using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopolia;
using Xunit;

namespace TestMonopolya
{
    public class TestRollDice
    {
        [Fact]
        public void TestChoiceOfTax()
        {
            //Arrange
            var expected = true;
            //Act
            RollDice RD = new RollDice();
            int[] roll = RD.DiceRoll();
            var actual = false;
            if (((roll[0]>0)&& (roll[0] < 7))&& ((roll[1] > 0) && (roll[1] < 7)))
            {
                actual = true;
            }
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
