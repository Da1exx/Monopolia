using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Chance
{
    class ExitPrisonChance : IChance
    {
        /// <summary>
        /// Карточка шанса получения выхода из тюрьмы
        /// </summary>
        /// <param name="player"></param>
        public void Card(Player player)
        {
            player.ChangeExitPrisonStatus( true);
        }
    }
}
