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
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        GamePlay GP = new GamePlay();
        public Game(List<string> playersName)
        {
            InitializeComponent();
            GP.CreateGameAndPlayer(playersName);
            NameField(GP.field);
        }
        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            int[] roll = GP.Game();
            if (roll == null)
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.EndGame(GP.players[0], GP.KolTern);
            }
            else
            {
                Roll1.Text = roll[0].ToString();
                Roll2.Text = roll[1].ToString();
                Tern.Content = new ActivePlayerPage(GP.players[GP.numplayers], GP.players, GP);
            }
        }
        
        private void NameField(List<FieldMonopoly> FM)
        {
            Brown1.Text = FM[1].name;
            Tresure1.Text = FM[2].name;
            Brown2.Text = FM[3].name;
            Tax1.Text = FM[4].name;
            RGD1.Text = FM[5].name;
            BLY1.Text = FM[6].name;
            Chance1.Text = FM[7].name;
            Bly2.Text = FM[8].name;
            Bly3.Text = FM[9].name;
            PINK1.Text = FM[11].name;
            GKX1.Text = FM[12].name;
            PINK2.Text = FM[13].name;
            PINK3.Text = FM[14].name;
            RGD2.Text = FM[15].name;
            ORANGE1.Text = FM[16].name;
            Tresure2.Text = FM[17].name;
            Orange2.Text = FM[18].name;
            Orange3.Text = FM[19].name;
            RED1.Text = FM[21].name;
            Chance2.Text = FM[22].name;
            RED2.Text = FM[23].name;
            Red3.Text = FM[24].name;
            RGD3.Text = FM[25].name;
            Yellow1.Text = FM[26].name;
            Yellow2.Text = FM[27].name;
            GKX2.Text = FM[28].name;
            Yellow3.Text = FM[29].name;
            Green1.Text = FM[31].name;
            Green2.Text = FM[32].name;
            Tresure3.Text = FM[33].name;
            Green3.Text = FM[34].name;
            RGD4.Text = FM[35].name;
            Chance3.Text = FM[36].name;
            Black1.Text = FM[37].name;
            Tax2.Text = FM[38].name;
            Black2.Text = FM[39].name;
        }
    }
}
