using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SearchAlgorithmsLib
{
    public interface ISearchable<T>
    {
        MazeState<T> getInitialState();
        MazeState<T> getGoalState();
        List<MazeState<T>> getAllPossibleStates(MazeState<T> s);
    }

}
