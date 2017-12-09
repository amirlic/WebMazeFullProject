using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClientWpf.ViewModel;
using MazeLib;
using MazeGeneratorLib;
using ClientWpf.View.Controls;

namespace ClientWpf.View
{
    /// <summary>
    /// Interaction logic for SinglePlayerMaze.xaml
    /// </summary>
    public partial class SinglePlayerMaze : Window
    {
        private SinglePlayerMazeViewModel vm;
        private Maze maze = new DFSMazeGenerator().Generate(2, 2);
        public int finish = 0;

        public int Algo
        {
            get { return (int)GetValue(AlgoProperty); }
            set { SetValue(AlgoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeRows2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlgoProperty =
            DependencyProperty.Register("SearchAlgorithm", typeof(int), typeof(SettingsWindow), new PropertyMetadata(0));


        public string MazeName2
        {
            get { return (string)GetValue(MazeName2Property); }
            set { SetValue(MazeName2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MazeName2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeName2Property =
            DependencyProperty.Register("MazeName2", typeof(string), typeof(Controls.MenuUserControl), new PropertyMetadata("Maze"));





        public int MazeRows2
        {
            get { return (int)GetValue(MazeRows2Property); }
            set { SetValue(MazeRows2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MazeRows2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeRows2Property =
            DependencyProperty.Register("MazeRows2", typeof(int), typeof(Controls.MenuUserControl), new PropertyMetadata(10));



        public int MazeCols2
        {
            get { return (int)GetValue(MazeCols2Property); }
            set { SetValue(MazeCols2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MazeCols2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeCols2Property =
            DependencyProperty.Register("MazeCols2", typeof(int), typeof(Controls.MenuUserControl), new PropertyMetadata(10));

        private void myCanvas2_Loaded(object sender, RoutedEventArgs e)
        {
            string x = maze.ToString();
            x = x.Replace("\n", String.Empty);
            x = x.Replace("\r", String.Empty);
            x = x.Replace("\t", String.Empty);
            //x = "00000001*10000000101011101010101111101010100010100010001000111011101111101111101000100010000010000010111#1110111010111110001010001000101000101010101110111010111010101000101000100010101011111010111110101010100000100000001010101011101111111010101000101010100000111011111010101011111000100010000010000010111010111110111110100000100000101000101011111111101110101010000000001000001000111111111111111111111";

            int noOfRecsInRow = 600 / maze.Rows;
            int noOfRecsInCol = 600 / maze.Cols;
            System.Console.WriteLine("{0}", maze);





            Rectangle pos = new Rectangle();
            pos.Height = noOfRecsInRow;
            pos.Width = noOfRecsInCol;
            Canvas.SetTop(pos, this.vm.MyLocation.Row * noOfRecsInRow);
            Canvas.SetLeft(pos, this.vm.MyLocation.Col * noOfRecsInCol);
            pos.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("flash.jpg", UriKind.Relative))
            };


            Rectangle end = new Rectangle();
            end.Height = noOfRecsInRow;
            end.Width = noOfRecsInCol;
            Canvas.SetTop(end, this.vm.FinishLocation.Row * noOfRecsInRow);
            Canvas.SetLeft(end, this.vm.FinishLocation.Col * noOfRecsInCol);
            end.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("Location.jpg", UriKind.Relative))
            };




            for (int i = 0; i < maze.Rows; i++)
            {
                for (int j = 0; j < maze.Cols; j++)
                {

                    Rectangle rec = new Rectangle();
                    rec.Height = noOfRecsInRow;
                    rec.Width = noOfRecsInCol;
                    if (x.ElementAt(i * maze.Cols + j) == '*') { rec.Fill = new SolidColorBrush(Colors.Silver); }
                    if (x.ElementAt(i * maze.Cols + j) == '#') { rec.Fill = new SolidColorBrush(Colors.Gold); }
                    if (x.ElementAt(i * maze.Cols + j) == '0') { rec.Fill = new SolidColorBrush(Colors.White); }
                    else if (x.ElementAt(i * maze.Cols + j) == '1') { rec.Fill = new SolidColorBrush(Colors.Black); }
                    Canvas.SetTop(rec, i * noOfRecsInRow);
                    Canvas.SetLeft(rec, j * noOfRecsInCol);

                    myCanvas2.Children.Add(rec);

                }
            }
            myCanvas2.Children.Add(pos);
            myCanvas2.Children.Add(end);
        }

        public SinglePlayerMaze()
        {
            this.vm = new SinglePlayerMazeViewModel();
            DataContext = this;
            InitializeComponent();
        }
        public SinglePlayerMaze(int rows, int cols)
        {
            this.MazeCols2 = cols;
            this.MazeRows2 = rows;
            this.vm = new SinglePlayerMazeViewModel();
            DataContext = this;
            InitializeComponent();
        }

        public SinglePlayerMaze(string name, int rows, int cols)
        {
            this.MazeName2 = name;
            this.MazeCols2 = cols;
            this.MazeRows2 = rows;
            vm = new SinglePlayerMazeViewModel();
            this.maze = vm.Game(this.MazeName2, this.MazeRows2, this.MazeCols2);
            this.DataContext = this;
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {

                this.solMaze_Click(sender, e);
            }
            switch (e.Key.ToString())
            {

                case "Right":
                    {
                        if (this.vm.MyLocation.Col == this.maze.Cols - 1)
                            break;
                        int myX, myY;
                        int otherX, otherY;
                        myX = (600 / this.maze.Cols) * this.vm.MyLocation.Col;
                        myY = (600 / this.maze.Rows) * this.vm.MyLocation.Row;
                        otherX = (600 / this.maze.Cols) * (this.vm.MyLocation.Col + 1);
                        otherY = myY;
                        Rectangle curr = new Rectangle();
                        Rectangle replace = new Rectangle();
                        foreach (UIElement child in myCanvas2.Children)
                        {
                            double top = (double)child.GetValue(Canvas.TopProperty);
                            double left = (double)child.GetValue(Canvas.LeftProperty);
                            if (top == myY && left == myX)
                            {
                                curr = (Rectangle)child;
                            }
                            if (top == otherY && left == otherX)
                            {
                                replace = (Rectangle)child;
                            }
                        }
                        if (!(replace.Fill.ToString() == new SolidColorBrush(Colors.Black).ToString()))
                        {


                            Brush c = curr.Fill;
                            Brush r = replace.Fill;
                            curr.Fill = r;
                            replace.Fill = c;

                            this.vm.MoveRight();
                            if (this.vm.MyLocation.Row == this.vm.FinishLocation.Row && this.vm.MyLocation.Col == this.vm.FinishLocation.Col)
                            {
                                MessageBox.Show("You Win!!");
                                this.finish = 1;
                                this.Close();
                            }
                        }
                        else
                            break;
                        break;
                    }

                case "Left":
                    {
                        if (this.vm.MyLocation.Col == 0)
                            break;
                        int myX, myY;
                        int otherX, otherY;
                        myX = (600 / this.maze.Cols) * this.vm.MyLocation.Col;
                        myY = (600 / this.maze.Rows) * this.vm.MyLocation.Row;
                        otherX = (600 / this.maze.Cols) * (this.vm.MyLocation.Col - 1);
                        otherY = myY;
                        Rectangle curr = new Rectangle();
                        Rectangle replace = new Rectangle();
                        foreach (UIElement child in myCanvas2.Children)
                        {
                            double top = (double)child.GetValue(Canvas.TopProperty);
                            double left = (double)child.GetValue(Canvas.LeftProperty);
                            if (top == myY && left == myX)
                            {
                                curr = (Rectangle)child;
                            }
                            if (top == otherY && left == otherX)
                            {
                                replace = (Rectangle)child;
                            }
                        }
                        if (!(replace.Fill.ToString() == new SolidColorBrush(Colors.Black).ToString()))
                        {


                            Brush c = curr.Fill;
                            Brush r = replace.Fill;
                            curr.Fill = r;
                            replace.Fill = c;

                            this.vm.MoveLeft();
                            if (this.vm.MyLocation.Row == this.vm.FinishLocation.Row && this.vm.MyLocation.Col == this.vm.FinishLocation.Col)
                            {
                                MessageBox.Show("You Win!!");
                                this.finish = 1;
                                this.Close();
                            }
                        }
                        else
                            break;
                        break;

                    }

                case "Down":
                    {
                        if (this.vm.MyLocation.Row == this.maze.Rows - 1)
                            break;
                        int myX, myY;
                        int otherX, otherY;
                        myX = (600 / this.maze.Cols) * this.vm.MyLocation.Col;
                        myY = (600 / this.maze.Rows) * this.vm.MyLocation.Row;
                        otherX = (600 / this.maze.Cols) * (this.vm.MyLocation.Col);
                        otherY = (600 / this.maze.Rows) * (this.vm.MyLocation.Row + 1);
                        Rectangle curr = new Rectangle();
                        Rectangle replace = new Rectangle();
                        foreach (UIElement child in myCanvas2.Children)
                        {
                            double top = (double)child.GetValue(Canvas.TopProperty);
                            double left = (double)child.GetValue(Canvas.LeftProperty);
                            if (top == myY && left == myX)
                            {
                                curr = (Rectangle)child;
                            }
                            if (top == otherY && left == otherX)
                            {
                                replace = (Rectangle)child;
                            }
                        }
                        if (!(replace.Fill.ToString() == new SolidColorBrush(Colors.Black).ToString()))
                        {


                            Brush c = curr.Fill;
                            Brush r = replace.Fill;
                            curr.Fill = r;
                            replace.Fill = c;

                            this.vm.MoveDown();
                            if (this.vm.MyLocation.Row == this.vm.FinishLocation.Row && this.vm.MyLocation.Col == this.vm.FinishLocation.Col)
                            {
                                MessageBox.Show("You Win!!");
                                this.finish = 1;
                                this.Close();
                            }

                        }
                        else
                            break;
                        break;
                        this.vm.MoveDown();
                        break;
                    }

                case "Up":
                    {
                        if (this.vm.MyLocation.Row == 0)
                            break;
                        int myX, myY;
                        int otherX, otherY;
                        myX = (600 / this.maze.Cols) * this.vm.MyLocation.Col;
                        myY = (600 / this.maze.Rows) * this.vm.MyLocation.Row;
                        otherX = (600 / this.maze.Cols) * (this.vm.MyLocation.Col);
                        otherY = (600 / this.maze.Rows) * (this.vm.MyLocation.Row - 1);
                        Rectangle curr = new Rectangle();
                        Rectangle replace = new Rectangle();
                        foreach (UIElement child in myCanvas2.Children)
                        {
                            double top = (double)child.GetValue(Canvas.TopProperty);
                            double left = (double)child.GetValue(Canvas.LeftProperty);
                            if (top == myY && left == myX)
                            {
                                curr = (Rectangle)child;
                            }
                            if (top == otherY && left == otherX)
                            {
                                replace = (Rectangle)child;
                            }
                        }
                        if (!(replace.Fill.ToString() == new SolidColorBrush(Colors.Black).ToString()))
                        {


                            Brush c = curr.Fill;
                            Brush r = replace.Fill;
                            curr.Fill = r;
                            replace.Fill = c;

                            this.vm.MoveUp();
                            if (this.vm.MyLocation.Row == this.vm.FinishLocation.Row && this.vm.MyLocation.Col == this.vm.FinishLocation.Col)
                            {
                                MessageBox.Show("You Win!!");
                                this.finish = 1;
                                this.Close();
                            }
                        }
                        else
                            break;
                        break;
                        this.vm.MoveUp();
                        break;
                    }
            }
        }

        private void solMaze_Click(object sender, RoutedEventArgs e)
        {
            string solve = this.vm.solve(this.MazeName2, this.Algo);

            System.Console.WriteLine("{0}", solve);
            foreach (char currChar in solve)
            {
                switch (currChar)
                {
                    case '1':
                        {

                            System.Console.WriteLine("1");
                            if (this.vm.MyLocation.Col == this.maze.Cols - 1)
                                break;
                            int myX, myY;
                            int otherX, otherY;
                            myX = (600 / this.maze.Cols) * this.vm.MyLocation.Col;
                            myY = (600 / this.maze.Rows) * this.vm.MyLocation.Row;
                            otherX = (600 / this.maze.Cols) * (this.vm.MyLocation.Col + 1);
                            otherY = myY;
                            Rectangle curr = new Rectangle();
                            Rectangle replace = new Rectangle();
                            foreach (UIElement child in myCanvas2.Children)
                            {
                                double top = (double)child.GetValue(Canvas.TopProperty);
                                double left = (double)child.GetValue(Canvas.LeftProperty);
                                if (top == myY && left == myX)
                                {
                                    curr = (Rectangle)child;
                                }
                                if (top == otherY && left == otherX)
                                {
                                    replace = (Rectangle)child;
                                }
                            }
                            if (!(replace.Fill.ToString() == new SolidColorBrush(Colors.Black).ToString()))
                            {


                                Brush c = curr.Fill;
                                Brush r = replace.Fill;
                                curr.Fill = r;
                                replace.Fill = c;

                                this.vm.MoveRight();
                                if (this.vm.MyLocation.Row == this.vm.FinishLocation.Row && this.vm.MyLocation.Col == this.vm.FinishLocation.Col)
                                {
                                    MessageBox.Show("You Win!!");
                                    this.finish = 1;
                                    this.Close();
                                }
                            }
                            else
                                break;
                            break;
                        }

                    case '0':
                        {
                            if (this.vm.MyLocation.Col == 0)
                                break;
                            int myX, myY;
                            int otherX, otherY;
                            myX = (600 / this.maze.Cols) * this.vm.MyLocation.Col;
                            myY = (600 / this.maze.Rows) * this.vm.MyLocation.Row;
                            otherX = (600 / this.maze.Cols) * (this.vm.MyLocation.Col - 1);
                            otherY = myY;
                            Rectangle curr = new Rectangle();
                            Rectangle replace = new Rectangle();
                            foreach (UIElement child in myCanvas2.Children)
                            {
                                double top = (double)child.GetValue(Canvas.TopProperty);
                                double left = (double)child.GetValue(Canvas.LeftProperty);
                                if (top == myY && left == myX)
                                {
                                    curr = (Rectangle)child;
                                }
                                if (top == otherY && left == otherX)
                                {
                                    replace = (Rectangle)child;
                                }
                            }
                            if (!(replace.Fill.ToString() == new SolidColorBrush(Colors.Black).ToString()))
                            {


                                Brush c = curr.Fill;
                                Brush r = replace.Fill;
                                curr.Fill = r;
                                replace.Fill = c;

                                this.vm.MoveLeft();
                                if (this.vm.MyLocation.Row == this.vm.FinishLocation.Row && this.vm.MyLocation.Col == this.vm.FinishLocation.Col)
                                {
                                    MessageBox.Show("You Win!!");
                                    this.finish = 1;
                                    this.Close();
                                }
                            }
                            else
                                break;
                            break;

                        }

                    case '3':
                        {
                            if (this.vm.MyLocation.Row == this.maze.Rows - 1)
                                break;
                            int myX, myY;
                            int otherX, otherY;
                            myX = (600 / this.maze.Cols) * this.vm.MyLocation.Col;
                            myY = (600 / this.maze.Rows) * this.vm.MyLocation.Row;
                            otherX = (600 / this.maze.Cols) * (this.vm.MyLocation.Col);
                            otherY = (600 / this.maze.Rows) * (this.vm.MyLocation.Row + 1);
                            Rectangle curr = new Rectangle();
                            Rectangle replace = new Rectangle();
                            foreach (UIElement child in myCanvas2.Children)
                            {
                                double top = (double)child.GetValue(Canvas.TopProperty);
                                double left = (double)child.GetValue(Canvas.LeftProperty);
                                if (top == myY && left == myX)
                                {
                                    curr = (Rectangle)child;
                                }
                                if (top == otherY && left == otherX)
                                {
                                    replace = (Rectangle)child;
                                }
                            }
                            if (!(replace.Fill.ToString() == new SolidColorBrush(Colors.Black).ToString()))
                            {


                                Brush c = curr.Fill;
                                Brush r = replace.Fill;
                                curr.Fill = r;
                                replace.Fill = c;

                                this.vm.MoveDown();
                                if (this.vm.MyLocation.Row == this.vm.FinishLocation.Row && this.vm.MyLocation.Col == this.vm.FinishLocation.Col)
                                {
                                    MessageBox.Show("You Win!!");
                                    this.finish = 1;
                                    this.Close();
                                }

                            }
                            else
                                break;
                            break;
                            this.vm.MoveDown();
                            break;
                        }

                    case '2':
                        {
                            if (this.vm.MyLocation.Row == 0)
                                break;
                            int myX, myY;
                            int otherX, otherY;
                            myX = (600 / this.maze.Cols) * this.vm.MyLocation.Col;
                            myY = (600 / this.maze.Rows) * this.vm.MyLocation.Row;
                            otherX = (600 / this.maze.Cols) * (this.vm.MyLocation.Col);
                            otherY = (600 / this.maze.Rows) * (this.vm.MyLocation.Row - 1);
                            Rectangle curr = new Rectangle();
                            Rectangle replace = new Rectangle();
                            foreach (UIElement child in myCanvas2.Children)
                            {
                                double top = (double)child.GetValue(Canvas.TopProperty);
                                double left = (double)child.GetValue(Canvas.LeftProperty);
                                if (top == myY && left == myX)
                                {
                                    curr = (Rectangle)child;
                                }
                                if (top == otherY && left == otherX)
                                {
                                    replace = (Rectangle)child;
                                }
                            }
                            if (replace.Fill != null && !(replace.Fill.ToString() == new SolidColorBrush(Colors.Black).ToString()))
                            {


                                Brush c = curr.Fill;
                                Brush r = replace.Fill;
                                curr.Fill = r;
                                replace.Fill = c;

                                this.vm.MoveUp();
                                if (this.vm.MyLocation.Row == this.vm.FinishLocation.Row && this.vm.MyLocation.Col == this.vm.FinishLocation.Col)
                                {
                                    MessageBox.Show("You Win!!");
                                    this.finish = 1;
                                    this.Close();
                                }
                            }
                            else
                                break;
                            break;
                            this.vm.MoveUp();
                            break;
                        }
                }
            }

        }

        private void mainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
