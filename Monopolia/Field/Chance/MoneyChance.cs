using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Chance
{
    class MoneyChance : IChance
    {
        
        /// <summary>
        /// Карточка связання с получением или отбиранием денег
        /// </summary>
        /// <param name="player"></param>
        public void Card(Player player)
        {
            Random rnd = new Random();
            int money = rnd.Next(-100, 100);
            player.ChangeMoney(money);
        }
    }
}
