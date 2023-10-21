using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ClientWPF.Validation
{
    class CarValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Models.Car car = (value as BindingGroup).Items[0] as Models.Car;
            if(String.IsNullOrEmpty(car.CarBrand))
            {
                return new ValidationResult(false, "Введите брэнд машины");
            }
            if (String.IsNullOrEmpty(car.CarModel))
            {
                return new ValidationResult(false, "Введите модель машины");
            }
            if (car.BodyTypeId is null)
            {
                return new ValidationResult(false, "Выберите тип кузова");
            }
            if (car.CarTypeId is null)
            {
                return new ValidationResult(false, "Выберите тип машины");
            }
            return ValidationResult.ValidResult;
        }
    }
}
