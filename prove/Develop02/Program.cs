using System;

class Program
{
    static void Main(string[] args)
    {
        /* We created the instance for the program */
        Journal _journal = new Journal();
        PromptGenerator _promptGenerator = new PromptGenerator();
        SaveJournal _saveJournal = new SaveJournal();
        LoadJournal _loadJournal = new LoadJournal();

        bool exit = false;

        /* We create a loop for the user's option. */
        while (exit != true)
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
                    Console.WriteLine("Prompt: "+ prompt);
                    Console.Write("Your answer: ");
                    string userResponse = Console.ReadLine();
                    _journal.AddEntry(prompt,userResponse);
                    Console.WriteLine("\nThanks for the answer!");
                    Thread.Sleep(2500);
                    Console.Clear();
                    break;
                case 2:
                    _journal.Display();
                    Console.WriteLine("\nPlease press any key to return to menu");
                    Console.ReadKey();
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                case 3: 
                    Console.Write("Please write the filename: (e.g. journal.txt)");
                    string _filenameSave = Console.ReadLine();
                    _saveJournal.Save(_journal,_filenameSave);
                    ProgressBar();
                    break;
                case 4:
                    Console.Write("Please write the filename: (e.g. journal.txt)");
                    string _filenameLoad = Console.ReadLine();
                    _journal = _loadJournal.Load(_filenameLoad);
                    ProgressBar();
                    break;
                case 5: 
                    exit = true;
                    return;
            }
        }

        /* Function to do a ProgressBar */
        static void ProgressBar(){
            int progress = 0;
            int total = 100;
            while (progress <= total) {
                //Display Progress Bar
                Console.Write("\r{0}% [{1}{2}]", progress, new string('#', progress), new string(' ', total - progress));
                progress++;
                Thread.Sleep(5);
            }
            Console.WriteLine("\nUpdated File!");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
