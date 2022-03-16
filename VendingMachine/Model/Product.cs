using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model
{
    public class Product
    {
        public string Name { get;  set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public void UpdateQuantity()
        {
            Quantity -= 1;
        }

    }
}

