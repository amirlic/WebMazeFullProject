using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8000;
            IClientHandler ic = new ClientHandler();
            Server server = new Server(port, ic);
            server.Start();
            Console.ReadKey();
        }
    }
}
