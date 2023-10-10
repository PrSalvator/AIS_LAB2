using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class DataController
    {
        //public List<Models.CarType> CarTypes = new List<Models.CarType>();
        //public List<Models.BodyType> BodyTypes = new List<Models.BodyType>();
        private static DataController dataController = null;
        private DataController() { }
        public static DataController Initialyze()
        {
            if (dataController == null) dataController = new DataController();
            //dataController.CarTypes = GetCarTypes();
            //dataController.BodyTypes = GetBodyTypes();
            return dataController;
        }
        public void AddCar(Models.Car car)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                db.Cars.Add(car);
            }

        }
        public void DeleteCar(int index)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                SqlParameter param = new SqlParameter("@INDEX", index);
                db.Database.ExecuteSqlCommand("exec DeleteCars @INDEX", param);
            }
        }
        public void DeleteCars()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                db.Database.ExecuteSqlCommand("exec DeleteCars");
            }
        }
        public Models.Car GetCar(int index)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return (Models.Car)db.Cars.Where(p => p.Id == index);
            }
        }
        public List<Models.Car> GetCars()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.Cars.ToList();
            }
        }
        public List<Models.CarType> GetCarTypes()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.CarTypes.ToList();
            }
        }
        public List<Models.BodyType> GetBodyTypes()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.BodyTypes.ToList();
            }
        }
    }
}
