using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S00250043_ClassLibrary
{
    public class Product
    {
        public int Collectible_id { get; set; }
        public string Name { get; set; }
        public int Category_id { get; set; }
        public double Price { get; set; }
        public string Condition { get; set; }
        public int Stock_quantity { get; set; }
    }
}
