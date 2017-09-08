using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatClient
{
    /// <summary>
    /// 2.0 in a Loop
    /// 2.1 Read a line from the console
    /// 2.2 Write the line to your stream-writer -- then remember to 'Flush()' the stream-writer.
    /// 2.3 Read a line from your stream-reader('ReadLine()') save it in a String and name it 'line'.
    /// 2.4 Print out the line in the console window('Console.WriteLine(line)).
    /// 2.5 Until either your own line or the incomming list is "STOP".
    /// </summary>
    class Client
    {
        public Client()
        {
            Console.WriteLine("Client is active...");
        }

        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 7070))
            using (NetworkStream ns = socket.GetStream())
            using (StreamReader streamReader = new StreamReader(ns))
            using (StreamWriter streamWriter = new StreamWriter(ns))
            {
                //2.0 in a Loop:
                while (true)
                {
                    //2.1 Read a line from the console:
                    string myLine = Console.ReadLine();

                    //2.2 Write the line to your stream-writer -- then remember to 'Flush()' the stream-writer.
                    streamWriter.WriteLine(myLine);
                    streamWriter.Flush();

                    //2.3 Read a line from your stream-reader('ReadLine()') save it in a String and name it 'line'.
                    string line = streamReader.ReadLine(); //Her læser vi hvad der kommer fra Server.

                    //2.4 Print out the line in the console window('Console.WriteLine(line)).
                    Console.WriteLine(line);

                    //2.5 Until either your own line or the incomming list is "STOP".
                    if (line == "STOP") 
                    {
                        Console.WriteLine("Server stopped itself...");
                        socket.Close();
                    }
                    if (myLine == "STOP")
                    {
                        Console.WriteLine("I, Client, stopped the Server and closed my socket...");
                        socket.Close();
                    }
                }
            }


        }
    }
}
