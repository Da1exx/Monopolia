using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Treasure
{
    public class MoneyCard:Card
    {
       
        /// <summary>
        /// Картачка получением или потерю денег
        /// </summary>
        /// <param name="player"></param>
        public override void PerformAction(Player player)
        {
            Random rnd = new Random();
            int money = rnd.Next(-100, 100);
            player.ChangeMoney(money);
        }
    }
}
