using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_LAB2.Models
{
    public class BodyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
        public BodyType()
        {
            Cars = new List<Car>();
        }
    }
}
