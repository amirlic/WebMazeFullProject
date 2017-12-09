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
using ClientWpf.Model;
using ClientWpf.ViewModel;

namespace ClientWpf.View
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private SettingsViewModel vm;

        public SettingsWindow()
        {
            InitializeComponent();
            this.vm = new SettingsViewModel();
            this.DataContext = this.vm;
        }

        public int MazeRows
        {
            get { return (int)GetValue(MazeRowsProperty); }
            set { SetValue(MazeRowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeRows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeRowsProperty =
            DependencyProperty.Register("MazeRows", typeof(int), typeof(SettingsWindow), new PropertyMetadata(10));



        public int MazeCols
        {
            get { return (int)GetValue(MazeColsProperty); }
            set { SetValue(MazeColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeCols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeColsProperty =
            DependencyProperty.Register("MazeCols", typeof(int), typeof(SettingsWindow), new PropertyMetadata(10));

        public int Algo
        {
            get { return (int)GetValue(AlgoProperty); }
            set { SetValue(AlgoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MazeRows2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlgoProperty =
            DependencyProperty.Register("SearchAlgorithm", typeof(int), typeof(SettingsWindow), new PropertyMetadata(10));



        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.vm.SaveSettings();
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }
    }
}
