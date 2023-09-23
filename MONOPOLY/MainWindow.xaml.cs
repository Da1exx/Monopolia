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
using Monopolia;

namespace MONOPOLY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowContent.Content = new MainMenu();
        }
        public void StartGame(List<string> players)
        {
            MainWindowContent.Content = new Game(players);
        }
        public void EndGame(Player player,int tern)
        {
            MainWindowContent.Content = new Rating(player ,tern);
        }
    }
}
