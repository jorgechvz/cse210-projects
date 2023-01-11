using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResult(name,square);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program");
    }
    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber(){
        Console.Write("Please enter your number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int SquareNumber(int number){
        int square = number * number;
        return square;
    }
    static void DisplayResult(string name, int square){
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
