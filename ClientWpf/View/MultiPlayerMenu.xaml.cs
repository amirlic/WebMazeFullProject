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
using ClientWpf.View.Controls;
using ClientWpf.Model;
using System.Collections.ObjectModel;
using System.Threading;

namespace ClientWpf.View
{
    /// <summary>
    /// Interaction logic for MultiPlayerMenu.xaml
    /// </summary>
    public partial class MultiPlayerMenu : Window
    {
        private MultiPlayerViewModel vm;
        private MenuUserControl us = new MenuUserControl();
        private ObservableCollection<string> games = new ObservableCollection<string>();
        private Dictionary<string, int> gamesRows = new Dictionary<string, int>();
        private Dictionary<string, int> gamesCols = new Dictionary<string, int>();
        private MultiPlayerMaze win;

        public MultiPlayerMenu()
        {
            InitializeComponent();
            vm = new MultiPlayerViewModel();

            DataContext = vm;
        }

        private void MenuUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MultiPlayerMazeViewModel a = new MultiPlayerMazeViewModel();
            string lst = a.List();
            ListOfGames.Items.Add(lst);

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            games.Add(vm.MazeName);
            gamesRows.Add(vm.MazeName, vm.MazeRows);
            gamesCols.Add(vm.MazeName, vm.MazeCols);
            ListOfGames.Items.Add(vm.MazeName);
            //ListOfGames.ItemsSource = games;

            new Thread(syncProcess).Start();
            //win = new MultiPlayerMaze(vm.MazeRows, vm.MazeCols, vm.MazeName, 0);
        }
        private void syncProcess()
        {
            Dispatcher.Invoke(() => { win = new MultiPlayerMaze(vm.MazeRows, vm.MazeCols, vm.MazeName, 0); });
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            string name = games[ListOfGames.TabIndex];
            int rows = gamesRows[name];
            int cols = gamesCols[name];
            win = new MultiPlayerMaze(rows, cols, name);
            win.ShowDialog();
        }

        private void ListOfGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
