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
    public class Model : IModel
    {
        private Dictionary<string, MultiPlayerGame> multiGames;
        private List<string> games;
        private Dictionary<string, MultiPlayerGame> multiGamesArePlayed;
        private Dictionary<string, SinglePlayerGame<Position>> singleGames;
        private Dictionary<string, SinglePlayerGame<Position>> singleGamesArePlayed;
        private Dictionary<string, Solution<Position>> gameSolutions;

        public Model()
        {
            singleGames = new Dictionary<string, SinglePlayerGame<Position>>();
            singleGamesArePlayed = new Dictionary<string, SinglePlayerGame<Position>>();
            multiGames = new Dictionary<string, MultiPlayerGame>();
            multiGamesArePlayed = new Dictionary<string, MultiPlayerGame>();
            gameSolutions = new Dictionary<string, Solution<Position>>();
            games = new List<string>();
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(rows, cols);
            SinglePlayerGame<Position> game = new SinglePlayerGame<Position>();
            game.AddMaze(maze);
            singleGames.Add(name, game);
            return maze;
        }

        public SinglePlayerGame<Position> Solve(string name, int algoritem)
        {
            Adapter maze = new Adapter(singleGames[name].GetMaze());
            SinglePlayerGame<Position> game = singleGames[name];
            singleGames.Remove(name);
            singleGamesArePlayed.Add(name, game);
            if (!gameSolutions.ContainsKey(name))
            {
                switch (algoritem)
                {
                    case 0:
                        {
                            BFS<Position> bfs = new BFS<Position>();
                            Solution<Position> sol = bfs.Search(maze);
                            int num = bfs.GetNumberOfNodesEvaluated();
                            sol.SetNum(num);
                            gameSolutions.Add(name, sol);
                            game.AddSolution(sol);
                            break;
                        }
                    case 1:
                        {
                            DFS<Position> dfs = new DFS<Position>();
                            Solution<Position> sol = dfs.Search(maze);
                            int num = dfs.GetNumberOfNodesEvaluated();
                            sol.SetNum(num);
                            gameSolutions.Add(name, sol);
                            game.AddSolution(sol);
                            break;
                        }
                }
            }
            else
            {
                game.AddSolution(gameSolutions[name]);
            }
            return game;
        }

        public MultiPlayerGame Start(string name, int rows, int cols, TcpClient client)
        {
            Maze maze = GenerateMaze(name, rows, cols);
            MultiPlayerGame game = new MultiPlayerGame();
            game.AddMaze(maze);
            game.AddPlayer(client);
            multiGames.Add(name, game);
            games.Add(name);
            return game;
        }

        public List<string> NameOfGames()
        {
            return this.games;
        }

        public MultiPlayerGame Join(string name, TcpClient client) {
            MultiPlayerGame game = multiGames[name];
            game.AddPlayer(client);
            multiGames.Remove(name);
            multiGamesArePlayed.Add(name, game);
            games.Remove(name);
            return game;
        }

        public MultiPlayerGame Play(TcpClient client)
        {
            MultiPlayerGame currentGame = new MultiPlayerGame();

            foreach (MultiPlayerGame game in multiGamesArePlayed.Values)
            {
                if (game.GetPlayer().Equals(client) || game.GetPlayer2().Equals(client))
                {
                    currentGame = game;
                }
            }

            if (currentGame.GetPlayer().Equals(client))
            {
                return currentGame;
            }
            else
            {
                return currentGame;
            }

        }

        public void Close(string name, TcpClient client)
        {
            multiGamesArePlayed[name].EndGame(client);
            multiGamesArePlayed.Remove(name);
        }

        public Dictionary<string, MultiPlayerGame> getMultiplayerGames()
        {
            return multiGames;
        }
    }
}
