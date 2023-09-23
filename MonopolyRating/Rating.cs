using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRating
{
    public class Rating
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int PlayerMoney { get; set; }
        public int Tern { get; set; }
        public Rating( string playerName, int playerMoney, int tern)
        {
            PlayerName = playerName;
            PlayerMoney = playerMoney;
            Tern = tern;
        }     
    }
}
