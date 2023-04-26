using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkMultipleClients
{
    internal class Server
    {
        private int count = 0;
        public void Start()
        {
            IPEndPoint localEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 11111);
            Socket listener = new Socket(SocketType.Stream,ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for connection ...");
            Socket server;
            

            while(true)
            {
                server = listener.Accept();
                Thread t = new Thread(new ParameterizedThreadStart(Run));
                t.Start(server);
                
            }
        }

        public void Run(object o)
        {
            int client = count;
            count++;
            Socket server = (Socket)o;
            Console.WriteLine("Client {0} connected", client);

            string msgReceived;
            byte[] bytesReceived = new byte[1024];
            int numBytesReceived;

            string msgSend;
            byte[] bytesSend;
            int numBytesSend;

            do
            {
                numBytesReceived = server.Receive(bytesReceived);
                msgReceived = Encoding.ASCII.GetString(bytesReceived, 0, numBytesReceived);
                Console.WriteLine("Client {0} -> {1}", client, msgReceived);

                msgSend = "Server -> " + msgReceived;
                bytesSend = Encoding.ASCII.GetBytes(msgSend);
                numBytesSend = server.Send(bytesSend);

            } while (msgReceived != "bye");

            Console.WriteLine("Client {0} disconnected",client);
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
