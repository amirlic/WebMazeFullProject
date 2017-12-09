using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;


namespace MVC
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);
        SinglePlayerGame<Position> Solve(string name, int algoritem);
        MultiPlayerGame Start(string name, int rows, int cols, TcpClient client);
        List<string> NameOfGames();
        MultiPlayerGame Join(string name, TcpClient client);
        MultiPlayerGame Play(TcpClient client);
        void Close(string name, TcpClient client);
    }
}
