using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public class FieldPrison : FieldMonopoly
    {
        
        private int Ransom { get; }

        public FieldPrison(string name, int Ransom) : base(name)
        {
            this.Ransom = Ransom;
        }
        private int[] ExitPrison(Player player)
        {
            RollDice RD = new RollDice();
            int[] roll = RD.DiceRoll();
            if (roll[0] == roll[1])
            {
                player.ChangePrisonStatus(false);
                player.ChangeSkipTurn(-player.SkipTurn);
            }else if ((player.SkipTurn == 0) && (player.PrisonStatus == true))
            {
                player.ChangeMoney(-Ransom);
                player.ChangePrisonStatus(false);
            }
            return roll;
        }
        public override int[] EffectBeforeMove(Player player)
        {
            int[] roll = ExitPrison(player);
            return roll;
        }
    }
}
