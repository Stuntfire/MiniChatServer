﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client myClient = new Client();
            myClient.Start();
            //Console.ReadLine();
        }
    }
}
