using System;

class Program
{
    static void Main(string[] args)
    {
        /* We created the instance for the program */
        Journal _journal = new Journal();
        PromptGenerator _promptGenerator = new PromptGenerator();
        SaveJournal _saveJournal = new SaveJournal();

        /* We create a loop for the user's option. */
        while (true)
        {
            /* We create a Journal's menu */
            
            Console.WriteLine("\nWelcome to Journal Program");
            Console.WriteLine();
            Console.WriteLine("1. Write Journal: ");
            Console.WriteLine("2. Read Journal: ");
            Console.WriteLine("3. Save Journal: ");
            Console.WriteLine("4. Load Journal: ");
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
                    Console.Write("Please write the filename: (e.g. journal.txt)");
                    string _filenameSave = Console.ReadLine();
                    _saveJournal.Save(_journal,_filenameSave);
                    break;
                case 4:
                    Console.Write("Please write the filename: (e.g. journal.txt)");
                    string _filenameLoad = Console.ReadLine();
                    break;
                case 5: 
                    return;
                /* If the user enter a incorrect option */
                default:
                    Console.WriteLine("Please choose a correct option");
                    break;
            }
        }
    }
}