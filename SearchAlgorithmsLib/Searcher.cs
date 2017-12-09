using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        private SimplePriorityQueue<MazeState<T>> openList;
        private int evaluatedNodes;
        public Searcher() {
            openList = new SimplePriorityQueue<MazeState<T>>();
            evaluatedNodes = 0;
        }
        public void AddToOpenList(MazeState<T> state,double cost) {
            this.openList.Enqueue(state,(float)cost);
        }
        /// <summary>
        /// returns whether or not an object is contained within the open list
        /// </summary>
        /// <param name="obj">the object to look if is in the open list</param>
        /// <returns>bool</returns>
        public bool IsContaining(MazeState<T> obj)
        {
            return this.openList.Contains(obj);
        }

        protected MazeState<T> PopOpenList() {
            ++this.evaluatedNodes;
            //return openList.poll;
            MazeState<T> f = openList.First();
            openList.Dequeue();
            return f;
        }
        // a property of openList 
        public int OpenListSize {
            // it is a read-only property :) 
            get
            {
                return openList.Count;
            }
        }
        // ISearcher’s methods:
        public int GetNumberOfNodesEvaluated() {
            return this.evaluatedNodes;
        }

        /// <summary>
        /// increases the number of evaluated nodes by 1
        /// </summary>
        public void IncNumberOfNodesEvaluated()
        {
            ++this.evaluatedNodes;
        }
        /// <summary>
        /// increases the number of evaluated nodes by N
        /// </summary>
        /// <param name="N"></param>
        public void IncNumberOfNodesEvaluatedByN(int N)
        {
            this.evaluatedNodes += N;
        }


        /// <summary>
        /// this function changes the priority of a member of the open list
        /// </summary>
        /// <param name="stat">the maze state to change the priority of</param>
        /// <param name="prio">the new priority of ther maze state</param>
        public void ChangeMemberPriority(MazeState<T> stat, double prio)
        {
            //changing the priority in the maze state it self
            stat.SetCost(prio);
            //updating the open list according trho the new priority of stat
            openList.UpdatePriority(stat, (float)prio);
        }

        



        public Solution<T> BackTrace(MazeState<T> current)
        {
            Solution<T> sol = new Solution<T>();
            sol.AddState(current);

            while(current.CameFrom() != null)
            {
                sol.AddState(current.CameFrom());
                current = current.CameFrom();
            }

            return sol;

        }

        public abstract Solution<T> Search(ISearchable<T> searchable);
    }
}
