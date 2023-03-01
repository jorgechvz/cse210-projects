
public class Rectangle : Shape
{
    private float _width;
    private float _length;

    public Rectangle(string color, string shape, float width, float length) : base(color, shape)
    {
        _width = width;
        _length = length;
    }
    public override float GetArea()
    {
        return _width * _length;
    }
}