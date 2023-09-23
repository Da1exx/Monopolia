using Monopolia;
using System;
using Xunit;
using System.Collections.Generic;

namespace TestMonopolya
{
    public class TestFieldStreet
    {
        List<string> players = new List<string>() { "apple", "banana" };

        [Fact]
        public void TestBuyHouse()
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
            FieldStreet FieldStreet = (FieldStreet)GP.field[1];
            FieldStreet.BuyHouse(GP.players[0]);
            var actual = GP.players[0].Realta[0].level;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestCellHouse()
        {
            //Arrange
            var expected = 0;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            FieldStreet FieldStreet = (FieldStreet)GP.field[1];
            FieldStreet.BuyHouse(GP.players[0]);
            FieldStreet.SellHouse(GP.players[0]);
            var actual = GP.players[0].Realta[1].level;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestDtBuyHouse()
        {
            //Arrange
            var expected = true;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            FieldStreet FieldStreet = (FieldStreet)GP.field[1];
            FieldStreet.DtBuyHouse();
            var actual = FieldStreet.DtBuyHouse(); 
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestDtCellHouse()
        {
            //Arrange
            var expected = true;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            FieldStreet FieldStreet = (FieldStreet)GP.field[1];
            var actual = FieldStreet.DtBuyHouse();
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestPaymentAnothePlayer()
        {
            //Arrange
            var expected = 1500;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(1);
            FieldStreet FieldStreet = (FieldStreet)GP.field[1];
            FieldStreet.EffectAfterMove(GP.players[1]);
            var actual = GP.players[0].Money;
            //Assert
            Assert.NotEqual(expected, actual);
        }
    }
}
