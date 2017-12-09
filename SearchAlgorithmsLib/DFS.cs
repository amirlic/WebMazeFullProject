using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS<T> : Searcher<T>
    {
        private Solution<T> sol = new Solution<T>();

        public override Solution<T> Search(ISearchable<T> searchable)
        {
            HashSet<MazeState<T>> closed = new HashSet<MazeState<T>>();

            Stack<MazeState<T>> depth = new Stack<MazeState<T>>();

            //I use this more than once so I would rather save to in a variable
            MazeState<T> entrance = searchable.getInitialState();

            MazeState<T> goal = searchable.getGoalState();


            //This is our first state, i.e the entrance of the maze
            MazeState<T> curr = searchable.getInitialState();

            //In case that the entrance and exit are in the same spot
            //I check the option that the entrance and the exit
            //aren't in the same spot because more often than not
            //they won't be in the same spot so in the assembly perspectibe
            //Id'e rather guess that they are not in the same spot
            //and count on branching
            if (!curr.Equals(searchable.getGoalState()))
            {
                depth.Push(curr);
            }
            else
            {
                sol.AddState(curr);
                return sol;
            }

            //while our stack isn't empty
            while (depth.Count() != 0)
            {
                //get current state
                curr = depth.Pop();

                //getting the liost of all possible successors
                List<MazeState<T>> successors = searchable.getAllPossibleStates(curr);

                foreach (MazeState<T> suc in successors)
                {
                    //if we hadn't visited this state before
                    if (!closed.Contains(suc))
                    {

                        closed.Add(suc);
                        IncNumberOfNodesEvaluated();
                        if (suc.Equals(goal))
                        {
                            sol = BackTrace(suc);
                            return sol;
                        }
                        //I check that the successor is not null first because it is more efficient
                        //because if the successor isn't null than we will not check the second rule which depends on the
                        //first
                        //if (suc.CameFrom() == null && suc != searchable.getInitialState())
                        //{
                        //    suc.setCameFrom(curr);
                        //}

                        depth.Push(suc);
                    }
                }
            }
            //just in case
            return sol;
        }
    }
}