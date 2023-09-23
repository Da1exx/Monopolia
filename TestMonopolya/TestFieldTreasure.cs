using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopolia.Field.Treasure;
using Monopolia;
using Xunit;

namespace TestMonopolya
{
    public class TestFieldTreasure
    {
        [Fact]
        public void TestPullingTreasury()
        {
            //Arrange
            Player playerStart = new Player("Аркадий", 1500, 2, false, false, new List<FieldStreet>(), 0);
            var expected = playerStart;
            //Act
            GeneratorField GF = new GeneratorField();
            List<FieldMonopoly> field = new List<FieldMonopoly>();
            field = GF.Generator_Field();
            Player playerFinish = new Player("Аркадий", 1500, 2, false, false, new List<FieldStreet>(), 0);
            field[2].EffectAfterMove(playerFinish);
            var actual = playerFinish;
            //Assert
            Assert.NotEqual(playerStart, playerFinish);
        }
    }
}
