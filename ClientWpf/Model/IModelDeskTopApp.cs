using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using System.ComponentModel;
using MazeLib;

namespace ClientWpf.Model
{
    public interface IModelDeskTopApp : INotifyPropertyChanged
    {   
        //PlayerStatus IsFinished { get; }
        bool IsConnected { get; }
        int MazeCols { get; set; }
        int MazeRows { get; set; }
        string MazeName { get; set; }
        Position MyLocation { get; set; }
        Position OtherLocation { get; set; }
        Position FinishLocation { get; set; }
        //MazeRep FirstPlayerMazeGame { get; set; }
        //ObservableCollection<BitmapImage> MazeDisplay { get; set; }
        void Connect(string ip, int port);
        void Disconnect();
        void EndGame(string gameName);
        void SinglePlayerGame();
        void RestartGame();
        void MultiPlayerGame();
        void AskForHint();
        void MoveUp();
        void MoveDown();
        void MoveRight();
        void MoveLeft();
        // void WaitForEnemy();
    }
}
