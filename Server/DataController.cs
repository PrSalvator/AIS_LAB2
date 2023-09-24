using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Configuration;
using System.Collections.Specialized;

namespace Server
{
    class DataController
    {
        private static DataController dataController = null;

        private string path = ConfigurationManager.AppSettings.Get("Path");

        protected DataController()
        {

        } 

        public static DataController Initialyze()
        {
            if (dataController == null)
            {
                dataController = new DataController();
            }
            return dataController;
        }
        
    }
}
