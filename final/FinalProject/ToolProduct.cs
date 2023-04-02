using System;
using Newtonsoft.Json;

public class ToolProduct : Product
{
    // Attributes
    [JsonProperty("ToolType")]
    private string _toolType {get;set;}
    [JsonProperty("MaterialTool")]
    private string _material {get;set;}
    private List<string> _commonMaterials = new List<string>{"steel","stainless steel", "hardened steel"};

    // Constructor
    public ToolProduct(string productName, float productPrice, int productQuantity, string toolType, string material) : base (productName,productPrice,productQuantity,"Tool Product")
    {
        _toolType = toolType;
        _material = material;
    }

    // Getters and Setters
    public string GetToolType()
    {
        return _toolType;
    }
    public void SetToolType(string newToolType)
    {
        _toolType = newToolType;
    }
    public string GetMaterialTool()
    {
        return _material;
    }
    public void SetMaterialTool(string newMaterialTool)
    {
        _material = newMaterialTool;
    }

    // Override Methods
    public override void PrintInfoProduct()
    {
        Console.Write($"{GetProductName()} - Price: $ {GetProductPrice():F2} - Type: {_toolType} - Stock: {GetProductQuantity()} - Material: {_material}");
    }
    public override float CalculatePrice()
    {
        if (_commonMaterials.Contains(_material.ToLower())) // Check if the product's material is a common material
        {
            // Add a 10% increase to the product price for common materials
            float price = (GetProductPrice() * 0.1f) + GetProductPrice();
            // Calculate the total price based on quantity
            return price * GetProductQuantity();
        } else
        {
            return GetProductPrice() * GetProductQuantity(); // Calculate the total price based on quantity for non-common materials
        }
    }
    public override bool CheckAvailability()
    {
        // Check if the product's quantity is greater than 0
        if(GetProductQuantity() > 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
    public override float CalculateDiscount()
    {
        // Calculate the discount based on the quantity of the product
        if (GetProductQuantity() <= 15)
        {
            return GetProductPrice() * 0.5f;
        } else if (GetProductQuantity() <= 10)
        {
            return GetProductPrice() * 0.1f;
        } else {
            return 0f;
        }
    }
    public override void EditProduct()
    {
        base.EditProduct(); // Call the base class's EditProduct method to display the options for editing a product
        Console.WriteLine(" 4. Tool Type");
        Console.WriteLine(" 5. Tool Material");
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
                Console.Write("Enter a new tool type: ");
                string newType = Console.ReadLine();
                Console.WriteLine("The product has been edited successfully.");
                Thread.Sleep(3000);
                Console.Clear();
                SetToolType(newType);
                break;
            case "5":
                Console.Write("Enter a new tool material: ");
                string newMaterial = Console.ReadLine();
                SetMaterialTool(newMaterial);
                Console.WriteLine("The product has been edited successfully.");
                Thread.Sleep(3000);
                Console.Clear();
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
}