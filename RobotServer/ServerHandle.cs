 using System;
using System.Collections.Generic;
using System.Text;

namespace RobotServer
{
    class ServerHandle
    {
        public static void SceneSend(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _scene = _packet.ReadString();

            ServerSend.sendScene(_clientIdCheck, _scene);
            Console.WriteLine($"Client send {_scene} to Server was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_scene} could not be received");
            }
        }

        public static void SoundSend(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _sound = _packet.ReadString();

            ServerSend.sendSound(_clientIdCheck, _sound);
            Console.WriteLine($"Client send {_sound} to Server was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_sound} could not be received");
            }
        }

        public static void NoteSend(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _note = _packet.ReadString();

            ServerSend.sendNoteToTablet(_clientIdCheck, _note);

            Console.WriteLine($"User played {_note} ");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_note} could not be received");
            }
        }
        
        public static void XylomovementSend(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _movement = _packet.ReadString();

            ServerSend.sendXyloMovement(_clientIdCheck, _movement);
            Console.WriteLine($"Client send {_movement} to Server was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_movement} could not be received");
            }

        }

        public static void LegomovementSend(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _movement = _packet.ReadString();

            ServerSend.sendLegoMovement(_clientIdCheck, _movement);
            Console.WriteLine($"Client send {_movement} to Server was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_movement} could not be received");
            }

        }

        public static void HandovermovementSend(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _movement = _packet.ReadString();

            ServerSend.sendHandoverMovement(_clientIdCheck, _movement);
            Console.WriteLine($"Client send {_movement} to Server was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_movement} could not be received");
            }

        }

        public static void Connect4movementSend(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _movement = _packet.ReadString();

            ServerSend.sendConnect4Movement(_clientIdCheck, _movement);
            Console.WriteLine($"Client send {_movement} to Server was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_movement} could not be received");
            }
        }

        public static void SceneReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _scene = _packet.ReadString();

            Console.WriteLine($"{_scene} received was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_scene} could not be received");
            }

        }

        public static void SoundReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _sound = _packet.ReadString();

            Console.WriteLine($"{_sound} received was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_sound} could not be received");
            }

        }

        public static void XylomovementReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _movement = _packet.ReadString();

            Console.WriteLine($"{_movement} received was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_movement} could not be received");
            }

        }

        public static void LegomovementReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _movement = _packet.ReadString();

            Console.WriteLine($"{_movement} received was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_movement} could not be received");
            }

        }

        public static void HandovermovementReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _movement = _packet.ReadString();

            Console.WriteLine($"{_movement} received was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_movement} could not be received");
            }

        }

        public static void Connect4movementReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _movement = _packet.ReadString();

            Console.WriteLine($"{_movement} received was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"{_movement} could not be received");
            }

        }
        public static void RobotmovementSend(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            float _joint1 = _packet.ReadFloat();
            float _joint2 = _packet.ReadFloat();
            float _joint3 = _packet.ReadFloat();
            float _joint4 = _packet.ReadFloat();
            float _joint5 = _packet.ReadFloat();
            float _joint6 = _packet.ReadFloat();
            float _grippervalue = _packet.ReadFloat();
            float _speed = _packet.ReadFloat();
            float _measuredx = _packet.ReadFloat();
            float _measuredy = _packet.ReadFloat();
            float _measuredz = _packet.ReadFloat();


            ServerSend.sendRobotMovement(_clientIdCheck, _joint1, _joint2, _joint3, _joint4, _joint5, _joint6, _grippervalue, _speed, _measuredx, _measuredy, _measuredz);
            //Console.WriteLine($"Joints send Succesful");
            //Console.WriteLine($"Server send Joints was succesfull.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Joints were not send properly");
            }
        }

        public static void RobotmovementReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            float _joint1 = _packet.ReadFloat();
            float _joint2 = _packet.ReadFloat();
            float _joint3 = _packet.ReadFloat();
            float _joint4 = _packet.ReadFloat();
            float _joint5 = _packet.ReadFloat();
            float _joint6 = _packet.ReadFloat();
            float _grippervalue = _packet.ReadFloat();
            float _speed = _packet.ReadFloat();
            //Console.WriteLine($"Joints Received Succesful");
            //Console.WriteLine($"Joints succesfully received");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Joints could not be received");
            }
        }



        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            //string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            if (_fromClient != _clientIdCheck)
            {
                //Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }

        }

        public static void UDPTestReceived(int _fromClient, Packet _packet)
        {
            string _msg = _packet.ReadString();

            Console.WriteLine($"Received packet via UDP. Contains message: {_msg}");
        }
    }
}
