using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetzwerkDB
{
    internal class Server
    {
        private int count = 0;
        public void Start()
        {
            IPEndPoint localEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 11111);
            Socket listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Socket server;
            Database.Connect();

            while (true)
            {
                server = listener.Accept();
                Thread t = new Thread(new ParameterizedThreadStart(Run));
                t.Start(server);
            }
            
        }

        public void Run(object o)
        {
            Socket server = (Socket)o;
            int client = count++;

            Console.WriteLine("Client {0} connected", client);

            string msgReceived;
            byte[] bytesReceived = new byte[1024];
            int numBytesReceived;

            string msgSend;
            byte[] bytesSend;
            int numBytesSend;

            string cmd;
            string table;
            int id;
            string desc;
            string[] parts;

            int rows=0;

            do
            {
                numBytesReceived = server.Receive(bytesReceived);
                msgReceived = Encoding.ASCII.GetString(bytesReceived, 0, numBytesReceived);
                Console.WriteLine("Client {0} -> {1}", client, msgReceived);

                //Protocoll
                parts = msgReceived.Split(' ');
                cmd = parts[0];
                if(cmd == "get")
                {
                    if(parts.Length == 2)
                    {
                        table = parts[1];
                        List<int> schools = Database.GetSchools();
                        msgSend = "";
                        foreach(int i in schools)
                        {
                            msgSend += Database.GetSchoolDesc(i) + ", ";
                        }
                    }
                    else if(parts.Length == 3)
                    {
                        table = parts[1];
                        id = int.Parse(parts[2]);
                        msgSend = Database.GetSchoolDesc(id);
                    }
                    else
                    {
                        msgSend = "command get needs parameters <table> [id]";
                    }
                }
                else if(cmd == "post")
                {
                    if(parts.Length > 2)
                    {
                        table = parts[1];
                        if(table == "school" && parts.Length == 3)
                        {
                            desc = parts[2];
                            rows = Database.InsertSchool(desc);
                            msgSend = "inserted " + rows + " rows";
                        }
                        else
                        {
                            msgSend = "command post needs the right amount of parameters";
                        }
                    }
                    else
                    {
                        msgSend = "command post needs parameters <table> <value> ...";
                    }
                }
                else if(cmd == "put")
                {
                    if (parts.Length > 2)
                    {
                        table = parts[1];
                        if (table == "school" && parts.Length == 4)
                        {
                            id = int.Parse(parts[2]);
                            desc = parts[3];
                            rows = Database.UpdateSchool(id, desc);
                            msgSend = "updated " + rows + " rows";
                        }
                        else
                        {
                            msgSend = "command put needs the right amount of parameters";
                        }
                    }
                    else
                    {
                        msgSend = "command put needs parameters <table> <value> ...";
                    }
                }
                else if(cmd == "delete")
                {
                    if(parts.Length == 3)
                    {
                        table = parts[1];
                        id = int.Parse(parts[2]);
                        rows = Database.DeleteSchool(id);
                        msgSend = "deleted " + rows + " rows";
                    }
                    else
                    {
                        msgSend = "command delete needs parameters <table> <id>";
                    }
                }
                else if(cmd == "bye")
                {
                    msgSend = "goodbye";
                }
                else
                {
                    msgSend = "command is not supported";
                }

                bytesSend = Encoding.ASCII.GetBytes(msgSend);
                numBytesSend = server.Send(bytesSend);

            } while (msgReceived != "bye");

            Console.WriteLine("Client {0} disconnected", client);

            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
