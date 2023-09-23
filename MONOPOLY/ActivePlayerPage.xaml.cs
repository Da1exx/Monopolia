using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Monopolia;

namespace MONOPOLY
{
    /// <summary>
    /// Логика взаимодействия для ActivePlayerPage.xaml
    /// </summary>
    public partial class ActivePlayerPage : Page
    {
        public Player player { get; }
        public FieldStreet FS { get; }
        public List<Player> players { get; }
        private  GamePlay GP { get; }


        public ActivePlayerPage(Player player, List<Player> players, GamePlay GP)
        {
            InitializeComponent();
            this.players = players;
            this.player = player;
            this.GP = GP;
            DataContext = this;
            SetingButtonAndText();
        }

        /// <summary>
        /// Кнопка Купить дом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyHouse_Click(object sender, RoutedEventArgs e)
        {
            TileList.ItemsSource = new ObservableCollection<FieldStreet>(player.Realta);
            FieldStreet selectedStreet = TileList.SelectedItem as FieldStreet;
            string text = GP.GoBuyHouse(selectedStreet);
            TileList.ItemsSource = player.Realta;
            Balance.Text = player.Money.ToString();
            Act.Text = text;
            SellHouce.IsEnabled = true;
        }

        /// <summary>
        /// Кнопка Продать дом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellHouce_Click(object sender, RoutedEventArgs e)
        {
            TileList.ItemsSource = new ObservableCollection<FieldStreet>(player.Realta);
            FieldStreet selectedStreet = TileList.SelectedItem as FieldStreet;
            string text = GP.GOSellHouse(selectedStreet);
            TileList.ItemsSource = player.Realta;
            Balance.Text = player.Money.ToString();
            Act.Text = text;
        }

        /// <summary>
        /// Кнопка Купить улицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TileList.ItemsSource = new ObservableCollection<FieldStreet>(player.Realta);
            string text = GP.GoBuyStreet();
            TileList.ItemsSource = player.Realta;
            Balance.Text = player.Money.ToString();
            Act.Text = text;
            BuyStreet.IsEnabled = false;
            if (player.CheckingSets().Count > 0)
            {
                BuyHouse.IsEnabled = true;
            }
        }

        /// <summary>
        /// Кнопка обмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chance_Click(object sender, RoutedEventArgs e)
        {
            TabItem activeTabItem = Players.SelectedItem as TabItem;
            FieldStreet selectedStreet = TileList.SelectedItem as FieldStreet;
            if (activeTabItem != null)
            {
                FieldStreet selectedStreet1= StreetPlayerModelFind(activeTabItem);
                string text=GP.GoChange(selectedStreet1, selectedStreet);
                TileList.ItemsSource = new ObservableCollection<FieldStreet>(player.Realta);
                TileList.ItemsSource = player.Realta;
                FillingTable();
                Act.Text = text;
            }
        }

        /// <summary>
        /// Поиск таблицы игроков
        /// </summary>
        private void FillingTable()
        {
            if (players.Count >= 1)
            {
                TileListPl1.ItemsSource = new ObservableCollection<FieldStreet>(players[0].Realta);
                TileListPl1.ItemsSource = players[0].Realta;
            }
            if (players.Count >= 2)
            {
                TileListPl2.ItemsSource = new ObservableCollection<FieldStreet>(players[1].Realta);
                TileListPl2.ItemsSource = players[1].Realta;
            }
            if (players.Count >= 3)
            {
                TileListPL3.ItemsSource = new ObservableCollection<FieldStreet>(players[2].Realta);
                TileListPL3.ItemsSource = players[2].Realta;
            }
            if (players.Count >= 4)
            {
                TileListPL4.ItemsSource = new ObservableCollection<FieldStreet>(players[3].Realta);
                TileListPL4.ItemsSource = players[3].Realta;
            }
        }

        /// <summary>
        /// Изначальное включение кнопок
        /// </summary>
        private void SetingButtonAndText()
        {
            NamePlayer.Text = player.Name;
            Balance.Text = player.Money.ToString();

            for (int i = 4; i > players.Count; i--)
            {
                Players.Items.RemoveAt(i - 1);
            }
            for (int i = 0; i < players.Count; i++)
            {
                TabItem tabItem = Players.Items[i] as TabItem;
                if (tabItem != null)
                {
                    tabItem.Header = players[i].Name;
                }
            }
        }

        /// <summary>
        /// Заполнение таблицы игроков
        /// </summary>
        private FieldStreet StreetPlayerModelFind(TabItem activeTabItem)
        {
            FieldStreet selectedStreetChange = null;
            if (activeTabItem.Header.ToString() == players[0].Name)
            {
                selectedStreetChange = TileListPl1.SelectedItem as FieldStreet;
            }
            else if (activeTabItem.Header.ToString() == players[1].Name)
            {
                selectedStreetChange = TileListPl2.SelectedItem as FieldStreet;
            }
            else if (activeTabItem.Header.ToString() == players[2].Name)
            {
                selectedStreetChange = TileListPL3.SelectedItem as FieldStreet;
            }
            else if (activeTabItem.Header.ToString() == players[3].Name)
            {
                selectedStreetChange = TileListPL4.SelectedItem as FieldStreet;
            }
            return selectedStreetChange;
        }
    }
}
