using System;

public class Square : Shape
{
    private int _side;
    
    public Square(string color, string shape, int side) : base(color, shape)
    {
        _side = side;
    }
    public override float GetArea()
    {
        return _side * _side;
    }
}