using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.ViewModels
{
    public class CarTypesObservableCollection
    {
        private ObservableCollection<AIS_LAB2.Models.CarType> carTypes;
        public CarTypesObservableCollection()
        {
            carTypes = new ObservableCollection<AIS_LAB2.Models.CarType>(AIS_LAB2.Controllers.ClientController.Initialyze().GetCarTypes());
        }
        public ObservableCollection<AIS_LAB2.Models.CarType> GetCarTypes()
        {
            return carTypes;
        }
    }
}
