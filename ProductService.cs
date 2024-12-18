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



            string path = "C:\\Users\\user\\Desktop\\";
            var productJson = JsonSerializer.Serialize(product);
            //File.AppendAllLines(path + "Folder/example.txt", product)
            using (StreamWriter streamWriter = new StreamWriter(path + "Folder1/example.txt", true))
            {
                streamWriter.WriteLine(productJson);
            }
            






        }

        public Product Get(int id)
        {
            var allProducts = GetAll();
            return allProducts.Find(p => p.ID == id);
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
            string[] contents = File.ReadAllLines(filePath);

            foreach (var item in contents)
            {
                Product product = JsonSerializer.Deserialize<Product>(item);
                if (product != null)
                {
                    products.Add(product);
                }
            }

            return products;
        }
        public void Delete(int id)
        {

            var products = GetAll();


            var productToDelete = products.Find(p => p.ID == id);


            if (productToDelete != null)
            {

                products.Remove(productToDelete);

                string path = "C:\\Users\\user\\Desktop\\Folder1\\";
                string filePath = Path.Combine(path, "example.txt");

                File.WriteAllText(filePath, string.Empty);


                foreach (var product in products)
                {
                    var productJson = JsonSerializer.Serialize(product);
                    using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                    {
                        streamWriter.WriteLine(productJson);
                    }
                }

                Console.WriteLine($"Product with ID {id} has been deleted.");
            }
            else
            {
                Console.WriteLine($"Product with ID {id} not found.");
            }
        }
    }
}
