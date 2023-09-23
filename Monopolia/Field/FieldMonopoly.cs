using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public abstract class FieldMonopoly
    {
        /// <summary>
        /// имя клетки
        /// </summary>
        public string name { get; }

        public FieldMonopoly(string name)
        { 
            this.name = name;
        }

        public virtual void EffectAfterMove(Player player)
        {
           
        }
        public virtual int[] EffectBeforeMove(Player player)
        {
            int[] roll = new int[] { 1, 1 };
            return roll;
        }
        public virtual void EffectShiftMove(Player player)
        {

        }
    }
}
