using System;

class Program
{
    static void Main(string[] args)
    {
        /* We created the instance for the program */
        Journal _journal = new Journal();
        PromptGenerator _promptGenerator = new PromptGenerator();


        /* We create a loop for the user's option. */
        while (true)
        {
            /* We create a Journal's menu */
            
            Console.WriteLine("\nWelcome to Journal Program");
            Console.WriteLine();
            Console.WriteLine("1. Write Journal: ");
            Console.WriteLine("2. Read Journal: ");
            Console.WriteLine("3. Load Journal: ");
            Console.WriteLine("4. Save Journal: ");
            Console.WriteLine("5. Exit Journal: ");
            Console.Write("Please choose a option: ");
            int _option = int.Parse(Console.ReadLine());

            switch (_option){
                case 1:
                    string prompt = _promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("\nYour answer: ");
                    string userResponse = Console.ReadLine();
                    _journal.AddEntry(prompt,userResponse);
                    break;
                case 2:
                    _journal.Display();
                    break;
                case 3: 
                    break;
                case 4:
                    break;
                case 5: 
                    return;
                default:
                    Console.WriteLine("Please choose a correct option");
                    break;
            }
        }
    }
}