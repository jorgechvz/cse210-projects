using System;
using Newtonsoft.Json;

public class FoodProduct : Product
{
    // Attributes
    [JsonProperty("ProductionDate")]
    private DateTime _productionDate {get;set;}
    [JsonProperty("ExpirationDate")]
    private DateTime _expirationDate {get;set;}

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