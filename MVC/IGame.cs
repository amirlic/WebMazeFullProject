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
    public interface IGame
    {
        void AddPlayer(TcpClient client);

        void AddMaze(Maze maze);

        TcpClient GetPlayer();

        Maze GetMaze();
    }
}
