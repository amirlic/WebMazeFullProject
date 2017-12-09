﻿/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ClientWpf.Model
{
    public class MultiPlayerMazeModel : GameModel
    {
        private Position myLocation;
        private Position otherLocation;
        private Position finishLocation;
        private Maze maze;
        private Client tcp;


        public MultiPlayerMazeModel()
        {

        }

        public List<string> GameList()
        {
            return null;
        }

        public Maze StartGame(string name, int rows, int cols)
        {
            this.tcp = new MultiPlayerClient();
            this.tcp.Start("generate " + name + " " + rows + " " + cols);
            this.maze = tcp.getMaze();
            InitMyLocation();
            InitFinishLocation();
            InitOtherLocation();
            return this.maze;
        }

        public Position MyLocation
        {
            get { return myLocation; }
            set
            {
                myLocation = value;
                NotifyPropertyChanged("MyLocation");
            }
        }
        public Position OtherLocation
        {
            get { return otherLocation; }
            set
            {
                otherLocation = value;
                NotifyPropertyChanged("OtherLocation");
            }
        }
        public Position FinishLocation
        {
            get { return finishLocation; }
            set
            {
                finishLocation = value;
                NotifyPropertyChanged("FinishLocation");
            }
        }

        public void Right()
        {
            this.myLocation = new Position(this.myLocation.Row, this.myLocation.Col + 1);
        }

        public void Left()
        {
            this.myLocation = new Position(this.myLocation.Row, this.myLocation.Col - 1);
        }

        public void Down()
        {
            this.myLocation = new Position(this.myLocation.Row - 1, this.myLocation.Col);
        }

        public void Up()
        {
            this.myLocation = new Position(this.myLocation.Row + 1, this.myLocation.Col);
        }

        public void InitMyLocation() { myLocation = maze.InitialPos; }

        public void InitOtherLocation() { otherLocation = maze.InitialPos; }

        public void InitFinishLocation() { finishLocation = maze.GoalPos; }
    }
}
*/