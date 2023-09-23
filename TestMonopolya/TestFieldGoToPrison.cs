using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopolia;
using Xunit;

namespace TestMonopolya
{
    public class TestGoToPrison
    {
        [Fact]
        public void TestGotoPrisonDtExitPrison()
        {
            //Arrange
            var expected = true;
            //Act
            GeneratorField GF = new GeneratorField();
            List<FieldMonopoly> field = new List<FieldMonopoly>();
            field = GF.Generator_Field();
            Player player = new Player("Аркадий", 1500, 30, false, false, new List<FieldStreet>(), 0);
            field[30].EffectAfterMove(player);
            var actual = player.PrisonStatus;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGotoPrisonHaveExitPrison()
        {
            //Arrange
            var expected = false;
            //Act
            GeneratorField GF = new GeneratorField();
            List<FieldMonopoly> field = new List<FieldMonopoly>();
            field = GF.Generator_Field();
            Player player = new Player("Аркадий", 1500, 30, false, false, new List<FieldStreet>(), 0);
            player.ChangeExitPrisonStatus( true);
            field[30].EffectAfterMove(player);
            var actual = player.PrisonStatus;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
