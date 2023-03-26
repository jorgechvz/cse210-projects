using System;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Test of Login 
        /* Login login = new Login();
        login.Run(); */
        Inventory _inventory = new Inventory();
        bool _exitProgram = false;
        while (!_exitProgram)
        {
            // Menu
            Console.WriteLine("Welcome to Inventory Systemy\n");
            Console.WriteLine(" 1. Create a new Product");
            Console.WriteLine(" 2. Get Products");
            Console.WriteLine(" 3. Remove Products");
            Console.WriteLine(" 4. Edit Products");
            Console.WriteLine(" 5. Save Inventary");
            Console.WriteLine(" 6. Exit");
            Console.Write("\nPlease choose a option: ");
            string _option = Console.ReadLine().ToLower();
            switch (_option)
            {
                case "1":
                    Console.Clear();
                    _inventory.CreateProduct();
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine(" 1. All Products");
                    Console.WriteLine(" 2. By Category");
                    Console.WriteLine(" 3. By Price Ascending");
                    Console.WriteLine(" 4. By Price Descending");
                    Console.Write("\nPlease choose a option: ");
                    string getProducts = Console.ReadLine().ToLower();
                    switch (getProducts)
                    {
                        case "1":
                            Console.Clear();
                            _inventory.GetProducts(_inventory.GetListProducts());
                            break;
                        case "2":
                            Console.Clear();
                            _inventory.GetProductsByCategory(_inventory.GetListProducts());
                            break;
                        case "3":
                            Console.Clear();
                            _inventory.GetProductsByPriceAscending(_inventory.GetListProducts());
                            break;
                        case "4":
                            Console.Clear();
                            _inventory.GetProductsByPriceDescending(_inventory.GetListProducts());
                            break;
                    }
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "3":
                    _inventory.RemoveProduct(_inventory.GetListProducts());
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "4":
                    _inventory.EditProduct();
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "5":
                    _inventory.SaveInventoryData(_inventory.GetListProducts(),_inventory);
                    break;
                case "6": // Option to exit the game
                    Console.WriteLine("Thanks for used the program!!");
                    _exitProgram = true;
                    return;
                default: // Default case if an invalid option is selected
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
            }
        }
    }
}

