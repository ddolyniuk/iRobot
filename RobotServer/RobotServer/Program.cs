using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server robotserver = new Server(8422);
            /*
             * Wait for user input and send to our PythonClient
             * It will then print the message.
             */
            while (true)
            {
                string line = Console.ReadLine();
                robotserver.SendClient(line);
            }
        }
    }
}
