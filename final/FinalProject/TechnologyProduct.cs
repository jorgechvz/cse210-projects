using System;
using Newtonsoft.Json;

public class TechnologyProduct : Product
{
    [JsonProperty("BrandProduct")]
    string _brandProduct {get;set;}

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
        throw new NotImplementedException();
    }
    public override float CalculatePrice()
    {
        throw new NotImplementedException();
    }
    public override bool CheckAvailability()
    {
        throw new NotImplementedException();
    }
    public override float CalculateDiscount()
    {
        throw new NotImplementedException();
    }
}