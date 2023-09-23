using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public class FieldGotoPrison : FieldMonopoly
    {
        private int GoToField {get;}
        public FieldGotoPrison(string name, int GoToField) : base(name)
        {
            this.GoToField = GoToField;
        }
        private void GotoPrison(Player player)
        {
            if (player.ExitPrison != true)
            {
                player.ChangePrisonStatus(true);
                player.ChangeField(GoToField);
                player.ChangeSkipTurn(3);
            }
            else { player.ChangeExitPrisonStatus( false); }
        }
        public override void EffectAfterMove(Player player)
        {
            GotoPrison(player);
        }
    }
}
