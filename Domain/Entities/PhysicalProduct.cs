using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PhysicalProduct : BaseProduct
    {
        public int Quantity { get; set; }
        public double Weight { get; set; }
    }
}
