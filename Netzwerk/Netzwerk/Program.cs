using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Netzwerk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint localEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 11111);
            Socket listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for connection ...");

            string msgReceived = null;
            byte[] bytesReceived = new byte[1024];
            int numBytesReceived;

            Socket server = listener.Accept();
            Console.WriteLine("Client connected");

            string msgSend = null;
            byte[] bytesSend;
            int numBytesSend;

            do
            {
                bytesReceived = new byte[1024];
                numBytesReceived = server.Receive(bytesReceived);
                msgReceived = Encoding.ASCII.GetString(bytesReceived, 0, numBytesReceived);
                Console.WriteLine("Client -> " + msgReceived);

                msgSend = "Received " + msgReceived;
                bytesSend = Encoding.ASCII.GetBytes(msgSend);
                numBytesSend = server.Send(bytesSend);

            } while (msgReceived != "bye");
            

            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
