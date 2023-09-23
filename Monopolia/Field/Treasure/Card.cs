using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Treasure
{
    public abstract class Card
    {
        public abstract void PerformAction(Player player);
    }
}
