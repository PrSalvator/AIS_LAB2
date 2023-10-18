using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AIS_LAB2.Controllers;
using AIS_LAB2.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Configuration;

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
        private ObservableCollection<CarType> carTypes;

        public ViewModel()
        {
            cars = JsonSerializer.Deserialize<ObservableCollection<Car>>(controller.SendMessage(remotePortRead), options);
            carTypes = new ObservableCollection<CarType>(controller.GetCarTypes());
        }
        public ObservableCollection<Car> Cars { get { return cars; } }
        public ObservableCollection<CarType> CarTypes { get { return carTypes; } }
    }
}
