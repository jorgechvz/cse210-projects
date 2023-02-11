using System;
class Program
{
    static void Main(string[] args){
        // Create a instance for the LibraryOfScripture
        LibraryOfScriptures _dictionaryScripture = new LibraryOfScriptures();
        bool exit = false;
        // Loop for the menu
        while (exit == false){
            Console.WriteLine("Welcome to Scripture Memorizer\n");
            Console.WriteLine("1. Add Scriptures: ");
            Console.WriteLine("2. Start Game (selected scripture): ");
            Console.WriteLine("3. Start Game (random scripture): ");
            Console.WriteLine("4. View Scriptures: ");
            Console.WriteLine("5. Exit Game: ");
            Console.Write("Please choose a option: ");
            int _option = int.Parse(Console.ReadLine());
            switch (_option){
                //Add new scripture option
                case 1:
                    Console.Write("\nEnter a Book: ");
                    string book = Console.ReadLine();
                    Console.Write("Enter a Chapter: ");
                    int chapter = int.Parse(Console.ReadLine());
                    Console.Write("Enter a Verse: ");
                    int verse = int.Parse(Console.ReadLine());
                    Console.Write("Enter a End Verse(Optional, Press enter if there is no end verse): ");
                    string endVerseInput = Console.ReadLine();
                    int? endVerse = null;
                    // Check if the user entered a final verse or not
                    if (!string.IsNullOrEmpty(endVerseInput))
                    {
                        endVerse = int.Parse(endVerseInput);
                    }
                    Console.Write("Enter a scripture: ");
                    string scripture = Console.ReadLine();
                    // Add the scripture in the list with the method AddScripture
                    _dictionaryScripture.AddScripture(book,chapter,verse,endVerse,scripture);
                    Console.Clear();
                    break;
                // Start the game with a selected scripture
                case 2:
                    Console.WriteLine();
                    _dictionaryScripture.DisplayScriptures();
                    // Get the lenght list
                    int _numberOfScriptures = 
                    _dictionaryScripture.GetNumberOfScriptures();
                    // Check if the length of the scripture list is greater than 0
                    if (_numberOfScriptures > 0){
                        Console.Write("\nPlease enter the Scripture ID that you want to memorizer: ");
                        int _selectedScripture = int.Parse(Console.ReadLine());
                        Console.Clear();
                        var _scriptureId = _dictionaryScripture.GetScripturyById(_selectedScripture);
                        // If there is no end verse specified, create a reference with just the book, chapter, and verse
                        if(_scriptureId != null){
                            Reference _reference;
                            if(_scriptureId["endVerse"] == null){
                                _reference = new Reference((string)_scriptureId["book"],(int)_scriptureId["chapter"],(int)_scriptureId["verse"]);
                            }else// if there is an end verse specified, create a reference with the book, chapter, verse, and end verse
                            {
                                _reference = new Reference((string)_scriptureId["book"],(int)_scriptureId["chapter"],(int)_scriptureId["verse"],(int)_scriptureId["endVerse"]);
                            }
                            Scripture _scripture1 = new Scripture(_reference,(string)_scriptureId["scripture"]);
                            // Start the game with the selected scripture
                            Console.WriteLine(_scripture1.DisplayScripture());
                            Console.Write("\nPress enter to hide words, or type 'quit' to return the menu: ");
                            string input1 = Console.ReadLine();
                            while (input1 != "quit")
                            {
                                Console.Clear();
                                _scripture1.HideWords();
                                Console.WriteLine(_scripture1.DisplayScriptureHidden());
                                Console.Write("\nPress enter to hide more words, or type 'quit' to return the menu: ");
                                input1 = Console.ReadLine();
                                if (_scripture1.IsCompletelyHidden()){
                                    Console.WriteLine("\nCongratulations, you have memorized the scripture!");
                                    break;
                                }
                                if (input1 == "quit"){
                                    Console.Clear();
                                    break;
                                }
                            } 
                        }
                    }
                    Thread.Sleep(4000);
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    // Get a random scripture in the list
                    var randomScripture = _dictionaryScripture.RandomScripture();
                    // Check if the randomScripture the value is diferent to null
                    if (randomScripture != null){
                        Reference reference = (Reference)randomScripture["reference"];
                        Scripture _scripture1 = new Scripture(reference,(string)randomScripture["scripture"]);
                        // Start the game with the random scripture
                        Console.WriteLine(_scripture1.DisplayScripture());
                        Console.WriteLine("\nPress enter to hide words, or type 'quit' to end the program:");
                        string input1 = Console.ReadLine();
                        while (input1 != "quit")
                        {
                            Console.Clear();
                            _scripture1.HideWords();
                            Console.WriteLine(_scripture1.DisplayScriptureHidden());
                            Console.WriteLine("\nPress enter to hide more words, or type 'quit' to end the program:");
                            input1 = Console.ReadLine();
                            if (_scripture1.IsCompletelyHidden()){
                                Console.WriteLine("\nCongratulations, you have memorized the scripture!");
                                break;
                            }
                            if (input1 == "quit"){
                                break;
                            }
                        } 
                    }
                    Thread.Sleep(4000);
                    Console.Clear();
                    break;
                // Option to view the list of scriptures
                case 4:
                    Console.Clear();
                    _dictionaryScripture.DisplayScriptures();
                    Console.WriteLine("Please press any key to return to menu");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                // Option to exit the game
                case 5:
                    exit = true;
                    return;
                // Default case if an invalid option is selected
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
            }
        }
    }
}