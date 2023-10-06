using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Server
{
    public class DataController
    {
        private static DataController dataController = null;

        private string path;

        protected DataController()
        {

        }

        public static DataController Initialyze(string path) // Не забыть сделать дефолт значение
        {
            if (dataController == null)
            {
                dataController = new DataController();
                dataController.path = path;
            }
            return dataController;
        }

        public string ReadData()
        {
            using (StreamReader sr = new StreamReader(dataController.path, System.Text.Encoding.Default))
            {
                return sr.ReadToEnd();
            }
        }

        public string ReadData(int index)
        {
            using (StreamReader sr = new StreamReader(dataController.path, System.Text.Encoding.Default))
            {
                string[] data;
                data = sr.ReadToEnd().Split('\n');
                try
                {
                    return data[index];
                }
                catch (Exception e)
                {
                    return $"{e.Message}";
                }
            }
        }

        public void WriteData(string car)
        {
            using (StreamWriter sw = new StreamWriter(dataController.path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(car);
            }
        }

        public void DeleteData()
        {
            using (StreamWriter sw = new StreamWriter(dataController.path, false, System.Text.Encoding.Default))
            {
                sw.Write("");
            }
        }
        public void DeleteData(int index)
        {
            string[] data;
            using (StreamReader sr = new StreamReader(dataController.path, System.Text.Encoding.Default))
            {
                data = sr.ReadToEnd().Split('\n');
            }
            DeleteData();
            using (StreamWriter sw = new StreamWriter(dataController.path, true, System.Text.Encoding.Default))
            {
                data[index] = "";
                for (int i = 0; i < data.Length-1; i++)
                {
                    if (i != index)
                    {
                        sw.WriteLine(data[i]);
                    }
                }
            }
        }
    }
}
