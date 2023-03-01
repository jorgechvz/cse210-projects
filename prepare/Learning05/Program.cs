using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red","Square",4);
        // Test Square
        /* Console.WriteLine(square.GetShape());
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea()); */

        Circle circle = new Circle("Black","Circle", 4);
        /* Test Circle 
        Console.WriteLine(circle.GetShape());
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea()); */

        Rectangle rectangle = new Rectangle("Green","Rectangle", 4, 6);
        /* Test Rectangle 
        Console.WriteLine(rectangle.GetShape());
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea()); */

        List<Shape> shape = new List<Shape>();
        shape.Add(square);
        shape.Add(circle);
        shape.Add(rectangle);
        foreach (Shape shapeItem in shape)
        {
            Console.WriteLine($"The {shapeItem.GetShape()} with color {shapeItem.GetColor()} has an area of {shapeItem.GetArea()}");
        }

    }
}