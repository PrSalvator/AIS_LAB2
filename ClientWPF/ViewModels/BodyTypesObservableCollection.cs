using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.ViewModels
{
    class BodyTypesObservableCollection
    {
        private List<AIS_LAB2.Models.BodyType> bodyTypes;
        public BodyTypesObservableCollection()
        {
            bodyTypes = AIS_LAB2.Controllers.ClientController.Initialyze().GetBodyTypes();
        }
        public List<AIS_LAB2.Models.BodyType> GetBodyTypes()
        {
            return bodyTypes;
        }
    }
}
