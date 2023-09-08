using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidl
{
    public class Customer
    {
        public string Name { get; set; }
        public void Buy(Shop shop, string productName, int quantity)
        {
            List<Product> products = shop.GetProducts();
            Product productToBuy = products.FirstOrDefault(p => p.Name == productName);

            if (productToBuy != null && productToBuy.Quantity >= quantity)
            {
                productToBuy.Quantity -= quantity;
                double totalSumm = quantity * productToBuy.Price;
                Console.WriteLine($"{Name} bought {quantity} {productToBuy.Name}(s) and payed {totalSumm}$");
                shop.SerializeProducts(products);
            }
            else
            {
                Console.WriteLine($"Sorry, {productName} not available in sufficient quantity.");
            }
        }
    }
}
