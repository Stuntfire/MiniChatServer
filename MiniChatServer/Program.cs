﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server myServer = new Server();
            //Console.WriteLine("Server is running...");
            myServer.Start();
        }
    }
}
