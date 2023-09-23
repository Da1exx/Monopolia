using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public class Player
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Количество денег
        /// </summary>
        public int Money { get; private set; }

        /// <summary>
        /// Поле на котором мы стоим
        /// </summary>
        public int Field { get; private set; }

        /// <summary>
        /// Сидим ли мы в тюрьме или нет false-NO, true-Yes
        /// </summary>
        public bool PrisonStatus { get; private set; }

        /// <summary>
        /// Есть ли карта выход из тюрьмы false-NO, true-Yes
        /// </summary>
        public bool ExitPrison { get; private set; }

        /// <summary>
        /// Количество недвижимости
        /// </summary>
        public List<FieldStreet> Realta { get; private set; }

        /// <summary>
        /// Сколько ходов пропустит игрок
        /// </summary>
        public int SkipTurn { get; private set; }
        public Player(string Name, int Money,int Field,bool PrisonStatus,bool ExitPrison,
            List<FieldStreet> Realta,int SkipTurn)
        {
            this.Name = Name;
            this.Money = Money;
            this.Field = Field;
            this.PrisonStatus = PrisonStatus;
            this.ExitPrison = ExitPrison;
            this.Realta = Realta;
            this.SkipTurn = SkipTurn;
        }

        /// <summary>
        /// Cмена денег у игрока
        /// </summary>
        /// <param name="money"></param>
        public void ChangeMoney(int money)
        {
            Money += money;
        }

        /// <summary>
        /// Смена поля у игрока
        /// </summary>
        /// <param name="money"></param>
        public void ChangeField(int field)
        {
            Field = field;            
        }

        /// <summary>
        /// Смена поля у игрока
        /// </summary>
        /// <param name="money"></param>
        public void ChangeShiftField(int field)
        {
            Field += field % 39;
            if (Field > 39)
            {
                Field -= 39;
            }
        }
        /// <summary>
        /// Смена тюремного статуса
        /// </summary>
        /// <param name="status"></param>
        public void ChangePrisonStatus(bool status)
        {
            PrisonStatus = status;
        }

        /// <summary>
        /// Смена выхода из тюрьмы статуса
        /// </summary>
        /// <param name="status"></param>
        public void ChangeExitPrisonStatus(bool status)
        {
            ExitPrison = status;
        }

        /// <summary>
        /// Смена пропуска хода
        /// </summary>
        /// <param name="tern"></param>
        public void ChangeSkipTurn(int tern)
        {
            SkipTurn+=tern;
        }

        /// <summary>
        /// Метод который позволяет игроку купить недвижимость
        /// </summary>
        /// <param name="player"></param>
        /// <param name="FS"></param>
        public void BuyStreet(FieldStreet FS)
        {
            FS.ChangeOwner(this);
            Realta.Add(FS);
            ChangeMoney(-FS.price);
            doublingFamily(FS);
        }

        /// <summary>
        /// Обмен улиц
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="FS2"></param>
        public void Change(FieldStreet FS,FieldStreet FS2)
        {
            Player pl3 =FS.owner;
            FS.ChangeOwner(FS2.owner);
            FS2.ChangeOwner(pl3);
            Realta.Remove(FS2);
            FS2.owner.Realta.Remove(FS);
            Realta.Add(FS);
            FS2.owner.Realta.Add(FS2);
        }  

        /// <summary>
        /// Проверка можно ли поменяться улицами или нет
        /// </summary>
        /// <param name="FS1"></param>
        /// <param name="FS2"></param>
        /// <returns></returns>
        public bool CheackChange(FieldStreet FS1, FieldStreet FS2)
        {
            if ((FS1.owner != FS2.owner) && (FS1.level == 0) && (FS2.level == 0))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверка на то есть ли у игрока триплет определенных улиц
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public List<string> CheckingSets()
        {
            Dictionary<string, int> streetCount = new Dictionary<string, int>();

            foreach (FieldStreet street in Realta)
            {
                if (streetCount.ContainsKey(street.family))
                {
                    streetCount[street.family]++;
                }
                else
                {
                    streetCount[street.family] = 1;
                }
            }
            List<string> familyField = new List<string>();
            foreach (KeyValuePair<string, int> kvp in streetCount)
            {
                if ((kvp.Value == 2 && (kvp.Key == "Brown" || kvp.Key == "Black")) || kvp.Value == 3)
                {
                    familyField.Add(kvp.Key);
                }
            }
            return familyField;
        }

        /// <summary>
        /// Если у тебя есть 3/2 карты определенного типа удваивает стоимость всех 3/2 карт
        /// </summary>
        /// <param name="player"></param>
        /// <param name="FS"></param>
        private void doublingFamily(FieldStreet FS)
        {
            List<string> color = new List<string>();
            color = CheckingSets();
            if (color.Contains(FS.family) == true)
            {
                string fam = FS.family;
                for (int i = 0; i < Realta.Count; i++)
                {
                    if (Realta[i].family==fam)
                    {
                        int changeProfit = Realta[i].Profit * 2;
                        Realta[i].ChangeProfit(changeProfit);
                    }
                }
            }
        }

    }
}
