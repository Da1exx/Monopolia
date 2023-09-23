using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public class FieldStart : FieldMonopoly
    {
        private int LoopMoney{get;}
        public FieldStart(string name,int LoopMoney) : base(name)
        {
            this.LoopMoney = LoopMoney;
        }
        private void PassToStart(Player player)
        {
            player.ChangeMoney(LoopMoney);
        }
        public override void EffectShiftMove(Player player)
        {
            PassToStart(player);
        }
    }
}
