using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Chance
{
    class GoToPrisonChance : IChance
    {
        /// <summary>
        /// Карточка шанса с отправлением в тюрьму
        /// </summary>
        /// <param name="player"></param>
        public void Card(Player player)
        {
            player.ChangePrisonStatus( true);
            player.ChangeField(10);
            player.ChangeSkipTurn(3);
        }
    }
}
