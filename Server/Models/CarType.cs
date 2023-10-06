using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Models
{
    class CarType
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Car> Cars { get; set; }
        public CarType()
        {
            Cars = new List<Car>();
        }
    }
}
