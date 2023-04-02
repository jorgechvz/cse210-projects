using System;
using Newtonsoft.Json;

public class FoodProduct : Product
{
    // Attributes
    [JsonProperty("ProductionDate")]
    private DateTime _productionDate {get;set;}
    [JsonProperty("ExpirationDate")]
    private DateTime _expirationDate {get;set;}

    // Constructor
    public FoodProduct(string productName, float productPrice, int productQuantity, DateTime productionDate, DateTime expirationDate) : base (productName,productPrice,productQuantity,"Food Product")
    {
        _productionDate = productionDate;
        _expirationDate = expirationDate;
    }

    // Getters and Setters
    public DateTime GetProductionDate()
    {
        return _productionDate;
    }
    public void SetProductionDate(DateTime newProductionDate)
    {
        _productionDate = newProductionDate;      
    }
    public DateTime GetExpirationDate()
    {
        return _expirationDate;
    }
    public void SetExpirationDate(DateTime newExpirationDate)
    {
        _expirationDate = newExpirationDate;
    }
    
    // Override Methods
    public override void PrintInfoProduct()
    {
        Console.Write($"{GetProductName()} - Price: $ {GetProductPrice():F2} - Stock: {GetProductQuantity()} - Production Date: {_productionDate.ToShortDateString()} - Expiration Date: {_expirationDate.ToShortDateString()}");;
    }
    public override float CalculatePrice()
    {
        return GetProductPrice() * GetProductQuantity();
    }
    public override bool CheckAvailability()
    {
        if (GetProductQuantity() > 0 && _expirationDate >= DateTime.Today)
        {
            return true; // Return true if the food product is available (i.e., has quantity greater than 0 and has not yet expired)
        }
        else
        {
            return false; // Return false otherwise
        };
    }
    public override float CalculateDiscount()
    {
        TimeSpan lifespan = _expirationDate - _productionDate; // Calculate the lifespan of the food product (i.e., the time between its production and expiration dates)
        TimeSpan elapsed = DateTime.Now - _productionDate; // Calculate the elapsed time since the food product's production date
        float timePercentage = (float) elapsed.TotalSeconds / (float) lifespan.TotalSeconds; // Calculate the percentage of the food product's lifespan that has elapsed
        float discountPercentage = 0f; // Initialize the discount percentage to 0
        if (timePercentage > 0.5f) {
            discountPercentage = 0.1f; // If more than 50% of the food product's lifespan has elapsed, apply a 10% discount
        } else if (timePercentage > 0.25f) {
            discountPercentage = 0.05f; // If more than 25% of the food product's lifespan has elapsed, apply a 5% discount
        }
        float discountAmount = GetProductPrice() * discountPercentage; // Calculate the amount of the discount based on the discount percentage and the food product's price
        float discountedPrice = GetProductPrice() - discountAmount; // Calculate the discounted price of the food product
        return discountedPrice; // Return the discounted price
    }
    public override void EditProduct()
    {
        base.EditProduct(); // Call the base class's EditProduct method to display the options for editing a product
        Console.WriteLine(" 4. Production Date");
        Console.WriteLine(" 5. Expiration Date");
        Console.Write("Choose a option or type 'quit' to return menu: ");
        string optionEdit = Console.ReadLine().ToLower();
        switch (optionEdit)
        {
            case "1":
                Console.Write("Enter a new name: ");
                string newName = Console.ReadLine();
                base.SetProductName(newName);
                Console.WriteLine("The product has been edited successfully.");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "2":
                Console.Write("Enter a new price: ");
                float newPrice = float.Parse(Console.ReadLine());
                base.SetProductPrice(newPrice);
                Console.WriteLine("The product has been edited successfully.");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "3":
                Console.Write("Enter a new quantity: ");
                int newQuantity = int.Parse(Console.ReadLine());
                base.SetProductPrice(newQuantity);
                Console.WriteLine("The product has been edited successfully.");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "4":
                Console.Write("Enter a new production date (MM/dd/yyyy hh:mm:ss): ");
                DateTime newProductionDate = DateTime.Parse(Console.ReadLine());
                SetProductionDate(newProductionDate);
                Console.WriteLine("The product has been edited successfully.");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "5":
                Console.Write("Enter a new expiration date (MM/dd/yyyy hh:mm:ss): ");
                DateTime newExpirationDate = DateTime.Parse(Console.ReadLine());
                SetExpirationDate(newExpirationDate);
                Console.WriteLine("The product has been edited successfully.");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "quit":
                break;
            default: // Default case if an invalid option is selected
                Console.Write("\nInvalid option. Please try again.");
                Thread.Sleep(3000);
                Console.Clear();
                break;
        }
    }
}