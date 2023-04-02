using System;
using Newtonsoft.Json;
using ConsoleTables;
using ConsoleTableExt;

public class Inventory
{
    // Attributes
    private List<Product> _listProducts;
    // Constructor
    public Inventory()
    {
        _listProducts = new List<Product>();
    }
    // Getters and Setters
    public List<Product> GetListProducts()
    {
        return _listProducts;
    }
    public void SetListProducts(List<Product> newListProduct)
    {
        _listProducts = newListProduct;
    }
    // Method to add Products
    public void AddProduct(Product product)
    {
        _listProducts.Add(product);
    }
    // Method to edit a product
    public void EditProduct()
    {
        try
        {
            // Check that the list is diferent to 0
            if(_listProducts.Count != 0)
            {
                // Call the Method GetProducts
                GetProducts(_listProducts);
                Console.Write("\nPlease choose a product that you want to edit: ");
                int chooseProduct = int.Parse(Console.ReadLine());
                Product chosenProduct = _listProducts[chooseProduct-1];
                Console.Clear();
                Console.WriteLine("Your selected product");
                chosenProduct.PrintInfoProduct();
                Console.WriteLine("\n");
                chosenProduct.EditProduct();
            } else 
            {
                Console.WriteLine("You don't have products yet, please add products");
                Thread.Sleep(3000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while edit the product, error: {ex.Message}\nPlease try again.");
            Thread.Sleep(5000);
        }
    }
    // Method to sell Product
    public void SellProduct()
    {
        try
        {
            if(_listProducts.Count != 0)
            {
                Console.Clear();
                GetProducts(_listProducts);
                Console.Write("\nPlease choose a product that you want to sell: ");
                int chooseProduct = int.Parse(Console.ReadLine());
                Product chosenProduct = _listProducts[chooseProduct-1];
                Console.Clear();
                Console.WriteLine("Your selected product");
                chosenProduct.PrintInfoProduct();
                Console.WriteLine("\n");
                if (chosenProduct.GetProductQuantity() != 0 && chosenProduct.GetProductQuantity() > 0)
                {
                    Console.Write("How many units do you want to sell?: ");
                    int unitsSell = int.Parse(Console.ReadLine());
                    if (chosenProduct is FoodProduct foodProduct)
                    {
                        if (unitsSell <= chosenProduct.GetProductQuantity() && foodProduct.GetExpirationDate() <= DateTime.Today)
                        {
                            int newUnits = chosenProduct.GetProductQuantity() - unitsSell;
                            chosenProduct.SetProductQuantity(newUnits);
                            Console.WriteLine($"You sold {unitsSell} units of your product successfully");
                            Thread.Sleep(5000);
                        } else 
                        {
                            Console.WriteLine("You do not have units available in your stock or the product has already expired."); 
                            Thread.Sleep(5000);
                        }
                    } else
                    {    
                        if (unitsSell <= chosenProduct.GetProductQuantity())
                        {
                            int newUnits = chosenProduct.GetProductQuantity() - unitsSell;
                            chosenProduct.SetProductQuantity(newUnits);
                            Console.WriteLine($"You sold {unitsSell} units of your product successfully");
                            Thread.Sleep(5000);
                        } else 
                        {
                            Console.WriteLine("You do not have stock available to sell this product, add more stock"); 
                            Thread.Sleep(5000);
                        }
                    }
                } else
                {
                   Console.WriteLine("You do not have stock available to sell this product, add more stock"); 
                   Thread.Sleep(5000);
                }
            } else 
            {
                Console.WriteLine("You don't have products yet, please add products");
                Thread.Sleep(3000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while edit the product, error: {ex.Message}\nPlease try again.");
            Thread.Sleep(5000);
        }
    }
    public void CreateProduct()
    {
        try
        {   
            Console.WriteLine("The category of products are:\n");
            Console.WriteLine(" 1. Food");
            Console.WriteLine(" 2. Clothes");
            Console.WriteLine(" 3. Tool");
            Console.WriteLine(" 4. Technology");
            Console.Write("\nWhich category of product would you like to create? or write 'quit' to return Menu: ");
            string category = Console.ReadLine().ToLower();
            switch (category)
            {
                case "1":
                    Console.Write("\nWhat is the product name: ");
                    string foodProductName = Console.ReadLine();
                    Console.Write("What is the product price: ");
                    float foodProductPrice = float.Parse(Console.ReadLine());
                    Console.Write("What is the product quantity: ");
                    int foodProductQuantity = int.Parse(Console.ReadLine());
                    Console.Write("What is the production date (MM/dd/yyyy hh:mm:ss): ");
                    DateTime foodProductionDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("What is the expiration date (MM/dd/yyyy hh:mm:ss): ");
                    DateTime foodExpirationDate = DateTime.Parse(Console.ReadLine());
                    FoodProduct foodProduct = new FoodProduct(foodProductName,foodProductPrice,foodProductQuantity,foodProductionDate,foodExpirationDate);
                    AddProduct(foodProduct);
                    break;
                case "2":
                    Console.Write("\nWhat is the product name: ");
                    string clothingProductName = Console.ReadLine();
                    Console.Write("What is the product price: ");
                    float clothingProductPrice = float.Parse(Console.ReadLine());
                    Console.Write("What is the product quantity: ");
                    int clothingProductQuantity = int.Parse(Console.ReadLine());
                    Console.Write("What is the product size: ");
                    string clothingProductSize = Console.ReadLine();
                    Console.Write("What is the product material: ");
                    string clothingProductMaterial = Console.ReadLine();
                    ClothingProduct clothingProduct = new ClothingProduct(clothingProductName,clothingProductPrice,clothingProductQuantity,clothingProductSize,clothingProductMaterial);
                    AddProduct(clothingProduct);
                    break;
                case "3":
                    Console.Write("\nWhat is the product name: ");
                    string toolProductName = Console.ReadLine();
                    Console.Write("What is the product price: ");
                    float toolProductPrice = float.Parse(Console.ReadLine());
                    Console.Write("What is the product quantity: ");
                    int toolProductQuantity = int.Parse(Console.ReadLine());
                    Console.Write("What is the tool type: ");
                    string toolType = Console.ReadLine();
                    Console.Write("What is the product material: ");
                    string toolProductMaterial = Console.ReadLine();
                    ToolProduct toolProduct = new ToolProduct(toolProductName,toolProductPrice,toolProductQuantity,toolType,toolProductMaterial);
                    AddProduct(toolProduct);
                    break;
                case "4":
                    Console.Write("\nWhat is the product name: ");
                    string technologyProductName = Console.ReadLine();
                    Console.Write("What is the product price: ");
                    float technologyProductPrice = float.Parse(Console.ReadLine());
                    Console.Write("What is the product quantity: ");
                    int technologyProductQuantity = int.Parse(Console.ReadLine());
                    Console.Write("What is the product brand: ");
                    string technologyProductBrand = Console.ReadLine();
                    TechnologyProduct technologyProduct = new TechnologyProduct(technologyProductName,technologyProductPrice,technologyProductQuantity,technologyProductBrand);
                    AddProduct(technologyProduct);
                    break;
                case "quit":
                    Console.Clear();
                    break;
                default: // Default case if an invalid option is selected
                    Console.Write("\nInvalid option. Please try again.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while creating the product, error: {ex.Message}\nPlease try again.");
            Thread.Sleep(5000);
        }  
    }
    public void RemoveProduct(List<Product> product)
    {
        try
        {
            if(product.Count != 0)
            {
                Console.Clear();
                GetProducts(_listProducts);
                Console.Write("\nChoose the product to remove: ");
                int productChoice = int.Parse(Console.ReadLine());
                Console.WriteLine("Your selected product to be removed\n");
                _listProducts[productChoice-1].PrintInfoProduct();
                Console.Write("\n\nDo you wish to continue? (y/n): ");
                string optionRemove = Console.ReadLine().ToLower();
                if (optionRemove == "y" || optionRemove == "yes")
                {
                    product.RemoveAt(productChoice-1);
                    Console.WriteLine("\nProduct removed successfully");
                    Thread.Sleep(3000);
                } else
                {
                    Console.WriteLine("The product was not removed");
                    Thread.Sleep(3000);
                }
            } else 
            {
                Console.WriteLine("You don't have products yet, please add products");
                Thread.Sleep(3000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nThere was an error removing the product. Error: {ex.Message}\nTry again");
            Thread.Sleep(5000); 
        }
    }
    public void GetProducts(List<Product> product)
    {
        try
        {
            if (product.Count != 0)
            {    
                Console.WriteLine("Your Products");
                var table = new ConsoleTable("N°", "Name", "Category", "Quantity","Unit Price","Discount","Total Price","Avalaible");
                int countProductIndex = 0;
                foreach(Product productItem in product)
                {
                    countProductIndex++;
                    float priceWithDiscount = (productItem.CalculatePrice() * productItem.CalculateDiscount()) + productItem.CalculatePrice();
                    table.AddRow(countProductIndex, productItem.GetProductName(), productItem.GetProductCategory(),productItem.GetProductQuantity(),$"$ {productItem.GetProductPrice():F2}",$"$ {productItem.CalculateDiscount():F2}",$"$ {priceWithDiscount:F2}",productItem.IsAvalaible());
                }
                Console.WriteLine(table.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nThere was an error get the products. Error: {ex.Message}\nTry again");
            Thread.Sleep(5000);
        }
    }
    public void GetProductsByCategory(List<Product> product)
    {
        if (product.Count != 0)
        {
            Console.Clear();
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("The category of products are:\n");
                Console.WriteLine(" 1. Food");
                Console.WriteLine(" 2. Clothes");
                Console.WriteLine(" 3. Tool");
                Console.WriteLine(" 4. Technology");
                Console.Write("\nWhich category of product would you like to see or write 'quit' to return Menu: ");
                string categorySelected = Console.ReadLine();
                switch(categorySelected)
                {
                    case "1":
                        PrintProductsByCategory(product,"FoodProduct");
                        exitMenu = false;
                        break;
                    case "2":
                        PrintProductsByCategory(product,"ClothingProduct");
                        exitMenu = false;
                        break;
                    case "3":
                        PrintProductsByCategory(product,"ToolProduct");
                        exitMenu = false;
                        break;
                    case "4":
                        PrintProductsByCategory(product,"TechnologyProduct");
                        exitMenu = false;
                        break;
                    case "quit":
                        exitMenu = true;
                        Console.Clear();
                        break;
                    default: // Default case if an invalid option is selected
                        Console.WriteLine("\nInvalid option. Please try again.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                }
            }
        } else
        {
            Console.WriteLine("You don't have goals yet, please add goals");
            Thread.Sleep(3000);
        }
        static void PrintProductsByCategory(List<Product> products, string category)
        {
            Console.Clear();
            bool exitProductCategory = false;
            var table = new ConsoleTable("N°", "Name", "Quantity","Unit Price","Discount","Total Price","Avalaible");
            for (int i=0; i < products.Count; i++)
            {
                if (products[i].GetType().Name == category)
                {    
                    exitProductCategory = true;
                    float priceWithDiscount = (products[i].CalculatePrice() * products[i].CalculateDiscount()) + products[i].CalculatePrice();
                    table.AddRow(i+1, products[i].GetProductName(),products[i].GetProductQuantity(),$"$ {products[i].GetProductPrice():F2}",$"$ {products[i].CalculateDiscount():F2}",$"$ {priceWithDiscount:F2}",products[i].IsAvalaible());
                }
            }
            Console.WriteLine(table.ToString());
            if(!exitProductCategory)
            {
                Console.WriteLine("You don't have Products for this category yet.");
            }
            Console.Write("\nPress enter to return to menu... ");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void GetProductsByPriceAscending(List<Product> product)
    {
        List<Product> sortedProduct = product.OrderBy(p => p.GetProductPrice()).ToList();
        var table = new ConsoleTable("N°", "Name", "Category", "Quantity","Unit Price","Discount","Total Price","Avalaible");
        int countProductIndex = 0;
        foreach (Product productItem in sortedProduct)
        {
            countProductIndex++;
            float priceWithDiscount = (productItem.CalculatePrice() * productItem.CalculateDiscount()) + productItem.CalculatePrice();
            table.AddRow(countProductIndex, productItem.GetProductName(), productItem.GetProductCategory(),productItem.GetProductQuantity(),$"$ {productItem.GetProductPrice():F2}",$"$ {productItem.CalculateDiscount():F2}",$"$ {priceWithDiscount:F2}",productItem.IsAvalaible());
        }
        Console.WriteLine(table.ToString());
        Console.Write("\nPress enter to return to menu... ");
        Console.ReadKey();
        Console.Clear();
    }
    public void GetProductsByPriceDescending(List<Product> product)
    {
        List<Product> sortedProduct = product.OrderByDescending(p => p.GetProductPrice()).ToList();
        var table = new ConsoleTable("N°", "Name", "Category", "Quantity","Unit Price","Discount","Total Price","Avalaible");
        int countProductIndex = 0;
        foreach (Product productItem in sortedProduct)
        {
            countProductIndex++;
            float priceWithDiscount = (productItem.CalculatePrice() * productItem.CalculateDiscount()) + productItem.CalculatePrice();
            table.AddRow(countProductIndex, productItem.GetProductName(), productItem.GetProductCategory(),productItem.GetProductQuantity(),$"$ {productItem.GetProductPrice():F2}",$"$ {productItem.CalculateDiscount():F2}",$"$ {priceWithDiscount:F2}",productItem.IsAvalaible());
        }
        Console.WriteLine(table.ToString());
        Console.Write("\nPress enter to return to menu... ");
        Console.ReadKey();
        Console.Clear();
    }
    public void SaveInventoryData(List<Product> products, string nameuser)
    {
        // Create an anonymous instance and assign the list of products 
        var dataToSerialize = new 
        {
            Inventory = products
        };
        // Create an instance of JsonSerializerSettings and configure the handling of type names
        JsonSerializerSettings settingsSave = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        try
        {
            // Serialize the anonymous instance to JSON format using the specified configuration options
            string json = JsonConvert.SerializeObject(dataToSerialize, Formatting.Indented, settingsSave);
            // Write the serialized JSON to a file with the specified name
            File.WriteAllText($@"Inventories\{nameuser}\inventory.json", json);
            // Call a ProgressBar function to update a progress bar or inform the user that the operation has completed successfully
            ProgressBar("Inventory","Saved");
            Thread.Sleep(3000);
            Console.Clear();
        }
        catch (Exception ex)
        {
            // If an exception occurs, display an error message on the console
            Console.WriteLine($"\nException while saving goals: {ex.Message}");
            Thread.Sleep(5000);
        }
    }
    public List<Product> LoadInventoryData(string nameuser)
    {
        // Verify if the file exist or not
        if(!File.Exists($@"Inventories\{nameuser}\inventory.json"))
        {
            Console.WriteLine($"\nThe file inventory.json no exist");  
        }
        // Create an instance of JsonSerializerSettings and configure the handling of type names
        JsonSerializerSettings settingsLoad = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        try
        {
            // Read the content of the JSON file and store it in a string
            string json = File.ReadAllText($@"Inventories\{nameuser}\inventory.json");
            // Deserialize the JSON into an anonymous variable using the specified configuration options
            var data = JsonConvert.DeserializeAnonymousType(json, new { Inventory = new List<Product>()}, settingsLoad);
            // Assign the list of products to the local variables
            List<Product> product = data.Inventory;
            // Return the list of goals
            return product;
        }
        catch
        {
            // If an exception occurs, display an error message on the console
            Console.WriteLine($"You still do not have products in your inventory, please add them.\n");
            // Return an empty list of goals
            return new List<Product>();
        }
    }
    public void ProgressBar(string filename, string message){
        int progress = 0;
        int total = 100;
        int barLength = Console.WindowWidth - message.Length - filename.Length - 22;
        while (progress <= total) {
            //Display Progress Bar
            int completedLength = (int)((float)progress / total * barLength);
            int remainingLength = barLength - completedLength;
            Console.Write("\r{0}% [{1}{2}]", 
                progress, 
                new string('#', completedLength), 
                new string(' ', remainingLength)
            );
            progress++;
            Thread.Sleep(5);
        }
        Console.WriteLine($"\n{message} {filename} data successful!!");
        Thread.Sleep(3000);
    }
}