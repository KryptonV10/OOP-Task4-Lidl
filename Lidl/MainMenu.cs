using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidl
{
    public class MainMenu
    {
        Shop shop = new Shop();
        List<Product> products = new List<Product>();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Lidl!");
                Console.WriteLine("1. Show products");
                Console.WriteLine("2. Add product");
                Console.WriteLine("3. Buy products");
                Console.WriteLine("0. Exit");
                string choiceAsString = Console.ReadLine();
                MainMenuChoices choice = (MainMenuChoices)Convert.ToInt32(choiceAsString);
                switch (choice)
                {
                    case MainMenuChoices.ShowProducts:
                        ShowAllProducts();
                        break;

                    case MainMenuChoices.AddProduct:
                        AddNewProduct();
                        break;

                    case MainMenuChoices.BuyProduct:
                        BuyProducts();
                        break;

                    case MainMenuChoices.Exit:
                        Console.WriteLine("Bye :)");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
        }

        #region Private Methods
        private void BuyProducts()
        {
            Customer customer = new Customer();
            Console.Write("Enter your name: ");
            customer.Name = Console.ReadLine();
            Console.Write("Enter name of your product, you want to buy: ");
            string productName = Console.ReadLine();

            Console.Write("Enter quantity of products to buy: ");
            int quantityToBuy;
            if (int.TryParse(Console.ReadLine(), out quantityToBuy))
            {
                customer.Buy(shop, productName, quantityToBuy);
                List<Product> remainingProducts = shop.GetProducts();
                Console.WriteLine("The rest of the products in the store:");
                foreach (Product product in remainingProducts)
                {
                    Console.WriteLine($"{product.Name}: {product.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Invalid quantity. Purchase cancelled.");
            }

        }

        private void AddNewProduct()
        {
            Console.Write("Enter the product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the product price: ");
            double price;
            if (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. The product will not be added.");
                return;
            }

            Console.Write("Enter the product quantity: ");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid quantity. The product will not be added.");
                return;
            }

            Console.Write("Does the product have a discount? (yes/no): ");
            string hasDiscount = Console.ReadLine();

            Product newProduct;
            if (string.Equals(hasDiscount, "yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter the discount amount (%): ");
                double discount;
                if (!double.TryParse(Console.ReadLine(), out discount))
                {
                    Console.WriteLine("Invalid discount amount. The product will not be added.");
                    return;
                }

                newProduct = new DiscountProduct(name, price, quantity, discount);
            }
            else
            {
                newProduct = new Product ( name, price, quantity );
            }
            shop.AddProduct(newProduct);
        }

        private void ShowAllProducts()
        {
            products = shop.GetProducts();
            Console.WriteLine("Name\t\t| Quantity | Price");
            Console.WriteLine(new string('-', 36));

            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name,-15} | {product.Quantity,-8} | {product.Price}$");
            }
        }
        #endregion
    }
}
