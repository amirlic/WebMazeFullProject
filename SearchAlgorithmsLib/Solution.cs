using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;

namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {
        private List<T> sol;
        private List<MazeState<T>> sol1;
        int numberOfNodesEvaluated;

        public Solution()
        {
            sol1 = new List<MazeState<T>>();
        }
        public Solution(List<T> sol)
        {
            this.sol = sol;
        }

        public Solution(List<MazeState<T>> sol1)
        {
            this.sol1 = sol1;
        }

        public void AddState(MazeState<T> stat)
        {
            this.sol1.Add(stat);
        }

        public List<MazeState<T>> GetSol()
        {
            return this.sol1;
        }

        public void SetNum(int num)
        {
            this.numberOfNodesEvaluated = num;
        }

        public int GetNum()
        {
            return this.numberOfNodesEvaluated;
        }
    }
}
