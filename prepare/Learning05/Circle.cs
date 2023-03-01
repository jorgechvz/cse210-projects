using System;

public class Circle : Shape
{
    private float _radius;

    public Circle(string color, string shape, float radius) : base (color, shape)
    {
        _radius = radius;
    }
    public override float GetArea()
    {
        return Convert.ToSingle(Math.Round(((Math.PI) * Math.Pow(_radius, 2)),2));
    }
}