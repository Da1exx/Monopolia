using Monopolia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestMonopolya
{
    public class TestFieldStart
    {
        [Fact]
        public void TestGotoPrisonHaveExitPrison()
        {
            //Arrange
            var expected = 1700;
            //Act
            GeneratorField GF = new GeneratorField();
            List<FieldMonopoly> field = new List<FieldMonopoly>();
            field = GF.Generator_Field();
            Player player = new Player("Аркадий", 1500, 0, false, false, new List<FieldStreet>(), 0);
            field[0].EffectShiftMove(player);
            var actual = player.Money;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
