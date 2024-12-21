
namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\user\\Desktop\\";
            Directory.CreateDirectory(path + "Folder1");

            if (!File.Exists(path + "Folder1/example.txt"))
            {
                using (File.Create(path + "Folder1/example.txt")) { }
            }

            Product product1 = new Product("Salam", 100, 10); 
            Product product2 = new Product("Hello", 150, 180); 

            ProductService productService = new ProductService();

            productService.Create(product1); 
            productService.Create(product2); 

            try
            {
                var product = productService.Get(2);

                if (product != null)
                {
                    Console.WriteLine($"Product found: {product.Name}, {product.CostPrice}, {product.SalePrice}");
                }
                else
                {
                    Console.WriteLine("Not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the product: {ex.Message}");
            }

            Console.WriteLine("\nAll Products:");
            var allProducts = productService.GetAll();
            foreach (var p in allProducts)
            {
                Console.WriteLine($"{p.ID}: {p.Name}, {p.CostPrice}, {p.SalePrice}");
            }

            try
            {
                productService.Delete(1);
                Console.WriteLine("Product with ID 1 deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
            }

            Console.WriteLine("\nAll Products After Deletion:");
            allProducts = productService.GetAll();
            foreach (var p in allProducts)
            {
                Console.WriteLine($"{p.ID}: {p.Name}, {p.CostPrice}, {p.SalePrice}");
            }
        }
    }
}
