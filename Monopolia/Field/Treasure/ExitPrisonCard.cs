using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Treasure
{
    public  class ExitPrisonCard :Card
    {

        /// <summary>
        /// Карточка связанная с получением выхода из тюрьмы
        /// </summary>
        /// <param name="player"></param>
        public override void PerformAction(Player player)
        {
            player.ChangeExitPrisonStatus( true);
        }
    }
}
