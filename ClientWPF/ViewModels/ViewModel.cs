using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AIS_LAB2.Controllers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Configuration;
using ClientWPF.Models;
using System.Threading;

namespace ClientWPF.ViewModels
{
    class ViewModel
    {

        private int remotePortRead = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortRead"));
        private int remotePortWrite = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortWrite"));
        private int remotePortDelete = int.Parse(ConfigurationManager.AppSettings.Get("RemotePortDelete"));

        private JsonSerializerOptions options = new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        private ClientController controller = ClientController.Initialyze();

        private ObservableCollection<Car> cars = new ObservableCollection<Car>();
        private Car selectedCar;

        public ViewModel()
        {
            Thread.Sleep(2000);
            cars = JsonSerializer.Deserialize<ObservableCollection<Car>>(controller.SendMessage(remotePortRead), options);
        }
        public void DeleteCar()
        {
            if (!(SelectedCar is null))
            { 
                if (!(String.IsNullOrEmpty(SelectedCar.CarBrand) || String.IsNullOrEmpty(SelectedCar.CarModel) || SelectedCar.BodyTypeId is null || SelectedCar.CarTypeId is null))
                {
                    string answer = controller.SendMessage(remotePortDelete, SelectedCar.Id.ToString());
                    Cars.Remove(SelectedCar);
                }
            }
        }
        public void AddCar()
        {
            if (!(SelectedCar is null))
            { 
                if (!(String.IsNullOrEmpty(SelectedCar.CarBrand) || String.IsNullOrEmpty(SelectedCar.CarModel) || SelectedCar.BodyTypeId is null || SelectedCar.CarTypeId is null))
                {
                    string massage = JsonSerializer.Serialize(SelectedCar);
                    string answer = controller.SendMessage(remotePortWrite, massage);
                    int id = int.Parse(answer);
                    SelectedCar.Id = id;
                }
            }
        }

        public ObservableCollection<Car> Cars { get { return cars; } private set { cars = value; } }
        public Car SelectedCar
        {
            get
            {
                return selectedCar;
            }
            set
            {
                selectedCar = value;
            }
        }
        
    }
}
