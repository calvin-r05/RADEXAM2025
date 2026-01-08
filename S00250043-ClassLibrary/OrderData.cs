using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S00250043_ClassLibrary
{
    public class OrderData
    {
        public int Order_item_id { get; set; }
        public int Order_id { get; set; }
        public int Collectible_id { get; set; }
        public int Quantity { get; set; }
        public double Unit_price { get; set; }
    }
}
