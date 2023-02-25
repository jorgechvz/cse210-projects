using System;

public class ListingActivity : Activity
{
    // Atributtes
    private List<string> _promptsListing;
    private List<string> _answerListing;
    private List<string> _usedPromptsListing;

    // Constructor to set the name, description, prompts, answers of the activity
    public ListingActivity() : base("Listing Activity","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _promptsListing = new List<string>(){"Who are people that you appreciate?","What are personal strengths of yours?","Who are people that you have helped this week?","When have you felt the Holy Ghost this month?","Who are some of your personal heroes?"};
        _answerListing = new List<string>();
        _usedPromptsListing = new List<string>();
    }

    // Method to get a prompt for the activity
    public void GetListingActivity ()
    {
        Console.WriteLine("\nList a many responses you can to the following prompt: ");
        Console.WriteLine($"\n--- {CheckRandomPrompt(_promptsListing,_usedPromptsListing)} ---");
        StartActivityCounter(5,"You may begin in: ");
    }
    // This method prompts the user to enter a response and adds the response to a list of answers for a specific activity. 
    public void GetAnswerListingActivity()
    {
        Console.Write("> ");
        string answer = Console.ReadLine();
        _answerListing.Add(answer);
    }
    // Method to get the lenght to list of answers
    public int GetLenghtListOfAnswer()
    {
        return _answerListing.Count;
    }
}