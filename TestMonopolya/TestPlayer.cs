using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopolia;
using Xunit;

namespace TestMonopolya
{
    public class TestPlayer
    {
        List<string> players = new List<string>() { "apple", "banana" };


        [Fact]
        public void TestChangeMoney()
        {
            //Arrange
            var expected = 1600;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.players[0].ChangeMoney(100);
            var actual = GP.players[0].Money;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ChangeShiftField()
        {
            //Arrange
            var expected = 3;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.players[0].ChangeShiftField(3);
            var actual = GP.players[0].Field;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBuyStreet()
        {
            //Arrange
            var expected = 1;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.players[0].ChangeField(1);
            FieldStreet FieldStreet = (FieldStreet)GP.field[1];
            GP.players[0].BuyStreet(FieldStreet);
            var actual = GP.players[0].Realta.Count;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestChange()
        {
            //Arrange
            var expected = "Главное шоссе";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.players[0].ChangeField(1);
            FieldStreet FieldStreet = (FieldStreet)GP.field[1];
            GP.players[1].ChangeField(3);
            FieldStreet FieldStreet1 = (FieldStreet)GP.field[3];
            GP.players[0].BuyStreet(FieldStreet);
            GP.players[1].BuyStreet(FieldStreet1);
            GP.players[0].Change(FieldStreet1,FieldStreet);
            var actual = GP.players[0].Realta[0].name;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestCheackChange()
        {
            //Arrange
            var expected = true;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.players[0].ChangeField(1);
            FieldStreet FieldStreet = (FieldStreet)GP.field[1];
            GP.players[1].ChangeField(3);
            FieldStreet FieldStreet1 = (FieldStreet)GP.field[3];
            GP.players[0].BuyStreet(FieldStreet);
            GP.players[1].BuyStreet(FieldStreet1);
            var actual = GP.players[0].CheackChange(FieldStreet, FieldStreet1);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestCheckingSets()
        {
            //Arrange
            var expected = 1;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            var actual = (GP.players[0].CheckingSets()).Count;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
