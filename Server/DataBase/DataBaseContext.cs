using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("DBConnection")
        {
            
        }

        public DbSet<Models.Car> Cars { get; set; }
        public DbSet<Models.BodyType> BodyTypes { get; set; }
        public DbSet<Models.CarType> CarTypes { get; set; }
    }

}
