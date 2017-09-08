using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer
{
    class Server
    {
        public Server()
        {

        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);
            server.Start();

            Console.WriteLine("Server is running...");

            DoClient(server);
        }

        private static void DoClient(TcpListener server)
        {
            while (true)
            {
                using (TcpClient socket = server.AcceptTcpClient())
                using (NetworkStream ns = socket.GetStream())
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    while (true)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);

                        string myLine = Console.ReadLine();

                        sw.WriteLine(myLine);

                        sw.Flush();

                        if (line == "STOP")
                        {
                            Console.Write("Server was stopped by Client...");
                            server.Stop();
                        }
                        if (myLine == "STOP")
                        {
                            Console.WriteLine("Server was stopped by Server ... hmm, I stopped myself!?");
                            server.Stop();
                        }
                    }
                }
            }
            
        }
    }
}
