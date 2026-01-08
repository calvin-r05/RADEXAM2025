using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S00250043_ClassLibrary
{
    public class Order
    {
        public int Order_id { get; set; }
        public int User_id { get; set; }
        public double Total_price { get; set; }
        public string Payment_status { get; set; }
        public string Order_status { get; set; }
    }
}
