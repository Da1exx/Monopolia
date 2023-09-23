using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopolia.Field.Chance;
using Monopolia.Field.Treasure;

namespace Monopolia
{
    public class GamePlay
    {
        public List<FieldMonopoly> field { get; private set; }
        public List<Player> players { get; private set; }
        public int numplayers { get; private set; } 
        public int KolTern { get; private set; }

        public GamePlay()
        {
            field = new List<FieldMonopoly>();
            players = new List<Player>();
            KolTern = 0;
            numplayers=-1;
        }

        /// <summary>
        /// Эффект хода передвежение игрока
        /// </summary>
        /// <returns></returns>
        public int[] Game()
        {
            Death();
            if (ViKA() == true) { return null; }
            if (numplayers == players.Count - 1)
            {
                numplayers = 0;
            }
            else { numplayers++; }
            KolTern++;
            int[] roll = GOEffectBeforeMove(field, players[numplayers]);
            if (players[numplayers].SkipTurn == 0)
            {
                GOEffectShiftMove(field, players[numplayers],roll);
                players[numplayers].ChangeShiftField(roll[0] + roll[1]); //
                field[players[numplayers].Field].EffectAfterMove(players[numplayers]);
            }
            else {players[numplayers].ChangeSkipTurn(-1); }
            return roll;
        }

        /// <summary>
        /// Создание поля и игроков
        /// </summary>
        /// <param name="playersName"></param>
        public void CreateGameAndPlayer(List<string> playersName)
        {
            GeneratorField GF = new GeneratorField();
            field = GF.Generator_Field();
            for (int i = 0; i < playersName.Count; i++)
            {
                Player player = new Player(playersName[i], 1500, 0, false, false, new List<FieldStreet>(), 0);
                players.Add(player);
            } 
        }

        /// <summary>
        ///  Действие продажа дома
        /// </summary>
        /// <param name="selectedStreet"></param>
        /// <param name="player"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string GOSellHouse(FieldStreet selectedStreet)
        {
            if (selectedStreet != null)
            {
                string name = selectedStreet.name;
                int numfield = field.FindIndex(item => item.name == name);
                if (selectedStreet.DtCellHouse() == true)
                {
                    selectedStreet.SellHouse(players[numplayers]);
                    return "Дом продан";
                }
            }
            return "Продавать нечего";
        }

        /// <summary>
        /// Действие покупка дома
        /// </summary>
        /// <param name="selectedStreet"></param>
        /// <param name="familyField"></param>
        /// <param name="player"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string GoBuyHouse(FieldStreet selectedStreet)
        {
            if (selectedStreet != null)
            {
                List<string> familyField = players[numplayers].CheckingSets();
                string family = selectedStreet.family;
                if (familyField.Contains(family) == true)
                {
                    if (selectedStreet.DtBuyHouse() == true)
                    {
                        selectedStreet.BuyHouse(players[numplayers]);
                        return "Дом построен";
                    }
                }
                else { return "нету сета карт"; }
            }
            return "Выше строить нельзя";
        }

        /// <summary>
        /// Действие покупка улицы
        /// </summary>
        /// <param name="selectedStreet"></param>
        /// <param name="player"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public string GoBuyStreet()
        {
            if (field[players[numplayers].Field] is FieldStreet selectedStreet)
            {
                if (selectedStreet.PossibleToBuyStreet() == true)
                {
                    players[numplayers].BuyStreet(selectedStreet);
                    return "Здание куплено";
                }
                return "Здание уже куплено";
            }
            else
            {
                return "Элемент не является улицей";
            }
        }

        /// <summary>
        /// Действие обмен     1 1 2 1
        /// </summary>
        /// <param name="SPM">индекс игрока и сама улица с который хочет поменяться</param>
        /// <param name="player">Активный игрок который предлагает обмен</param>
        /// <param name="selectedStreet">Улица которую хоти ппоменять</param>
        /// <returns></returns>
        public string GoChange(FieldStreet selectedStreet1, FieldStreet selectedStreet2)
        {
            if ((selectedStreet1 != null) && (selectedStreet2 != null))
            {
                if (players[numplayers].CheackChange(selectedStreet1, selectedStreet2) == true)
                {
                    players[numplayers].Change(selectedStreet1, selectedStreet2);
                    return "Обмен совершен";
                }
                else { return "Обмен совершить не возможно"; }

            }
            else { return "Выберете что и с кем хотите поменяться"; }
        }

        /// <summary>
        /// Эффект перед броском костей и сам бросок костей
        /// </summary>
        /// <param name="FM"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private int[] GOEffectBeforeMove(List<FieldMonopoly> FM, Player player)
        {
            RollDice RD = new RollDice();
            int[] roll;
            if  (player.PrisonStatus == true)
            {
                roll=FM[player.Field].EffectBeforeMove(player);
            }
            else {roll = RD.DiceRoll(); }
            return roll;
        }

        /// <summary>
        /// Эффект когда игрок идет по полю
        /// </summary>
        /// <param name="FM"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private void GOEffectShiftMove(List<FieldMonopoly> FM, Player player,int[] roll)
        {
            int kol = player.Field;
            if ((((player.Field + roll[0] + roll[1]) / 39) >= 1) && (player.SkipTurn == 0))
            {
                int fieldStart = 0;
                player.ChangeField(fieldStart);
                FM[player.Field].EffectShiftMove(player);
                player.ChangeField(kol);
            }
        }

        /// <summary>
        /// Проверка на то что окончилась ли игра
        /// </summary>
        /// <returns></returns>
        private bool ViKA()
        {
            if (players.Count == 1) { return true; }
            return false;
        }

        /// <summary>
        /// Игкрок Банкрот
        /// </summary>
        private void Death()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Money < 0)
                {
                    players.RemoveAt(i);
                }
            }
        }
    }
}
