using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MVC
{
    class PlayCommand : ICommand
    {
        private IModel model;
        public PlayCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string move = args[0];
            MultiPlayerGame game = model.Play(client);
            JObject playObj = new JObject();
            playObj["Name"] = game.GetMaze().Name;
            playObj["Direction"] = move.ToString();
            game.WritePlayMove(client, playObj.ToString());
            return "";
        }
    }
}
