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
                File.Create(path + "Folder1/example.txt");
            }

            Product product1 = new Product("Salam", 100, 120);
            Product product2 = new Product("Hello", 150, 180);

            ProductService productService = new ProductService();

            productService.Create(product1);
            productService.Create(product2);

            Console.WriteLine("Product for id");
            try
            {
                var product = productService.Get(3);




                if (product != null)
                {
                    Console.WriteLine($"Product found: {product.Name}, {product.CostPrice}, {product.SalePrice}");
                }
                else
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine("Not found");
                }
             

                
            }
            catch (Exception ex)
            {

                Console.WriteLine("ID not be less than 0");
            }

            Console.WriteLine("---------------------------------------------------");
            var allProducts = productService.GetAll();
                Console.WriteLine("\nAll Products:");
                foreach (var p in allProducts)
                {
                    Console.WriteLine($"{p.ID}: {p.Name}, {p.CostPrice}, {p.SalePrice}");
                }

            try
            {
                productService.Delete(-1);
            }
            catch (Exception ex) {

                Console.WriteLine("-------------------");

                Console.WriteLine("ID not be less than 0");
            }
            Console.WriteLine("---------------------------------------------------");

                allProducts = productService.GetAll();
                Console.WriteLine("\nAll Products After Deletion:");
                foreach (var p in allProducts)
                {
                    Console.WriteLine($"{p.ID}: {p.Name}, {p.CostPrice}, {p.SalePrice}");
                }
            }
    }
}
