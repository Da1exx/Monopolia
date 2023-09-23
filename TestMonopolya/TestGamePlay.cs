using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopolia;
using Xunit;

namespace TestMonopolya
{
    public class TestGamePlay
    {
        List<string> players = new List<string>() { "apple", "banana" };
        [Fact]
        public void GoBuyStreetTest()
        {
            //Arrange
            var expected = "Здание куплено";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            var actual = GP.GoBuyStreet();
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GoBuyStreetBusyTest()
        {
            //Arrange
            var expected = "Здание уже куплено";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[1].ChangeField(1);
            var actual = GP.GoBuyStreet();
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GoBuyNoStreetTest()
        {
            //Arrange
            var expected = "Элемент не является улицей";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(2);
            var actual = GP.GoBuyStreet();
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GoBuyHouseCompliteTest()
        {
            //Arrange
            var expected = "Дом построен";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            var actual = GP.GoBuyHouse(GP.players[0].Realta[0]);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GoBuyHouseNoCetTest()
        {
            //Arrange
            var expected = "нету сета карт";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            var actual = GP.GoBuyHouse(GP.players[0].Realta[0]);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GoBuyHouseNoBuildUpFiveTest()
        {
            //Arrange
            var expected = "Выше строить нельзя";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            for (int i = 0; i < 5; i++)
            {
                GP.GoBuyHouse(GP.players[0].Realta[0]);
            }
            var actual = GP.GoBuyHouse(GP.players[0].Realta[0]);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GOSellHouseCompliteTest()
        {
            //Arrange
            var expected = "Дом продан";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            GP.GoBuyHouse(GP.players[0].Realta[0]);
            var actual = GP.GOSellHouse(GP.players[0].Realta[0]);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GOSellHouseNoCellDownZeroTest()
        {
            //Arrange
            var expected = "Продавать нечего";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            var actual = GP.GOSellHouse(GP.players[0].Realta[0]);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]

        public void GoChangeCompliteTest()
        {
            //Arrange
            var expected = "Обмен совершен";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.Game();
            GP.players[1].ChangeField(3);
            GP.GoBuyStreet();
            var actual = GP.GoChange(GP.players[1].Realta[0], GP.players[0].Realta[0]);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GoChangeImposibleTest()
        {
            //Arrange
            var expected = "Обмен совершить не возможно";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.players[0].ChangeField(3);
            GP.GoBuyStreet();
            GP.GoBuyHouse(GP.players[0].Realta[0]);
            GP.Game();
            GP.players[1].ChangeField(5);
            GP.GoBuyStreet();
            var actual = GP.GoChange(GP.players[1].Realta[0], GP.players[0].Realta[0]);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GoChangeNotChoiceTest()
        {
            //Arrange
            var expected = "Выберете что и с кем хотите поменяться";
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.Game();
            GP.players[0].ChangeField(1);
            GP.GoBuyStreet();
            GP.Game();
            GP.players[1].ChangeField(3);
            GP.GoBuyStreet();
            var actual = GP.GoChange(GP.players[1].Realta[0],null);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateGameAndPlayerTest()
        {
            //Arrange
            var expected1 = 2;
            var expected2 = 40;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            var actual1 = GP.players.Count;
            var actual2 = GP.field.Count;
            //Assert
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }
        [Fact]
        public void GameTest()
        {
            //Arrange
            var expected1 = 39;
            //Act
            GamePlay GP = new GamePlay();
            GP.CreateGameAndPlayer(players);
            GP.players[0].ChangeField(39);
            GP.Game();
            var actual1 = GP.players[0].Field;
            //Assert
            Assert.NotEqual(expected1, actual1);

        }
    }
}
