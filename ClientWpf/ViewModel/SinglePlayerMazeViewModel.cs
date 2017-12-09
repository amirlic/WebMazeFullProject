using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MazeLib;
using ClientWpf.Model;
using ClientProj;

namespace ClientWpf.ViewModel
{
    class SinglePlayerMazeViewModel : ViewModel
    {
        private Client model;

        public SinglePlayerMazeViewModel()
        {
            //we pass 1 as the game kind because it is a single player game
            this.model = new Client();
        }

        public Maze Game(string name, int rows, int cols)
        {
            string ans = model.Command("generate " + name + " " + rows + " " + cols);
            return Maze.FromJSON(ans);
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

        public string solve(string name, int algo)
        {
            return this.model.Command("solve " + name + " " + algo);
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
