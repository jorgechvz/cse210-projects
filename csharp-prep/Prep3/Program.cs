using System;

class Program
{
    static void Main(string[] args)
    {
        string again = "yes";
        while (again == "yes")
        {
            Random randomGenerator = new Random();
            int magic = randomGenerator.Next(1,100); 
            Console.WriteLine($"What is your magic number?: {magic}");
            int guess = -1;
            int attempt = 0;
            while (magic != guess)
            {
                Console.Write("What is your guess?: ");
                guess = int.Parse(Console.ReadLine());
                if (magic < guess){
                    Console.WriteLine("Higher");
                }
                else if (magic > guess){
                    Console.WriteLine("Lower");
                }
                else if (magic == guess){
                    Console.WriteLine("You guessed it!");
                }
                attempt++;
            }
            Console.WriteLine($"I take you {attempt} guesses.");
            Console.Write("Do you want to play again? (yes or no): ");
            again = Console.ReadLine();
            Console.Clear();
        }   
    }   
}