using System;
using Newtonsoft.Json;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        LoginUser login = new LoginUser();
        login.RunLogin();
        if (login.GetLoginIsComplete())
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            Inventory _inventory = new Inventory();
            _inventory.SetListProducts(_inventory.LoadInventoryData(login.GetNameUser()));
            bool _exitProgram = false;
            while (!_exitProgram)
            {
                // Menu
                Console.WriteLine($"Welcome to your '{login.GetStoreName()}' store inventory\n");
                Console.WriteLine(" 1. Create a new Product");
                Console.WriteLine(" 2. Get Products");
                Console.WriteLine(" 3. Remove Products");
                Console.WriteLine(" 4. Edit Products");
                Console.WriteLine(" 5. Sell Products");
                Console.WriteLine(" 6. Save Inventary");
                Console.WriteLine(" 7. Exit");
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
                        Console.Clear();
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
                                Console.WriteLine("Press enter to return to menu...");
                                Console.ReadKey();
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
                        _inventory.SellProduct();
                        _exitProgram = false;
                        Console.Clear();
                        break;
                    case "6":
                        _inventory.SaveInventoryData(_inventory.GetListProducts(), login.GetNameUser());
                        break;
                    case "7": // Option to exit the game
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
}