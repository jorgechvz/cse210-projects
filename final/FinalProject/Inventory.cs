using System;
using Newtonsoft.Json;

public class Inventory
{
    private List<Product> _listProducts;
    public Inventory()
    {
        _listProducts = new List<Product>();
    }
    public List<Product> GetListProducts()
    {
        return _listProducts;
    }
    public void SetListProducts(List<Product> newListProduct)
    {
        _listProducts = newListProduct;
    }
    public void AddProduct(Product product)
    {
        _listProducts.Add(product);
    }
    public void EditProduct()
    {
        try
        {
            if(_listProducts.Count != 0)
            {
                GetProducts(_listProducts);
                Console.Write("\nPlease choose a product that you want to edit: ");
                int chooseProduct = int.Parse(Console.ReadLine());
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
            Console.WriteLine("");
            string category = Console.ReadLine().ToLower();
            switch (category)
            {
                case "1":
                    Console.WriteLine("What is the product name: ");
                    string foodProductName = Console.ReadLine();
                    Console.WriteLine("What is the product price: ");
                    float foodProductPrice = float.Parse(Console.ReadLine());
                    Console.WriteLine("What is the product quantity: ");
                    int foodProductQuantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the production date (MM/dd/yyyy hh:mm:ss): ");
                    DateTime foodProductionDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("What is the expiration date (MM/dd/yyyy hh:mm:ss): ");
                    DateTime foodExpirationDate = DateTime.Parse(Console.ReadLine());
                    FoodProduct foodProduct = new FoodProduct(foodProductName,foodProductPrice,foodProductQuantity,foodProductionDate,foodExpirationDate);
                    AddProduct(foodProduct);
                    break;
                case "2":
                    Console.WriteLine("What is the product name: ");
                    string clothingProductName = Console.ReadLine();
                    Console.WriteLine("What is the product price: ");
                    float clothingProductPrice = float.Parse(Console.ReadLine());
                    Console.WriteLine("What is the product quantity: ");
                    int clothingProductQuantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the product size: ");
                    string clothingProductSize = Console.ReadLine();
                    Console.WriteLine("What is the product material: ");
                    string clothingProductMaterial = Console.ReadLine();
                    ClothingProduct clothingProduct = new ClothingProduct(clothingProductName,clothingProductPrice,clothingProductQuantity,clothingProductSize,clothingProductMaterial);
                    AddProduct(clothingProduct);
                    break;
                case "3":
                    Console.WriteLine("What is the product name: ");
                    string toolProductName = Console.ReadLine();
                    Console.WriteLine("What is the product price: ");
                    float toolProductPrice = float.Parse(Console.ReadLine());
                    Console.WriteLine("What is the product quantity: ");
                    int toolProductQuantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the tool type: ");
                    string toolType = Console.ReadLine();
                    Console.WriteLine("What is the product material: ");
                    string toolProductMaterial = Console.ReadLine();
                    ToolProduct toolProduct = new ToolProduct(toolProductName,toolProductPrice,toolProductQuantity,toolType,toolProductMaterial);
                    AddProduct(toolProduct);
                    break;
                case "4":
                    Console.WriteLine("What is the product name: ");
                    string technologyProductName = Console.ReadLine();
                    Console.WriteLine("What is the product price: ");
                    float technologyProductPrice = float.Parse(Console.ReadLine());
                    Console.WriteLine("What is the product quantity: ");
                    int technologyProductQuantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the product brand: ");
                    string technologyProductBrand = Console.ReadLine();
                    TechnologyProduct technologyProduct = new TechnologyProduct(technologyProductName,technologyProductPrice,technologyProductQuantity,technologyProductBrand);
                    AddProduct(technologyProduct);
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
                Console.WriteLine("Choose the product to remove:\n");
                for (int i = 0; i<product.Count; i++)
                {
                    Console.WriteLine($" {i+1}. {product[i].PrintInfoProduct}");
                }
                Console.WriteLine("Choose a product: ");
                int productChoice = int.Parse(Console.ReadLine());
                product.RemoveAt(productChoice-1);
                Console.WriteLine("\nProduct removed successfully");
                Thread.Sleep(3000);
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
                int countProductIndex = 0;
                foreach(Product productItem in product)
                {
                    countProductIndex++;
                    Console.WriteLine($" {countProductIndex}. {productItem.GetProductName()} - Category: {productItem.GetProductCategory()} - Quantity: {productItem.GetProductQuantity()}");
                }
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
                Console.Write("\nWhich category of product would you like to see? or write 'quit' to return Menu: ");
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
            Console.WriteLine("You don't have products yet, please add products");
            Thread.Sleep(3000);
        }
        static void PrintProductsByCategory(List<Product> products, string category)
        {
            bool exitProductCategory = false;
            for (int i=0; i < products.Count; i++)
            {
               if (products[i].GetType().Name == category)
                {    
                    exitProductCategory = true;
                    Console.WriteLine($" {i+1}. {products[i].GetProductName()}");
                }
                if(!exitProductCategory)
                {
                    Console.WriteLine("You don't have Products for this category yet.");
                }
                Console.Write("\nPress enter to return to menu... ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    public void GetProductsByPriceAscending(List<Product> product)
    {
        List<Product> sortedProduct = product.OrderBy(p => p.GetProductPrice()).ToList();
        foreach (Product productItem in sortedProduct)
        {
            Console.WriteLine($"{productItem.GetProductName()} Price: {productItem.GetProductPrice()}");
        }
    }
    public void GetProductsByPriceDescending(List<Product> product)
    {
        List<Product> sortedProduct = product.OrderByDescending(p => p.GetProductPrice()).ToList();
        foreach (Product productItem in sortedProduct)
        {
            Console.WriteLine($"{productItem.GetProductName()} Price: {productItem.GetProductPrice()}");
        }
    }
    public void SaveInventoryData(List<Product> products, Inventory inventory)
    {

    }
    public List<Product> LoadInventoryData(string filename)
    {
        return _listProducts;
    }
}