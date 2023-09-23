using Monopolia.Field.Chance;
using Monopolia.Field.Treasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopolia
{
    public class GeneratorField
    {
        public List<FieldMonopoly> Generator_Field()
        {
            List<FieldMonopoly> field = new List<FieldMonopoly>();
            field.Clear();
            field.Add(new FieldStart("Start",200));
            field.Add(new FieldStreet("Старая дорога", "Brown", 60, 0, 50, 2, null));
            field.Add(new FieldTreasury("Treasury"));
            field.Add(new FieldStreet("Главное шоссе", "Brown", 60, 0, 50, 2, null));
            field.Add(new FieldTax("Tax", 200));
            field.Add(new FieldStreet("Рижская ЖД", "Train", 200, 0, 0, 25, null));
            field.Add(new FieldStreet("Горный парк", "Bly", 100, 0, 50, 6, null));
            field.Add(new FieldChance("Chance",new ExitPrisonChance()));
            field.Add(new FieldStreet("Лесной курорт", "Bly", 100, 0, 50, 6, null));
            field.Add(new FieldStreet("Аквапарк", "Bly", 120, 0, 50, 8, null));
            field.Add(new FieldPrison("Prison",50));
            field.Add(new FieldStreet("Торговая площадь", "Pink", 140, 0, 100, 10, null));
            field.Add(new FieldStreet("Свет", "GKX", 150, 0, 0, 0, null));
            field.Add(new FieldStreet("Деловой квартал", "Pink", 140, 0, 100, 10, null));
            field.Add(new FieldStreet("Спальный район", "Pink", 160, 0, 100, 12, null));
            field.Add(new FieldStreet("Омская ЖД", "Train", 200, 0, 0, 25, null));
            field.Add(new FieldStreet("Завод", "Orange", 180, 0, 100, 14, null));
            field.Add(new FieldTreasury("Treasury"));
            field.Add(new FieldStreet("Фабрика", "Orange", 180, 0, 100, 14, null));
            field.Add(new FieldStreet("Эмпория", "Orange", 200, 0, 100, 16, null));
            field.Add(new FieldFreeParking("Parking"));
            field.Add(new FieldStreet("Деловой район", "Red", 220, 0, 150, 18, null));
            field.Add(new FieldChance("Chance", new ExitPrisonChance()));
            field.Add(new FieldStreet("Сады памяти", "Red", 220, 0, 150, 18, null));
            field.Add(new FieldStreet("Дом пророка", "Red", 240, 0, 150, 20, null));
            field.Add(new FieldStreet("Мемная ЖД", "Train", 200, 0, 0, 25, null));
            field.Add(new FieldStreet("Порт процветания", "Yellow", 260, 0, 150, 22, null));
            field.Add(new FieldStreet("Маяк", "Yellow", 260, 0, 150, 22, null));
            field.Add(new FieldStreet("Вода", "GKX", 150, 0, 0, 0, null));
            field.Add(new FieldStreet("Длань мудреца", "Yellow", 280, 0, 150, 24, null));
            field.Add(new FieldGotoPrison("GoToPrison",10));
            field.Add(new FieldStreet("Фонтейн футуристик", "Green", 300, 0, 200, 26, null));
            field.Add(new FieldStreet("Форт Веселый", "Green", 300, 0, 200, 26, null));
            field.Add(new FieldTreasury("Treasury"));
            field.Add(new FieldStreet("Пентхауз Олимпа", "Green", 320, 0, 200, 28, null));
            field.Add(new FieldStreet("Новая ЖД", "Train", 200, 0, 0, 25, null));
            field.Add(new FieldChance("Chance", new ExitPrisonChance()));
            field.Add(new FieldStreet("Восторг", "Black", 350, 0, 200, 35, null));
            field.Add(new FieldTax("Tax" ,100));
            field.Add(new FieldStreet("Колумбия", "Black", 400, 0, 200, 50, null));
            return field;
        }

    }
}
