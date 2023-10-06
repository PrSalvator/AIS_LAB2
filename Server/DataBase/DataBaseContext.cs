using ClassLibrary;
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

        public DbSet<Car> Cars { get; set; }

    }
}
