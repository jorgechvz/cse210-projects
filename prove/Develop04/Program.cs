using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {   
        // Instances of Stopwatch, Activity and Activity subclasses
        Stopwatch _stopwatch = Stopwatch.StartNew();
        Activity _activity = new Activity();
        BreathingActivity _breathingActivity = new BreathingActivity();
        ReflectingActivity _reflectingActivity = new ReflectingActivity();
        ListingActivity _listingActivity = new ListingActivity();
        bool exit = false;
        while (exit == false)
        {
            Console.WriteLine("Welcome to Mindfulness Program\n");
            Console.WriteLine(" 1. Start Breathing Activity");
            Console.WriteLine(" 2. Start Reflecting Activity");
            Console.WriteLine(" 3. Start Listing Activity");
            Console.WriteLine(" 4. Activity's Report");
            Console.WriteLine(" 5. Quit");
            Console.Write("\nPlease choose a option: ");
            int _option = int.Parse(Console.ReadLine());
            switch(_option)
            {
                case 1: // Breathing Activity
                    _activity.AddActivityList(_breathingActivity.GetNameActivity());
                    int inputValueBreathing = _breathingActivity.InitMessage();
                    Console.Clear();
                    Console.WriteLine("Get ready...");
                    _breathingActivity.DisplaySpinner(5);
                    // Reset stopwatch
                    _stopwatch.Restart();
                    // Check that the time is less than the value entered by the user 
                    while (_stopwatch.Elapsed < TimeSpan.FromSeconds(inputValueBreathing))
                    { 
                        _breathingActivity.BreathIn();
                        _breathingActivity.BreathOut();
                        Console.WriteLine();
                        Thread.Sleep(1000);
                    }
                    _breathingActivity.EndMessage();
                    break;
                case 2: // Reflecting Activity
                    _activity.AddActivityList(_reflectingActivity.GetNameActivity());
                    int inputValueReflecting = _reflectingActivity.InitMessage();
                    Console.Clear();
                    Console.WriteLine("Get ready...");
                    _reflectingActivity.DisplaySpinner(5);
                    _reflectingActivity.GetPromptReflecting();
                    Console.Clear();
                    _stopwatch.Restart();
                    // Check that the time is less than the value entered by the user
                    while (_stopwatch.Elapsed < TimeSpan.FromSeconds(inputValueReflecting))
                    {
                        Console.Write($"{_reflectingActivity.GetQuestionsReflecting()} ");
                        _reflectingActivity.DisplaySpinner(5);
                    }
                    Console.WriteLine();
                    _reflectingActivity.EndMessage();
                    break;
                case 3: // Listing Activity
                    _activity.AddActivityList(_listingActivity.GetNameActivity());
                    int inputValueListing = _listingActivity.InitMessage();
                    Console.Clear();
                    Console.WriteLine("Get ready...");
                    _listingActivity.DisplaySpinner(5);
                    _listingActivity.GetListingActivity();
                    _stopwatch.Restart();
                    // Check that the time is less than the value entered by the user
                    while (_stopwatch.Elapsed < TimeSpan.FromSeconds(inputValueListing))
                    {
                        _listingActivity.GetAnswerListingActivity();
                    }
                    Console.WriteLine($"You listed {_listingActivity.GetLenghtListOfAnswer()} items!");
                    Console.WriteLine();
                    _listingActivity.EndMessage();
                    break;
                case 4: // Activity's Report
                    Console.Clear();
                    _activity.DisplayActivityReport();
                    Console.Write("\nPress enter to return to menu... ");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5: // Option to exit the game
                    Console.WriteLine("Thanks for used the program!!");
                    return;
                default: // Default case if an invalid option is selected
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Thread.Sleep(3000);
                    Console.Clear();
                    break;
            }
        }
    }
}