using System;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
       
        LoginUser login = new LoginUser();
        login.Run();
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

/* For the progress of my project, I have created all the classes that I will need as their respective constructors, methods, getters and setters. I'm still working on completing some methods such as saving, loading of inventory data and override methods of the subclasses of the Product class. But I have already been able to build the main methods such as the method to create new products, remove them, show the products either all, by categories or prices. I have also implemented the LoginUser class where the login works correctly, as well as if the user does not exist, a new user can be created. I did this so that the users are saved in a json file. I also have a small structure of the program of how it will look at the beginning in the console. I feel that my program is already 60% complete. */