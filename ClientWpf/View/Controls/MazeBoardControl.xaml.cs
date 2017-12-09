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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientWpf.ViewModel;
using MazeLib;

namespace ClientWpf.View.Controls
{
    /// <summary>
    /// Interaction logic for MazeBoardControl.xaml
    /// </summary>
    public partial class MazeBoardControl : UserControl
    {
        public MazeBoardControl()
        {
            InitializeComponent();
            //myCanvas_Loaded();
        }




        public string MazeName
        {
            get { return (string)GetValue(MazeNameProperty); }
            set { SetValue(MazeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeNameProperty =
            DependencyProperty.Register("MazeName", typeof(string), typeof(MazeBoardControl), new PropertyMetadata("Maze"));



        public int MazeRows
        {
            get { return (int)GetValue(MazeRowsProperty); }
            set { SetValue(MazeRowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeRows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeRowsProperty =
            DependencyProperty.Register("MazeRows", typeof(int), typeof(MazeBoardControl), new PropertyMetadata(10));






        public int MazeCols
        {
            get { return (int)GetValue(MazeColsProperty); }
            set { SetValue(MazeColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeCols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeColsProperty =
            DependencyProperty.Register("MazeCols", typeof(int), typeof(MazeBoardControl), new PropertyMetadata(10));

        public string MyMaze
        {
            get { return (string)GetValue(MazeProperty); }
            set { SetValue(MazeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeCols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeProperty =
            DependencyProperty.Register("MyMaze", typeof(string), typeof(MazeBoardControl), new PropertyMetadata("00000001*10000000101011101010101111101010100010100010001000111011101111101111101000100010000010000010111#1110111010111110001010001000101000101010101110111010111010101000101000100010101011111010111110101010100000100000001010101011101111111010101000101010100000111011111010101011111000100010000010000010111010111110111110100000100000101000101011111111101110101010000000001000001000111111111111111111111"));


        
        public void printMaze()
        { }
        private void myCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            string x = MyMaze.ToString();
            //x = "00000001*10000000101011101010101111101010100010100010001000111011101111101111101000100010000010000010111#1110111010111110001010001000101000101010101110111010111010101000101000100010101011111010111110101010100000100000001010101011101111111010101000101010100000111011111010101011111000100010000010000010111010111110111110100000100000101000101011111111101110101010000000001000001000111111111111111111111";
            
            int noOfRecsInRow = 600 / MazeRows;
            int noOfRecsInCol = 600 / MazeCols;
            System.Console.WriteLine("{0},{1}", noOfRecsInRow, noOfRecsInCol);

            for (int i = 0; i < MazeRows; i++)
            {
                for (int j = 0; j < MazeCols; j++)
                {
                    
                    Rectangle rec = new Rectangle();
                    rec.Height = noOfRecsInRow;
                    rec.Width = noOfRecsInCol;
                    if(x.ElementAt(i * MazeCols + j) == '*') { rec.Fill = new SolidColorBrush(Colors.Silver); }
                    if (x.ElementAt(i * MazeCols + j) == '#') { rec.Fill = new SolidColorBrush(Colors.Gold); }
                    if (x.ElementAt(i*MazeCols + j) == '0') { rec.Fill = new SolidColorBrush(Colors.White); }
                    else if(x.ElementAt(i * MazeCols + j) == '1'){ rec.Fill = new SolidColorBrush(Colors.Black); }
                    Canvas.SetTop(rec, i * noOfRecsInRow);
                    Canvas.SetLeft(rec, j * noOfRecsInCol);
                    
                    myCanvas.Children.Add(rec);

                }
            }
        }
    }
}