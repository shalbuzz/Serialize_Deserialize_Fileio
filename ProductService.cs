using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test
{
    public class ProductService
    {
        List<Product> products;
        public ProductService()
        {
            products = new List<Product>();
        }

        public void Create(Product product)
        {
            string path = "C:\\Users\\user\\Desktop\\Folder1\\";
            string filePath = Path.Combine(path, "example.txt");

            if (product.SalePrice < product.CostPrice)
            {
                Console.WriteLine($"Product '{product.Name}' has invalid SalePrice and will not be added.");
                return; 
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var productJson = JsonSerializer.Serialize(product);

            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(productJson);
            }
        }


        public Product Get(int id)
        {
            if(id < 0)
            {
                throw new ArgumentException();
            }

           
            else {
                var allProducts = GetAll();
                return allProducts.Find(p => p.ID == id);

            }
           
        }

       
        public List<Product> GetAll()
        {

            string path = "C:\\Users\\user\\Desktop\\Folder1\\";
              string filePath = Path.Combine(path, "example.txt");
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No products found.");
                return new List<Product>();
            }

            var products = new List<Product>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                try
                {
                    var product = JsonSerializer.Deserialize<Product>(line);
                    if (product != null)
                    {
                        products.Add(product);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
                }
            }

            return products;
        }


        

        public void Delete(int id)
        {
            var products = GetAll();
            var productToDelete = products.Find(p => p.ID == id);

            if (productToDelete == null)
            {
                Console.WriteLine($"Product with ID {id} not found.");
                return;
            }

            products.Remove(productToDelete);

            string path = "C:\\Users\\user\\Desktop\\Folder1\\";
            string filePath = Path.Combine(path, "example.txt");

      
            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                foreach (var product in products)
                {
                    var productJson = JsonSerializer.Serialize(product);
                    streamWriter.WriteLine(productJson);
                }
            }

            Console.WriteLine($"Product with ID {id} has been deleted.");
        }

    }
}

