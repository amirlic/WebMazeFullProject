using ClientProj;
using ClientWpf.Model;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientWpf.ViewModel
{
    class MultiPlayerMazeViewModel : ViewModel
    {
        private Client model;

        public MultiPlayerMazeViewModel()
        {
            //we pass 1 as the game kind because it is a single player game
            this.model = new Client();
        }

        public Maze Game(string name, int rows, int cols)
        {

            string ans = model.Command("start " + name + " " + rows + " " + cols);
            return Maze.FromJSON(ans);
        }

        public string List()
        {
            string ans = this.model.getList();
            return ans;
        }

        public Position MyLocation
        {
            get { return model.MyLocation; }
            set
            {
                model.MyLocation = value;
                NotifyPropertyChanged("MyLocation");
            }
        }
        public Position OtherLocation
        {
            get { return model.OtherLocation; }
            set
            {
                model.OtherLocation = value;
                NotifyPropertyChanged("OtherLocation");
            }
        }
        public Position FinishLocation
        {
            get { return model.FinishLocation; }
            set
            {
                model.FinishLocation = value;
                NotifyPropertyChanged("FinishLocation");
            }
        }

        public void MoveRight()
        {
            this.model.Right();
        }

        public void MoveLeft()
        {
            this.model.Left();
        }

        public void MoveDown()
        {
            this.model.Down();
        }

        public void MoveUp()
        {
            this.model.Up();
        }
    }
}
