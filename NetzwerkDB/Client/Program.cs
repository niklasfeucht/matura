using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint localEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 11111);
            Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            client.Connect(localEndPoint);
            Console.WriteLine("Client connected");

            string msgReceived;
            byte[] bytesReceived = new byte[1024];
            int numBytesReceived;

            string msgSend;
            byte[] bytesSend;
            int numBytesSend;

            do
            {
                Console.Write(">>");
                msgSend = Console.ReadLine();
                bytesSend = Encoding.ASCII.GetBytes(msgSend);
                numBytesSend = client.Send(bytesSend);

                numBytesReceived = client.Receive(bytesReceived);
                msgReceived = Encoding.ASCII.GetString(bytesReceived,0, numBytesReceived);
                Console.WriteLine("Server -> {0}", msgReceived);
            } while (msgSend != "bye");

            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
