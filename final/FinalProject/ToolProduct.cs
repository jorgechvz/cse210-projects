using System;
using Newtonsoft.Json;

public class ToolProduct : Product
{
    [JsonProperty("ToolType")]
    private string _toolType {get;set;}
    [JsonProperty("MaterialTool")]
    private string _material {get;set;}

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