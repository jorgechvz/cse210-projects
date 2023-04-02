using System;
using Newtonsoft.Json;

public class TechnologyProduct : Product
{
    // Attributes
    [JsonProperty("BrandProduct")]
    string _brandProduct {get;set;}

    // Constructor
    public TechnologyProduct(string productName, float productPrice, int productQuantity, string brandProduct) : base(productName,productPrice,productQuantity,"Technology Product")
    {
        _brandProduct = brandProduct;
    }

    // Getter and Setter
    public string GetBrandProduct()
    {
        return _brandProduct;
    }
    public void SetBrandProduct(string newBrandProduct)
    {
        _brandProduct = newBrandProduct;
    }

    // Override Methods
    public override void PrintInfoProduct()
    {
        Console.Write($"{GetProductName()} - Brand: {_brandProduct} - Price: $ {GetProductPrice():F2} - Stock: {GetProductQuantity()}");
    }
    public override float CalculatePrice()
    {
        // Calculate the total price
        return GetProductPrice() * GetProductQuantity();
    }
    public override bool CheckAvailability()
    {
        return GetProductQuantity() > 0; // Return true if the Quantity is greater 0
    }
    public override float CalculateDiscount()
    {
        return 0;
    }
    public override void EditProduct()
    {
        base.EditProduct(); // Call the base class's EditProduct method to display the options for editing a product
        Console.WriteLine(" 4. Brand");
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
                Console.Write("Enter a new size: ");
                string newBrand = Console.ReadLine();
                SetBrandProduct(newBrand);
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