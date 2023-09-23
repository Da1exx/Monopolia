using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public class FieldStreet : FieldMonopoly
    {
        /// <summary>
        /// Принадлежность к определеному группе недвижимости(триплеты одинаковоцветных карточек)
        /// </summary>
        public string family { get; } 

        /// <summary>
        /// цена покупки улицы
        /// </summary>
        public int price { get; }

        /// <summary>
        /// колличество домиков которые увеличивают стоимость улицы
        /// (изначально 0, группа полей 1, дальше за каждый домик +1, до 6)
        /// </summary>
        public int level { get;  private set; }

        /// <summary>
        /// цена за домик 
        /// </summary>
        public int priceLevel { get; }

        /// <summary>
        /// Цена которую ты заплатишь вступив на эту клетку, если она во владениях другово игрока
        /// </summary>
        public int Profit { get; private set; }

        /// <summary>
        /// Имя какому игроку пренадлежит данная улица
        /// </summary>
        public Player owner { get; private set; }

        public FieldStreet(string name,string family, int price, int level, int priceLevel, int profit, Player owner) : base(name)
        {
           
            this.family = family;
            this.price = price;
            this.level = level;
            this.priceLevel = priceLevel;
            this.Profit = profit;
            this.owner = owner;
        }
        /// <summary>
        /// Смена аренды ха пребывание другого игрока
        /// </summary>
        /// <param name="profit"></param>
        public void ChangeProfit(int profit)
        {
            Profit = profit;
        }

        /// <summary>
        ///Смена владельца клетки
        /// </summary>
        /// <param name="owner"></param>
        public void ChangeOwner(Player owner)
        {
            this.owner = owner;
        }
        /// <summary>
        /// Строит отели у каждой стороны поля своя цена.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="FS"></param>
        public void BuyHouse(Player player)
        {
            player.ChangeMoney(-priceLevel);
            level++;
            Profit = Profit * 2;
        }

        /// <summary>
        /// Продает отель за полцены
        /// </summary>
        /// <param name="player"></param>
        /// <param name="FS"></param>
        public void SellHouse(Player player)
        {
            player.ChangeMoney(priceLevel / 2);
            level--;
            Profit = Profit / 2;
        }

        /// <summary>
        /// Проверка на то что пренадлежит ли улица комунибудь
        /// </summary>
        /// <returns></returns>
        public bool PossibleToBuyStreet()
        {
            if (owner == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Плата другому игроку
        /// </summary>
        /// <param name="player"></param>
        public override void EffectAfterMove(Player player)
        {
            RentalField(player);
        }

        private void RentalField(Player player)
        {
            if((owner!= null)&&(owner!= player))
            {
                owner.ChangeMoney(Profit);
                player.ChangeMoney(-Profit);
            }
        }

        /// <summary>
        /// Проверка чтобы уровень дома не превышал 5
        /// </summary>
        /// <param name="player"></param>
        /// <param name="FS"></param>
        public bool DtBuyHouse()
        {
            if (level >= 5)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// проверка чтобы уровень не понизился до -1
        /// </summary>
        /// <param name="player"></param>
        /// <param name="FS"></param>
        /// <returns></returns>
        public bool DtCellHouse()
        {
            if (level <= 0)
            {
                return false;
            }
            return true;
        }
    }
}

