using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;

namespace MVC
{
    class JoinCommand : ICommand
    {
        private IModel model;
        public JoinCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            MultiPlayerGame game = model.Join(name, client);
            Maze maze = game.GetMaze();
            maze.Name = name;
            return maze.ToJSON();
        }
    }
}
