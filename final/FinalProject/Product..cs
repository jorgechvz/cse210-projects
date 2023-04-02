using System;
using Newtonsoft.Json;

public abstract class Product
{
    // Attributes
    [JsonProperty("ProductName")]
    private string _productName {get;set;}
    [JsonProperty("ProductPrice")]
    private float _productPrice {get;set;}
    [JsonProperty("ProductQuantity")]
    private int _productQuantity {get;set;}
    [JsonProperty("ProductCategory")]
    private string _productCategory {get;set;}

    // Constructor
    public Product(string productName, float productPrice, int productQuantity, string productCategory)
    {
        _productName = productName;
        _productPrice = productPrice;
        _productQuantity = productQuantity;
        _productCategory = productCategory;
    }

    // Getters and Setters
    public string GetProductName()
    {
        return _productName;
    }
    public void SetProductName(string  newProductName)
    {
        _productName = newProductName;
    }
    public float GetProductPrice()
    {
        return _productPrice;
    }
    public void SetProductPrice(float newProductPrice)
    {
        _productPrice = newProductPrice;
    }
    public int GetProductQuantity()
    {
        return _productQuantity;
    }
    public void SetProductQuantity(int newProductQuantity)
    {
        _productQuantity = newProductQuantity;
    }
    public string GetProductCategory()
    {
        return _productCategory;
    }
    public void SetProductCategory(string  newProductCategory)
    {
        _productCategory = newProductCategory;
    }

    // Abstract Methods
    public abstract void PrintInfoProduct();
    public abstract float CalculatePrice();
    public abstract bool CheckAvailability();
    public abstract float CalculateDiscount();
    public virtual void EditProduct()
    {
        Console.WriteLine("What do you want to edit?");
        Console.WriteLine(" 1. Product Name");
        Console.WriteLine(" 2. Product Price");
        Console.WriteLine(" 3. Product Quantity");  
    }

    public string IsAvalaible()
    {
        return CheckAvailability() ? "Yes" : "No";
    } 

}