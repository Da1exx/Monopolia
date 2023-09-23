using Monopolia;
using Monopolia.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestMonopolya
{
    public class TestFieldPrison
    {
        [Fact]
        public void TestPrisonRansom()
        {
            //Arrange
            var expected = false;
            //Act
            GeneratorField GF = new GeneratorField();
            List<FieldMonopoly> field = new List<FieldMonopoly>();
            field = GF.Generator_Field();
            Player player = new Player("Аркадий", 1500,30 , false, false, new List<FieldStreet>(), 0);
            for (int i = 0; i < 3; i++)
            {
                if (player.PrisonStatus == true)
                {
                    field[30].EffectBeforeMove(player);
                }
            }
            var actual = player.PrisonStatus;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
