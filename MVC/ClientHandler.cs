using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace MVC
{
    class ClientHandler : IClientHandler
    {
        private Controller control;

        public ClientHandler()
        {
            this.control = new Controller();
        } 

        public void HandleClient(TcpClient client)
        {
            Task t = new Task(() =>
            {
                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);
                {
                    string line = "";
                    while (!line.StartsWith("close") && !line.StartsWith("generate") && !line.StartsWith("solve"))

                    {
                        line = reader.ReadString();
                        Console.WriteLine(line);
                        string result = this.control.ExecuteCommand(line, client);
                        writer.Write(result);
                        writer.Flush();
                    }
                }
                client.Close();
            });
            t.Start();
        }
    }

}
