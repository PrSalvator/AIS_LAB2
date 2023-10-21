using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AIS_LAB2.Models;

namespace ClientWPF.Models
{
    class Car: AIS_LAB2.Models.Car, IEditableObject
    {
        [NonSerialized]
        private Car backUpCopy;
        [NonSerialized]
        private bool inEdit;
        public int? Id { get; set; }
        public void BeginEdit()
        {
            if (inEdit) return;
            inEdit = true;
            backUpCopy = this.MemberwiseClone() as Car;
        }

        public void CancelEdit()
        {
            if (!inEdit) return;
            inEdit = false;
            this.CarBrand = backUpCopy.CarBrand;
            this.CarModel = backUpCopy.CarModel;
            this.NumberOfDoors = backUpCopy.NumberOfDoors;
            this.AmountOfHorsepower = backUpCopy.AmountOfHorsepower;
        }

        public void EndEdit()
        {
            if (!inEdit) return;
            inEdit = false;
            backUpCopy = null;
        }
        //[NonSerialized]
        //public bool Ready = false;
        //[JsonIgnore]
        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string error = String.Empty;
        //        switch (columnName)
        //        {
        //            case "CarBrand":
        //                if (String.IsNullOrEmpty(CarBrand))
        //                {
        //                    error = "Введена пустая строка";
        //                }
        //                break;
        //            case "CarModel":
        //                if (String.IsNullOrEmpty(CarModel))
        //                {
        //                    error = "Введена пустая строка";
        //                }
        //                break;
        //            case "CarType":
        //                if(CarType == null)
        //                {
        //                    error = "Выберите тип машины";
        //                }
        //                break;
        //            case "BodyType":
        //                if(BodyType == null)
        //                {
        //                    error = "Выберите тип кузова";
        //                }
        //                break;
        //            case "NumberOfDoors":
        //                if(NumberOfDoors<1 || NumberOfDoors > 5){
        //                    error = "Введите число в диапозоне от 1 до 5";
        //                }
        //                break;
        //            case "AmountOfHorsepower":
        //                if(AmountOfHorsepower<1 || AmountOfHorsepower > 2028)
        //                {
        //                    error = "Введите число в диапозоне от 1 до 2028";
        //                }
        //                break;
        //        }
        //        return error;
        //    }
        //}
        //[JsonIgnore]
        //public string Error
        //{
        //    get { throw new NotImplementedException(); }
        //}
    }
}
