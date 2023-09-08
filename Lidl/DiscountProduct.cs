using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidl
{
    public class DiscountProduct : Product
    {
        public DiscountProduct(string name, double price, int quantity, double discount) : base(name, price, quantity)
        {
            Discount = discount;
        }
        public double Discount { get; set; }
    }
}
