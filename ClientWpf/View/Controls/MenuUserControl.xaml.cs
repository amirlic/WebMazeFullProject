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


namespace ClientWpf.View.Controls
{
    /// <summary>
    /// Interaction logic for MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {

        public MenuUserControl()
        {
            InitializeComponent();
        }

        public int MazeRows
        {
            get { return (int)GetValue(MazeRowsProperty); }
            set { SetValue(MazeRowsProperty, value);}
        }

        // Using a DependencyProperty as the backing store for MazeRows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeRowsProperty =
            DependencyProperty.Register("MazeRows", typeof(int), typeof(MenuUserControl), new PropertyMetadata(10));



        public int MazeCols
        {
            get { return (int)GetValue(MazeColsProperty); }
            set { SetValue(MazeColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeCols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeColsProperty =
            DependencyProperty.Register("MazeCols", typeof(int), typeof(MenuUserControl), new PropertyMetadata(10));



        public string MazeName
        {
            get { return (string)GetValue(MazeNameProperty); }
            set { SetValue(MazeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeNameProperty =
            DependencyProperty.Register("MazeName", typeof(string), typeof(MenuUserControl), new PropertyMetadata("maze"));


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}