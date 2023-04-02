using System;
using Newtonsoft.Json;

public class ClothingProduct : Product
{
    // Attributes
    [JsonProperty("SizeClothes")]
    private string _sizeClothes {get;set;}
    [JsonProperty("MaterialClothes")]
    private string _materialClothes {get;set;}
    private List<string> _popularMaterialClothes = new List<string>{"cotton","suede","gauze","wool","silk"};
    private float _materialCost;

    // Constructor
    public ClothingProduct(string productName, float productPrice, int productQuantity, string sizeClothes, string materialClothes) : base (productName,productPrice,productQuantity,"Clothing Product")
    {
        _sizeClothes = sizeClothes;
        _materialClothes = materialClothes;
        _materialCost = 0;
    }

    // Getters and Setters
    public string GetSizeClothes()
    {
        return _sizeClothes;
    }
    public void SetSizeClothes(string newSizeClothes)
    {
        _sizeClothes = newSizeClothes;
    }
    public string GetMaterialClothes()
    {
        return _materialClothes;
    }
    public void SetMaterialClothes(string newMaterialClothes)
    {
        _materialClothes = newMaterialClothes;
    }
    public float GetMaterialCost()
    {
        return _materialCost;
    }

    // Override Methods
    public override void PrintInfoProduct()
    {
        Console.Write($"{GetProductName()} - Price: $ {GetProductPrice():F2} - Size: {_sizeClothes} - Stock: {GetProductQuantity()} - Material: {_materialClothes}");
    }
    public override float CalculatePrice()
    {
        // Check if the material of the clothes is popular
        if (_popularMaterialClothes.Contains(_materialClothes.ToLower()))
        {
            // Calculate the cost of material
            _materialCost = (GetProductPrice() * 0.15f);
            return (_materialCost + GetProductPrice()) * GetProductQuantity(); // Calculate the total price including material cost
        } else 
        {
            // Calculate the total price without material cost
            return GetProductPrice() * GetProductQuantity();
        }
    }
    public override bool CheckAvailability()
    {
        // Check if the product quantity is greater than 0 
        if (GetProductQuantity() > 0)
        {
            return true;
        } else 
        {
            return false;
        }
    }
    public override float CalculateDiscount()
    {
        // Check if the material of the clothes is popular and if the product quantity is less than 10
        if (_popularMaterialClothes.Contains(_materialClothes.ToLower()) && GetProductQuantity() < 10)
        {
            // Calculate the discount
            float discount = GetProductPrice() * 0.1f;
            return discount;
        } else 
        {
            return 0f;
        }
    }
    public override void EditProduct()
    {
        base.EditProduct(); // Call the base class's EditProduct method to display the options for editing a product
        Console.WriteLine(" 4. Size");
        Console.WriteLine(" 5. Material");
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
                string newSize = Console.ReadLine();
                SetSizeClothes(newSize);
                Console.WriteLine("The product has been edited successfully.");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            case "5":
                Console.Write("Enter a new material: ");
                string newMaterial = Console.ReadLine();
                SetMaterialClothes(newMaterial);
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