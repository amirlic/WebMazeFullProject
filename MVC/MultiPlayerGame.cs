using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using System.IO;

namespace MVC
{
    public class MultiPlayerGame : IGame
    {
        private TcpClient player1;
        private TcpClient player2;
        private Maze maze;
        private BinaryWriter writer1;
        private BinaryWriter writer2;
        private bool isPlay = false;

        public void AddPlayer(TcpClient client)
        {
            if (player1 == null)
            {
                this.player1 = client;
                NetworkStream stream = player1.GetStream();
                this.writer1 = new BinaryWriter(stream);
            }
            else if (player2 == null)
            {
                this.player2 = client;
                this.isPlay = true;
                NetworkStream stream2 = player2.GetStream();
                this.writer2 = new BinaryWriter(stream2);
            }
            else if (player2 != null && player1 != null)
            {
                Console.WriteLine("ERORR 2 PLEYERS ALREDY JOIN");
            }
        }

        public void AddMaze(Maze maze)
        {
            this.maze = maze;
        }

        public TcpClient GetPlayer()
        {
            return this.player1;
        }

        public TcpClient GetPlayer2()
        {
            return this.player2;
        }

        public BinaryWriter GetPlayerWriter()
        {
            return this.writer1;
        }

        public BinaryWriter GetPlayerWriter2()
        {
            return this.writer2;
        }

        public Maze GetMaze()
        {
            return this.maze;
        }

        public void WritePlayMove(TcpClient dest, string massage)
        {

            if (dest.Equals(this.player1))
            {
                this.writer2.Write(massage);
            }
            else if (dest.Equals(this.player2))
            {
                this.writer1.Write(massage);
            }
            else
            {
                Console.WriteLine("ERORR");
            }
        }

        public bool IsPlaying()
        {
            if (isPlay) { return true; }
            return false;
        }

        public void EndGame(TcpClient dest)
        {
            if (dest.Equals(this.player1))
            {
                this.writer2.Write("close");
            }
            else if (dest.Equals(this.player2))
            {
                this.writer1.Write("close");
            }
            else
            {
                Console.WriteLine("ERORR");
            }
        }
     }
}
