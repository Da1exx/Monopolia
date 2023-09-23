using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public class RollDice
    {
        public int[] DiceRoll()
        {
            Random rnd = new Random();
            int[] roll = new int[] { 1, 1 };
            roll[0] = rnd.Next(1, 7);
            roll[1] = rnd.Next(1, 7);
            return roll;
        }
    }
}
