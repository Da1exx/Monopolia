using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Chance
{
    class ShiftChance : IChance
    {
        
        /// <summary>
        /// Карточка связанная со сдвигом на поле
        /// </summary>
        /// <param name="player"></param>
        public void Card(Player player)
        {
            Random rnd = new Random();
            int shift =rnd.Next(-2, 3);
            int nextField = player.Field + shift;
            player.ChangeShiftField(nextField);
        } 
    }
}
