using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace RobotServer
{
    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private TcpClient PythonClient;

        /// <summary>
        /// Our barebones TCP server using System.Net
        /// no recv functionality implemented at this time
        /// since we are just writing to our client.
        /// </summary>
        /// <param name="port">Port to listen to</param>
        public Server(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, port);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        /// <summary>
        /// Send a message if the PythonClient
        /// is connected.
        /// </summary>
        /// <param name="message"></param>
        public void SendClient(string message)
        {
            if (PythonClient == null)
            {
                Console.WriteLine("PythonClient has not connected.");
            }
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] bMessage = encoder.GetBytes(message); //encode our message as a byte buffer
            if (PythonClient.GetStream() != null)
            {
                try
                {
                    PythonClient.GetStream().Write(bMessage, 0, bMessage.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Start listening for our PythonClient
        /// </summary>
        private void ListenForClients()
        {
            this.tcpListener.Start();
            TcpClient client = null;
            Console.WriteLine("Listening for incoming PythonClient");
            while (client == null) //wait for client to not be null
            {
                client = this.tcpListener.AcceptTcpClient();
            }
            Console.WriteLine("PythonClient has connected.");
            HandleClient(client);
        }

        /// <summary>
        /// Handle our client and prepare to send
        /// him information
        /// </summary>
        /// <param name="client"></param>
        private void HandleClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            PythonClient = tcpClient;
        }
    }
}
