
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

            Product product1 = new Product("Salam", 100, 100);
            Product product2 = new Product("Hello", 150, 180);

            ProductService productService = new ProductService();
            try
            {

                int input;

                do
                {
                    
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. View all products");
                    Console.WriteLine("2. Find a product");
                    Console.WriteLine("3. Create products");
                    Console.WriteLine("4. Delete a product");
                    Console.WriteLine("0. Exit");
                    Console.Write("Please choose an option: ");

                    try
                    {
                        input = int.Parse(Console.ReadLine());



                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("\nAll Products:");
                                var allProducts = productService.GetAll();
                                if (allProducts.Any())
                                {
                                    foreach (var product in allProducts)
                                    {
                                        Console.WriteLine($"{product.ID}: {product.Name}, Cost Price: {product.CostPrice}, Sale Price: {product.SalePrice}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("The product list is empty.");
                                }
                                break;

                            case 2:
                                Console.Write("\nEnter the product ID: ");
                                if (int.TryParse(Console.ReadLine(), out int productId))
                                {
                                    try
                                    {
                                        var product = productService.Get(productId);
                                        if (product != null)
                                        {
                                            Console.WriteLine($"Product found: {product.Name}, Cost Price: {product.CostPrice}, Sale Price: {product.SalePrice}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Product not found.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"An error occurred while retrieving the product: {ex.Message}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. The ID must be a number.");
                                }
                                break;

                            case 3:
                                Console.WriteLine("\nCreating Products:");
                                productService.Create(product1);
                                productService.Create(product2);
                                Console.WriteLine($"Products created successfully: 1: {product1.Name}, 2: {product2.Name}");
                                break;

                            case 4:
                                Console.Write("\nEnter the product ID to delete: ");
                                if (int.TryParse(Console.ReadLine(), out int deleteId))
                                {
                                    if (deleteId < 1)
                                    {
                                        Console.WriteLine("Invalid ID. The ID must be greater than 0.");
                                    }
                                    else
                                    {
                                        try
                                        {
                                            var product = productService.Get(deleteId);
                                            if (product != null)
                                            {
                                                productService.Delete(deleteId);
                                                Console.WriteLine($"Product with ID {deleteId} was successfully deleted.");
                                                Console.WriteLine("\nAll Products After Deletion:");
                                                allProducts = productService.GetAll();
                                                if (allProducts.Any())
                                                {
                                                    foreach (var products in allProducts)
                                                    {
                                                        Console.WriteLine($"{products.ID}: {products.Name}, Cost Price: {products.CostPrice}, Sale Price: {products.SalePrice}");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The product list is empty.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Product with ID {deleteId} does not exist.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"An error occurred while deleting the product: {ex.Message}");
                                        }
                                       
                                        
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. The ID must be a number.");
                                }
                                break;


                            case 0:
                                Console.WriteLine("Exiting the program.");
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Please enter a number between 0 and 4.");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        input = -1;
                    }


                } while (input != 0);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong");





            }
        }
    }
}
