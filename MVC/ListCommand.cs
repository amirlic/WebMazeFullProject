﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MVC
{
    class ListCommand : ICommand
    {
        private IModel model;
        public ListCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            List<string> games = model.NameOfGames();
            Console.WriteLine(JsonConvert.SerializeObject(games));
            return JsonConvert.SerializeObject(games) + '\n';
        }
    }
}
