using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServer
{
    class ServerSend
    {
        private static void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].tcp.SendData(_packet);
        }

        private static void SendUDPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_toClient].udp.SendData(_packet);
        }

        private static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet);
            }
        }
        private static void SendTCPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        private static void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                Server.clients[i].udp.SendData(_packet);
            }
        }
        private static void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.MaxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].udp.SendData(_packet);
                }
            }
        }

        #region Packets
        public static void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
            }
        }
        

        // We probably send the Scene to ClientID 2 and 3 => send to all except for 1 
        public static void sendScene(int _toClient, string _msg)
        {
           using (Packet _packet = new Packet((int)ServerPackets.scene))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendUDPDataToAll(1, _packet);
            }
        }
        

        public static void sendSound(int _toClient, string _msg)
        {
           using (Packet _packet = new Packet((int)ServerPackets.sound))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendUDPDataToAll(1, _packet);
            }
        }

        public static void sendNoteToTablet(int _toClient, string _msg)
        {
           using (Packet _packet = new Packet((int)ServerPackets.noteToTablet))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendUDPData(1, _packet);
            }
        }



        // We want to send specific commands from one Client to the other client
        // Like Xylophne movement 1 or Duplo Movement 2
        public static void sendXyloMovement(int _toClient, string _msg)
        {
           using (Packet _packet = new Packet((int)ServerPackets.xylomovement))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendUDPData(2, _packet);
            }
        }


        public static void sendLegoMovement(int _toClient, string _msg)
        {
           using (Packet _packet = new Packet((int)ServerPackets.legomovement))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);
                Console.WriteLine($"Server send {_msg} to Client was succesfull.");
                SendUDPData(2, _packet);
            }
        }

        public static void sendHandoverMovement(int _toClient, string _msg)
        {
           using (Packet _packet = new Packet((int)ServerPackets.handovermovement))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);
                Console.WriteLine($"Server send {_msg} to Client was succesfull.");
                SendUDPData(2, _packet);
            }
        }


        public static void sendConnect4Movement(int _toClient, string _msg)
        {
           using (Packet _packet = new Packet((int)ServerPackets.connect4movement))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);
                Console.WriteLine($"Server send {_msg} to Client was succesfull.");
                SendUDPData(2, _packet);
            }
        }

        public static void sendRobotMovement(int _toClient, float  _joint1, float _joint2, float _joint3, float _joint4, float _joint5, float _joint6, float _grippervalue, float _speed, float _measuredx, float _measuredy, float _measuredz)
        {
           using (Packet _packet = new Packet((int)ServerPackets.robotmovement))
            {
                _packet.Write(_joint1);
                _packet.Write(_joint2);
                _packet.Write(_joint3);
                _packet.Write(_joint4);
                _packet.Write(_joint5);
                _packet.Write(_joint6);
                _packet.Write(_grippervalue);
                _packet.Write(_speed);
                _packet.Write(_measuredx);
                _packet.Write(_measuredy);
                _packet.Write(_measuredz);
                _packet.Write(_toClient);

                SendUDPData(3, _packet);
            }
        }

        #endregion
        
        public static void UDPTest(int _toClient)
        {
            using (Packet _packet = new Packet((int)ServerPackets.udpTest))
            {
                _packet.Write("A test packet for UDP.");
            }

        }
    }
}
