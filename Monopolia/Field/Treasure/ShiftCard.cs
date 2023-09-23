using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Treasure
{
    public class ShiftCard : Card
    {
        
        /// <summary>
        /// Карточка связанная со сдвигам на карте
        /// </summary>
        /// <param name="player"></param>
        public override void PerformAction(Player player)
        {
            Random rnd = new Random();
            int shift = rnd.Next(-2, 3);
            int nextField = player.Field + shift;
            player.ChangeShiftField(nextField);
        }
    }
}
