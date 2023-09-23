using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Treasure
{
    public class GoToPrisonCard :Card
    {
        /// <summary>
        /// Карточка связанная с посадкой в тюрьму
        /// </summary>
        /// <param name="player"></param>
        public override void PerformAction(Player player)
        {
            player.ChangePrisonStatus(true);
            player.ChangeField(10);
            player.ChangeSkipTurn(3);
        }

    }
}
