using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopolia;
using Monopolia.Field.Chance;
using Xunit;

namespace TestMonopolya
{
    public class TestFieldChance
    {

        [Fact]
        public void TestPullingChance()
        {
            //Arrange
            Player playerStart = new Player("Аркадий", 1500, 7, false, false, new List<FieldStreet>(), 0);
            var expected = playerStart;
            //Act
            GeneratorField GF = new GeneratorField();
            List<FieldMonopoly> field = new List<FieldMonopoly>();
            field = GF.Generator_Field();
            Player playerFinish = new Player("Аркадий", 1500, 7, false, false, new List<FieldStreet>(), 0);
            field[7].EffectAfterMove(playerFinish);
            var actual = playerFinish;
            //Assert
            Assert.NotEqual(playerStart, playerFinish);
        }
    }
}
