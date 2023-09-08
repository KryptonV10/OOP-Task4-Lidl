using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lidl
{
    public class Shop
    {
        public List<Product> Products = new List<Product>();

        private string jsonFilePath = "products.json";

        /// <summary>
        /// Add products to file
        /// </summary>
        /// <param name="newProduct"></param>
        public void AddProduct(Product newProduct)
        {
            Products = GetProducts();
            Product existingProduct = Products.FirstOrDefault(p => p.Name == newProduct.Name && p.Price == newProduct.Price);

            if (existingProduct != null)
            {
                existingProduct.Quantity += newProduct.Quantity;
            }
            else
            {
                Products.Add(newProduct);
            }
            Console.WriteLine("Product added to products");
            SerializeProducts(Products);
        }

        /// <summary>
        /// Returns products from file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Product> GetProducts() 
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                Products = JsonConvert.DeserializeObject<List<Product>>(json);
                return Products;
            }
            else
            {
                throw new Exception("Error file read");
            }
        }

        /// <summary>
        /// Serialize products to file
        /// </summary>
        /// <param name="products"></param>
        public void SerializeProducts(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products);

            File.WriteAllText(jsonFilePath, json);
        }
    }
}
