using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetzwerkProtokoll
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

            string msgReceived;
            byte[] bytesReceived = new byte[1024];
            int numBytesReceived;

            string msgSend;
            byte[] bytesSend;
            int numBytesSend;

            Socket server = listener.Accept();
            Console.WriteLine("Client connected");

            string[] parts;
            string command;
            string[] values;
            string parameter;
            

            Dictionary<string, string> data = new Dictionary<string, string>();

            do
            {

                numBytesReceived = server.Receive(bytesReceived);
                msgReceived = Encoding.ASCII.GetString(bytesReceived,0,numBytesReceived);
                Console.WriteLine("Client -> {0}", msgReceived);

                //Protocol
                parts = msgReceived.Split(' ');
                command = parts[0];
                

                if (command == "put")
                {
                    if(parts.Length > 1)
                    {
                        parameter = parts[1];
                        values = parameter.Split(':');
                        data.Add(values[0], values[1]);
                        msgSend = "Inserted " + values[0] + ":" + values[1];
                    } 
                    else
                    {
                        msgSend = "Command put needs a parameter <key>:<value>";
                    }                    

                } 
                else if(command == "get")
                {
                    if(parts.Length > 1)
                    {
                        parameter = parts[1];
                        if (data.ContainsKey(parameter))
                        {
                            msgSend = "Get " + data[parameter];
                        }
                        else
                        {
                            msgSend = "Key doesnt exist in data";
                        }
                    } 
                    else
                    {
                        msgSend = "Command get needs a parameter <key>";
                    }                            
                } 
                else if(command == "bye")
                {
                    msgSend = "bye";
                } 
                else
                {
                    msgSend = "Command is not supported";
                }

                //---

                bytesSend = Encoding.ASCII.GetBytes(msgSend);
                numBytesSend = server.Send(bytesSend);
                
            } while (msgReceived != "bye");
        }
    }
}
