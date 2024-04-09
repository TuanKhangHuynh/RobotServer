using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace RobotServer
{
    class Server
    {
        public static int MaxPlayers { get; private set; }
        public static int Port { get; private set; }
        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();
        public delegate void PacketHandler(int _fromClient, Packet _packet);
        public static Dictionary<int, PacketHandler> packetHandlers;
        private static string myIPAdress = "10.163.181.115"; // Lab
        //private static string myIPAdress = "192.168.1.115"; // In-Situ

        private static TcpListener tcpListener;
        private static UdpClient udpListener;

        public static void Start(int _maxPlayers, int _port)
        {
            MaxPlayers = _maxPlayers;
            Port = _port;


            Console.WriteLine("Starting server...");
            InitializeServerData();
            // 138.246.3.115 IPAddress.Any 10.163.65.71
            // 10.163.181.29
            //tcpListener = new TcpListener(IPAddress.Parse("10.163.65.71"), Port);
            //10.163.181.29
            tcpListener = new TcpListener(IPAddress.Parse(myIPAdress), Port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);

            udpListener = new UdpClient(Port);
            udpListener.BeginReceive(UDPReceiveCallback, null);

            Console.WriteLine($"Server started on port {Port}.");
        }

        private static void TCPConnectCallback(IAsyncResult _result)
        {
            TcpClient _client = tcpListener.EndAcceptTcpClient(_result);
            tcpListener.BeginAcceptTcpClient(TCPConnectCallback, null);
            Console.WriteLine($"Incoming connection from {_client.Client.RemoteEndPoint}...");

            for (int i = 1; i <= MaxPlayers; i++)
            {
                if (clients[i].tcp.socket == null)
                {
                    clients[i].tcp.Connect(_client);
                    return;
                }
            }

            Console.WriteLine($"{_client.Client.RemoteEndPoint} failed to connect: Server full!");
        }

        private static void UDPReceiveCallback(IAsyncResult _result)
        {
            try
            {
                IPEndPoint _clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] _data = udpListener.EndReceive(_result, ref _clientEndPoint);
                udpListener.BeginReceive(UDPReceiveCallback, null);

                if (_data.Length < 4)
                {
                    return;
                }

                using (Packet _packet = new Packet(_data))
                {
                    int _clientId = _packet.ReadInt();

                    if (_clientId == 0)
                    {
                        return;
                    }

                    if (clients[_clientId].udp.endPoint == null)
                    {
                        clients[_clientId].udp.Connect(_clientEndPoint);
                        return;
                    }

                    if (clients[_clientId].udp.endPoint.ToString() == _clientEndPoint.ToString())
                    {
                        clients[_clientId].udp.HandleData(_packet);
                    }
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine($"Error receiving UDP data: {_ex}");
            }
        }

        public static void SendUDPData(IPEndPoint _clientEndPoint, Packet _packet)
        {
            try
            {
                if (_clientEndPoint != null)
                {
                    udpListener.BeginSend(_packet.ToArray(), _packet.Length(), _clientEndPoint, null, null);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine($"Error sending data to {_clientEndPoint} via UDP: {_ex}");
            }
        }

        private static void InitializeServerData()
        {
            for (int i = 1; i <= MaxPlayers; i++)
            {
                clients.Add(i, new Client(i));
            }

            packetHandlers = new Dictionary<int, PacketHandler>()
            {

                { (int)ClientPackets.welcomeReceived, ServerHandle.WelcomeReceived },
                { (int)ClientPackets.updTestReceived, ServerHandle.UDPTestReceived },
                { (int)ClientPackets.sceneSend, ServerHandle.SceneSend },
                { (int)ClientPackets.sceneReceived, ServerHandle.SceneReceived },
                { (int)ClientPackets.soundSend, ServerHandle.SoundSend },
                { (int)ClientPackets.soundReceived, ServerHandle.SoundReceived },
                { (int)ClientPackets.noteSend, ServerHandle.NoteSend },
                /*{ (int)ClientPackets.movement1Received, ServerHandle.Movement1Received },
                { (int)ClientPackets.movement2Received, ServerHandle.Movement2Received },
                { (int)ClientPackets.movement1send, ServerHandle.Movement1Send },
                { (int)ClientPackets.movement2send, ServerHandle.Movement2Send }, */
                { (int)ClientPackets.xylomovementSend, ServerHandle.XylomovementSend },
                { (int)ClientPackets.xylomovementReceived, ServerHandle.XylomovementReceived},
                { (int)ClientPackets.legomovementSend, ServerHandle.LegomovementSend },
                { (int)ClientPackets.legomovementReceived, ServerHandle.LegomovementReceived},
                { (int)ClientPackets.handovermovementSend, ServerHandle.HandovermovementSend },
                { (int)ClientPackets.handovermovementReceived, ServerHandle.HandovermovementReceived},
                { (int)ClientPackets.connect4movementSend, ServerHandle.Connect4movementSend },
                { (int)ClientPackets.connect4movementReceived, ServerHandle.Connect4movementReceived},
                { (int)ClientPackets.robotmovementSend, ServerHandle.RobotmovementSend },
                { (int)ClientPackets.robotmovementReceived, ServerHandle.RobotmovementReceived},
                //{ (int)ClientPackets.updTestReceived, ServerHandle.UDPTestReceived }
            };
            Console.WriteLine("Initialized packets.");
        }
    }
}
