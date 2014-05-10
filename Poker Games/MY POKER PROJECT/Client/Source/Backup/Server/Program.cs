using System;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(55555);
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();
            Console.WriteLine(" >> " + "Server Started");
            ServerLobby.Initialize();
            ServerLobby.reader.Load("Users.xml");

            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                Client client = new Client(clientSocket);
            }
        }
    }
}