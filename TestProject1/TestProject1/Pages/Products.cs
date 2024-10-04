using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class Products
    {
        public string ProductName { get; set; }
        public string Price { get; set; }

        public Products(string productname, string price)
        {
            ProductName = productname;
            Price = price; 
        }
    }
}
