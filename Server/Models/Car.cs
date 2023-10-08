using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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

        [Required]
        public string CarBrand { get; set; }
        [Required]
        public string CarModel { get; set; }
        [Required]
        public bool IsElectricCar { get; set; }

        public int? CarTypeId { get; set; }
        public CarType CarType { get; set; }

        public int? BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        

        private Car()
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
