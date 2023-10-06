using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Car
    {
        public Dictionary<int, string> Types = new Dictionary<int, string>
            {
                { 1, "Легковой"},
                { 2, "Грузовой"},
                { 3, "Грузопассажирский"},
                { 4, "Автобус"},
                { 5, "Спецтранспорт"}
            };
        public Dictionary<int, string> Bodies = new Dictionary<int, string>
            {
                { 1, "Седан"},
                { 2, "Купе"},
                { 3, "Хэтчбек"},
                { 4, "Лифтбек"},
                { 5, "Фастбэк"},
                { 6, "Универсал"},
                { 7, "Кроссовер"},
                { 8, "Внедорожник"},
                { 9, "Пикап"},
                { 10, "Легковой фургон"},
                { 11, "Минивэн"},
                { 12, "Компактвэн"},
                { 13, "Кабриолет"},
                { 14, "Родстер"},
                { 15, "Тарга"},
                { 16, "Ландо"},
                { 17, "Лимузин"},
                { 18, "Микровэн"}
            };

        public int Number_of_doors
        {
            get
            {
                return number_of_doors;
            }
            set
            {
                if (value < 0)
                {
                    number_of_doors = 1;
                }
                else if (value > 5)
                {
                    number_of_doors = 5;
                }
                else
                {
                    number_of_doors = value;
                }
            }
        }
        public int Amount_of_horsepower
        {
            get
            {
                return amount_of_horsepower;
            }
            set
            {
                if (value < 0)
                {
                    amount_of_horsepower = 1;
                }
                else if (value > 2028)
                {
                    amount_of_horsepower = 2028;
                }
                else
                {
                    amount_of_horsepower = value;
                }
            }
        }
        public string Car_type { get; set; }

        public string Car_brand { get; set; }

        public string Car_model { get; set; }
        public string Body_type { get; set; }
        public bool Is_electric_car { get; set; }

        private Car()
        {

        }
        public static Car Initialyze()
        {
            if (car == null) car = new Car();
            return car;
        }


        private static Car car = null;

        private int number_of_doors;

        private int amount_of_horsepower;



    }
}
