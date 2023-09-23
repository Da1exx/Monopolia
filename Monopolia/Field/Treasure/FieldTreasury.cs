using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia.Field.Treasure
{
    public class FieldTreasury : FieldMonopoly
    {
        public FieldTreasury(string name) : base(name)
        { 
        
        }
    
        /// <summary>
        /// Берем случайную карточку
        /// </summary>
        /// <param name="player"></param>
        private void ChoiceCard(Player player)
        {
            Card card = new ExitPrisonCard();
            Random rnd = new Random();
            int choice = rnd.Next(0, 15);
            if (choice > 0 && choice < 5) { card = new MoneyCard(); }
            if (choice > 4 && choice < 9) { card = new ShiftCard(); }
            if (choice > 8 && choice < 11) { card = new GoToPrisonCard(); }
            card.PerformAction(player);
        }

        public override void EffectAfterMove(Player player)
        {
            ChoiceCard( player);
        }
    }
}
