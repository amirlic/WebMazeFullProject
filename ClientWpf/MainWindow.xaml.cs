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
using ClientWpf.View;

namespace ClientWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MultiPlayerMenu mpm = new MultiPlayerMenu();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Single_OnClick(object sender, RoutedEventArgs e)
        {
            SinglePlayerMenu single_menu = new SinglePlayerMenu();
            single_menu.ShowDialog();
        }

        private void Multi_OnClick(object sender, RoutedEventArgs e)
        {
            //MultiPlayerMenu multi_menu = new MultiPlayerMenu();
            //multi_menu.ShowDialog();
            MainWindow.mpm.ShowDialog();
        }

        private void Setting_OnClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow setting_menu = new SettingsWindow();
            setting_menu.ShowDialog();
        }
    }
}