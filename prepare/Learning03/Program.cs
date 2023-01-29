using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        Fraction _fraction1 = new Fraction();
        Fraction _fraction2 = new Fraction(5);
        Fraction _fraction3 = new Fraction(3,4);
        Fraction _fraction4 = new Fraction(1,3);
        Console.WriteLine(_fraction3.GetFractionString());
        Console.WriteLine(_fraction1.GetFractionString());
        Console.WriteLine(_fraction2.GetFractionString());
        Console.WriteLine(_fraction4.GetFractionString());
        Console.WriteLine(_fraction3.GetDecimalValue());
        Console.WriteLine(_fraction1.GetDecimalValue());
        Console.WriteLine(_fraction2.GetDecimalValue());
        Console.WriteLine(_fraction4.GetDecimalValue());

    }
}