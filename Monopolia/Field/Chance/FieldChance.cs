using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Chance
{
    public class FieldChance : FieldMonopoly
    {
        private IChance Chance { get; set; }

        public FieldChance(string name,IChance Chance) : base(name)
        {
            this.Chance = Chance;
        }
        /// <summary>
        /// Случайнаая карточка шанса
        /// </summary>
        /// <param name="player"></param>
        private void PullingCard(Player player)
        {
            Random rnd = new Random();
            int choice = rnd.Next(0, 15);
            if (choice > 0 && choice < 5) { Chance = new MoneyChance(); }
            if (choice > 4 && choice < 9) { Chance = new ShiftChance(); }
            if (choice > 8 && choice < 11) { Chance = new GoToPrisonChance(); }
            Chance.Card(player);
        }
        public override void EffectAfterMove(Player player)
        {
            PullingCard(player);
        }
    }
}
