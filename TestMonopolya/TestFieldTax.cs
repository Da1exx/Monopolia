using Monopolia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestMonopolya
{
    public class TestFieldTax
    {
        [Fact]
        public void TestChoiceOfTax()
        {
            //Arrange
            var expected1 = 1300;
            var expected2 = 1400;
            //Act
            GeneratorField GF = new GeneratorField();
            List<FieldMonopoly> field = new List<FieldMonopoly>();
            field = GF.Generator_Field();
            Player player = new Player("Аркадий", 1500, 4, false, false, new List<FieldStreet>(), 0);
            field[4].EffectAfterMove(player);
            var actual1 = player.Money;
            Player player2 = new Player("Аркадий", 1500, 38, false, false, new List<FieldStreet>(), 0);
            field[38].EffectAfterMove(player2);
            var actual2 = player2.Money;
            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }
    }
}
