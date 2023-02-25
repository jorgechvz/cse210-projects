using System;

public class Activity
{
    //Atributtes
    private string _nameActivity;
    private string _descriptionActivity;
    private int _lengthTime;
    private List<string> _activityList = new List<string>();

    // Empty constructor
    public Activity(){}

    // Constructor to set the name and description of the activity
    public Activity(string nameActivity, string descriptionActivity){
        _nameActivity = nameActivity;
        _descriptionActivity = descriptionActivity;
    }

    // Getter to NameActivity
    public string GetNameActivity()
    {
        return _nameActivity;
    }

    // Method to initialize the activity and get the length of time from the user
    public int InitMessage(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_nameActivity}\n{_descriptionActivity}");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session: ");
        // Store the length of time entered by the user and return it
        return _lengthTime = int.Parse(Console.ReadLine());  
    }

    // Method to display a message at the end of the activity
    public void EndMessage(){
        Console.WriteLine("Well Done!!");
        DisplaySpinner(5);
        Console.WriteLine($"You have completed another {_lengthTime} seconds of the {_nameActivity}");
        DisplaySpinner(7);
        Console.Clear();
    }

    // Method to display a spinning animation while waiting for a certain time
    public void DisplaySpinner(int counter){
        // Define an array with the spinning characters 
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;
        while (counter > 0){
            // Move the cursor back one position and overwrite it with the next spinning character
            Console.Write($"\b{spinner[index]}");
            // Move to the next spinning character in the array
            index = (index + 1) % spinner.Length;
            // Wait for one second
            Thread.Sleep(1000); 
            counter--;
        }
        // Clear the spinning animation
        Console.WriteLine("\b \b");
    }

    // Method to start a counter and display a message
    public void StartActivityCounter(int counter, string message){
        while (counter > 0) {
            Console.Write($"\r{message}{counter}");
            Thread.Sleep(1000);
            counter--;
        }
        // Clear the counter
        Console.WriteLine("\b \b");
    }

    // Method to get a random prompt from a list of prompts
    public string GetRandomPrompt(List<string> listRandom)
    {
        Random random = new Random();
        int randomIndex = random.Next(listRandom.Count);
        return listRandom[randomIndex];
    }

    // Method to check if a prompt has already been used and get a new one if needed
    public string CheckRandomPrompt(List<string> listPrompt, List<string> listCheckPrompt)
    {
        string itemList = "";
        // Loop until all prompts have been used at least once
        while (listCheckPrompt.Count < listPrompt.Count)
        {
            // Get a random prompt from the list
            do 
            {
                itemList = GetRandomPrompt(listPrompt);
            } while (listCheckPrompt.Contains(itemList));// Add the prompt to the list of used prompts and return it
            listCheckPrompt.Add(itemList);
            return itemList;
        }
        // If all prompts have been used, clear the list of used prompts and get a new random prompt
        listCheckPrompt.Clear();
        return GetRandomPrompt(listPrompt);
    }
    
    // Method to Add items in Activity List
    public void AddActivityList(string activityName)
    {
        _activityList.Add(activityName);
    }
    // Method to Display Activity's Report
    public void DisplayActivityReport()
    {   
        if (_activityList.Count != 0){
            Console.Write("\nGenerating your report... ");
            DisplaySpinner(5);
            Console.Clear();
            Console.WriteLine("Report generated.");
            Console.WriteLine("\nYour Activity's Report\n");
            // Group the activities by type using GroupBy()
            var itemList = _activityList.GroupBy(s => s);
            // Iterate over each group and print the number of times the activity was done
            foreach (var group in itemList)
            {
                Console.WriteLine($" > You did the {group.Key} {group.Count()} times.");
            }
            // Calculate the total number of activities and print it
            int totalActivity = itemList.Sum(g => g.Count());
            Console.WriteLine($"\nYou did a total of {totalActivity} activities.\nWell done!!");
        }
        else{
            Console.WriteLine("You haven't done any activity yet.");
        }
    }
}
/* For "Shows creativity and exceeds core requirements", I have generated 3 methods, the first method is "CheckRandomPrompt". This method has the responsibility of verifying that prompts such as questions are not repeated until they have all been used. When all have been used, the prompts or questions are generated again. The second method called "AddActivityList" is responsible for adding to a list the names of the activities that the user has carried out.
And the last method called "DisplayActivityReport" is a method to show the report of the activities carried out by the user. It shows how many times the user has done each activity and also the total of all the activities he has done. */