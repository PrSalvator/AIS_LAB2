using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIS_LAB2.Models
{
    public class Car
    {
        public int? Id { get; set; }
        public int NumberOfDoors
        {
            get
            {
                return numberOfDoors;
            }
            set
            {
                if (value < 0)
                {
                    numberOfDoors = 1;
                }
                else if (value > 5)
                {
                    numberOfDoors = 5;
                }
                else
                {
                    numberOfDoors = value;
                }
            }
        }
        public int AmountOfHorsepower
        {
            get
            {
                return amountOfHorsepower;
            }
            set
            {
                if (value < 0)
                {
                    amountOfHorsepower = 1;
                }
                else if (value > 2028)
                {
                    amountOfHorsepower = 2028;
                }
                else
                {
                    amountOfHorsepower = value;
                }
            }
        }

        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public bool IsElectricCar { get; set; }

        public int? CarTypeId { get; set; }
        public CarType CarType { get; set; }

        public int? BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }


        public Car()
        {

        }
        public static Car Initialyze()
        {
            if (car == null) car = new Car();
            return car;
        }


        private static Car car = null;

        private int numberOfDoors;

        private int amountOfHorsepower;
    }
}
