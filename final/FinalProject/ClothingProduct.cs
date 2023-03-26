using System;
using Newtonsoft.Json;

public class ClothingProduct : Product
{
    [JsonProperty("SizeClothes")]
    private string _sizeClothes {get;set;}
    [JsonProperty("MaterialClothes")]
    private string _materialClothes {get;set;}

    public ClothingProduct(string productName, float productPrice, int productQuantity, string sizeClothes, string materialClothes) : base (productName,productPrice,productQuantity,"Clothing Product")
    {
        _sizeClothes = sizeClothes;
        _materialClothes = materialClothes;
    }
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