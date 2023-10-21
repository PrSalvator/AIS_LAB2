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
            cars = JsonSerializer.Deserialize<ObservableCollection<Car>>(controller.SendMessage(remotePortRead), options);
            cars.CollectionChanged += Cars_CollectionChanged;
        }

        private void Cars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {

            }
            else if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                
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
