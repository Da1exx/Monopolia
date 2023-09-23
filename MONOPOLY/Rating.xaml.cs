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
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : Page
    {
        public Task<int[]> task1;
        public List<MonopolyRating.Rating> Ratings { get; set;}
        Player player;
        MonopolyRating.DataBaseManager DBM = new MonopolyRating.DataBaseManager();

        public Rating(Player player, int tern)
        {
            InitializeComponent();
            Ratings = new List<MonopolyRating.Rating>();
            this.player = player;
            WinPlayer.Text = player.Name;
            Money.Text = player.Money.ToString();
            Tern.Text = tern.ToString();
        }

        public async Task Acinxron()
        {
            var loadedRatings = await DBM.LoadRatingsAsync();
            TileList.ItemsSource = loadedRatings;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SeeRating.IsEnabled = false;
            await DBM.SaveRatingAsync(player, Convert.ToInt32(Tern.Text));
            await Acinxron();
        }

    }
}

