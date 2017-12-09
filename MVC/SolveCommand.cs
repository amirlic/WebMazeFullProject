using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using SearchAlgorithmsLib;

namespace MVC
{
    class SolveCommand : ICommand
    {
        private IModel model;

        public SolveCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int algoritem = int.Parse(args[1]);
            SinglePlayerGame<Position> game = model.Solve(name, algoritem);
            JObject solveObj = new JObject();
            solveObj["Name"] = game.GetMaze().Name;
            solveObj["Solution"] = ParseSolToJson(game.GetSolution().GetSol());
            solveObj["NodesEvaluated"] = game.GetSolution().GetNum().ToString();
            return solveObj.ToString();
        }

        public string ParseSolToJson(List<MazeState<Position>> sol1)
        {
            string sol = "";
            if (sol1 != null)
            {
                for (int i = 1; i < sol1.Count(); i++)
                {
                    if (sol1[i - 1].getState().Row > sol1[i].getState().Row)
                    {
                        sol = "1" + sol;
                    }

                    else if (sol1[i - 1].getState().Row < sol1[i].getState().Row)
                    {
                        sol = "3" + sol;
                    }

                    else if (sol1[i - 1].getState().Col < sol1[i].getState().Col)
                    {
                        sol = "0" + sol;
                    }

                    else if (sol1[i - 1].getState().Col < sol1[i].getState().Col)
                    {
                        sol = "1" + sol;
                    }
                }
            }
            return sol;
        }
    }
}
