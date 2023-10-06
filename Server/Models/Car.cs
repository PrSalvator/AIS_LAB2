using System;
using System.Collections.Generic;
namespace Server.Models
{
    public class Car
    {
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

        public string Car_brand { get; set; }

        public string Car_model { get; set; }

        public bool Is_electric_car { get; set; }

        public string Car_type { get; set; }

        public string Body_type { get; set; }
        

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
