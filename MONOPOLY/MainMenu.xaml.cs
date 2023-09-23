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

namespace MONOPOLY
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            List<string> players = new List<string>();
            PlayersVoid(players);
            string sdf = KolPlayers.Text;
            int kolpl = int.Parse(sdf);
            for (int i = 4; i >kolpl; i--)
            {
                players.RemoveAt(i - 1);
            }
            mainWindow.StartGame(players);

        }
        public List<string> PlayersVoid(List<string> players)
        {
            if (pl1.Text == "")
            {
                pl1.Text = "player1";
            }
            if (pl2.Text == "")
            {
                pl2.Text = "player2";
            }
            if (pl3.Text == "")
            {
                pl3.Text = "player3";
            }
            if (pl4.Text == "")
            {
                pl4.Text = "player4";
            }
            players.Add(pl1.Text);
            players.Add(pl2.Text);
            players.Add(pl3.Text);
            players.Add(pl4.Text);
            return players;
        }
    }
}
