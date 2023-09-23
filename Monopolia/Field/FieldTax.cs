using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public class FieldTax : FieldMonopoly
    {
        /// <summary>
        /// Показывает сумму выплат
        /// </summary>
        private int Tax { get; }
        public FieldTax(string name, int Tax) : base(name)
        {
            this.Tax = Tax;
        }      
        /// <summary>
        /// Списываает налог на соотетсующих клетках
        /// </summary>
        /// <param name="player"></param>
        private void ChoiceOfTax(Player player)
        {
            player.ChangeMoney(-Tax);
        }

        public override void EffectAfterMove(Player player)
        {
            ChoiceOfTax(player);
        }
    }
}
