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
    }
}
