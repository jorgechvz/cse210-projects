using System;
using Newtonsoft.Json;

public class GoalsManager
{
    // Attributes
    private List<Goal> _goalsList;
    // Attribute to stored the Points Accumulated of a goal remove
    [JsonProperty("RemovePoints")]
    private float _removePoints {get; set;}
    // Constructor for GoalsManager
    public GoalsManager()
    {
        _goalsList = new List<Goal>();
        _removePoints = 0;
    }
    // Get and Set for _goalsList attribute
    public List<Goal> GetListGoal()
    {
        return _goalsList;
    }
    public void SetListGoal(List<Goal> goalsList)
    {
        _goalsList = goalsList;
    }
    public float GetRemovePoints()
    {
        return _removePoints;
    }
    public void SetRemovePoints(float remove)
    {
        _removePoints = remove;
    }
    // Method to Add goals in List
    public void AddGoal(Goal goal)
    {
        _goalsList.Add(goal);
    }
    // Method to Display All Goals in List
    public void DisplayGoals(List<Goal> goal)
    {
        if (goal.Count != 0)
        {
            Console.Clear();
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Your Goals\n");
                Console.WriteLine(" 1. Simple Goal");
                Console.WriteLine(" 2. Eternal Goal");
                Console.WriteLine(" 3. Checklist Goal");
                Console.WriteLine(" 4. All Goals");
                Console.Write("\nChoose a option or write 'quit' to return menu: ");
                string _option = Console.ReadLine().ToLower();
                switch (_option)
                {
                    case "1": // Display only Simple Goals
                        Console.Clear();
                        Console.WriteLine($"Your Simple Goals\n");
                        int countSimple = 0;
                        bool simpleGoalsExist = false;
                        foreach(Goal goals in goal)
                        {
                            if(goals is SimpleGoal) // "If" to verify if goals is a SimpleGoal
                            {
                                countSimple++;
                                simpleGoalsExist = true;
                                Console.WriteLine($"{countSimple}. {goals.GetStatus()} {goals.GetNameOfGoal()} ({goals.GetDescriptionOfGoal()})");
                            }
                        }
                        if (!simpleGoalsExist)
                        {
                            Console.WriteLine("You don't have any Simple Goals yet.");
                        }
                        Console.Write("\nPress enter to return to menu... ");
                        Console.ReadKey();
                        Console.Clear();
                        exitMenu = false;
                        break;
                    case "2": // Display only Eternal Goals
                        Console.Clear();    
                        Console.WriteLine($"Your Eternal Goals\n");
                        bool eternalGoalsExist = false;
                        int countEternal = 0;
                        foreach(Goal goals in goal)
                        {
                            if(goals is EternalGoal eternalGoal) // "If" to verify if goals is a EternalGoal
                            {
                                countEternal++;
                                eternalGoalsExist = true;
                                Console.WriteLine($"{countEternal}. {goals.GetStatus()} {goals.GetNameOfGoal()} ({goals.GetDescriptionOfGoal()}) -- Attempts made: {eternalGoal.GetNumberOfAttempts()}");
                                exitMenu = false;
                            }
                        }
                        if (!eternalGoalsExist)
                        {
                            Console.WriteLine("You don't have any Eternal Goals yet.");
                        }
                        Console.Write("\nPress enter to return to menu... ");
                        Console.ReadKey();
                        Console.Clear();
                        exitMenu = false;
                        break;
                    case "3": // Display only Checklist Goals
                        Console.Clear();
                        Console.WriteLine($"Your Checklist Goals\n");
                        int countCheck = 0;
                        bool checkGoalsExist = false;
                        foreach(Goal goals in goal)
                        {
                            if(goals is ChecklistGoal checklistGoal) // "If" to verify if goals is a ChecklistGoal
                            {
                                countCheck++;
                                checkGoalsExist = true;
                                Console.WriteLine($"{countCheck}. {goals.GetStatus()} {goals.GetNameOfGoal()} ({goals.GetDescriptionOfGoal()}) -- Currently completed: {checklistGoal.GetAttemptGoals()}/{checklistGoal.GetNumRequieredGoals()}");
                            }
                        }
                        if (!checkGoalsExist)
                        {
                            Console.WriteLine("You don't have any Checklist Goals yet.");
                        }
                        Console.Write("\nPress enter to return to menu... ");
                        Console.ReadKey();
                        Console.Clear();
                        exitMenu = false;
                        break;
                    case "4": // Display only All Goals
                        Console.Clear();
                        Console.WriteLine("Your Goals\n");
                        int countAllGoals = 0;
                        foreach(Goal goals in goal)
                        {
                            if (goals is ChecklistGoal checklistGoalAll)
                            {
                                countAllGoals++;
                                Console.WriteLine($"{countAllGoals}. {goals.GetStatus()} {goals.GetNameKinfOfGoal()}: {goals.GetNameOfGoal()} ({goals.GetDescriptionOfGoal()}) -- Currently completed: {checklistGoalAll.GetAttemptGoals()}/{checklistGoalAll.GetNumRequieredGoals()}");
                            } else if(goals is EternalGoal eternalGoal){
                                countAllGoals++;
                                Console.WriteLine($"{countAllGoals}. {goals.GetStatus()} {goals.GetNameKinfOfGoal()}: {goals.GetNameOfGoal()} ({goals.GetDescriptionOfGoal()}) -- Attempts made: {eternalGoal.GetNumberOfAttempts()}");
                            }
                            else {
                                countAllGoals++;
                                Console.WriteLine($"{countAllGoals}. {goals.GetStatus()} {goals.GetNameKinfOfGoal()}: {goals.GetNameOfGoal()} ({goals.GetDescriptionOfGoal()})");
                            }
                        }
                        Console.Write("\nPress enter to return to menu... ");
                        Console.ReadKey();
                        Console.Clear();
                        exitMenu = false;
                        break;
                    case "quit":
                        exitMenu = true;
                        Console.Clear();
                        break;
                    default: // Default case if an invalid option is selected
                        Console.WriteLine("\nInvalid option. Please try again.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                }
            } 
        } else
        {
            Console.WriteLine("You don't have goals yet, please add goals");
            Thread.Sleep(3000);
        }
    }
    // Method to create a new Goal
    public void CreateNewGoal()
    {
        try
        {
            Console.WriteLine("The type of Goals are:\n");
            Console.WriteLine(" 1. Simple Goal");
            Console.WriteLine(" 2. Eternal Goal");
            Console.WriteLine(" 3. Checklist Goal");
            Console.Write("\nWhich type of goal would you like to create? or write 'quit' to return Menu: ");
            string type = Console.ReadLine().ToLower();
            switch (type)
            {
                case "1": // Create a new Simple Goal
                    Console.Write("\nWhat is the name of your goal?: ");
                    string _nameGoalSimple = Console.ReadLine();
                    Console.Write("What is a short description of it?: ");
                    string _descriptioGoalSimple = Console.ReadLine();
                    Console.Write("Whats is th amount of points associated with this goal?: ");
                    int _pointsGoalsSimple = int.Parse(Console.ReadLine());
                    SimpleGoal listGoal = new SimpleGoal(_nameGoalSimple,_descriptioGoalSimple,_pointsGoalsSimple);
                    AddGoal(listGoal);
                    break;
                case "2": // Create a new Eternal Goal
                    Console.Write("What is the name of your goal?: ");
                    string _nameGoalEternal = Console.ReadLine();
                    Console.Write("What is a short description of it?: ");
                    string _descriptioGoalEternal = Console.ReadLine();
                    Console.Write("Whats is th amount of points associated with this goal?: ");
                    int _pointsGoalsEternal = int.Parse(Console.ReadLine());
                    EternalGoal listGoalEternal = new EternalGoal(_nameGoalEternal,_descriptioGoalEternal,_pointsGoalsEternal);
                    AddGoal(listGoalEternal);
                    break;
                case "3": // Create a new Checklist Goal
                    Console.Write("What is the name of your goal?: ");
                    string _nameGoalChecklist = Console.ReadLine();
                    Console.Write("What is a short description of it?: ");
                    string _descriptioGoalChecklist = Console.ReadLine();
                    Console.Write("Whats is th amount of points associated with this goal?: ");
                    int _pointsGoalsChecklist = int.Parse(Console.ReadLine());
                    Console.Write("How many times does this goal need to be accomplished for a bonus?: ");
                    int _attemptGoalsChecklist = int.Parse(Console.ReadLine());
                    Console.Write("what is the bonus for accomplishing it tha many times?: ");
                    float _bonusGoalsChecklist = float.Parse(Console.ReadLine());
                    ChecklistGoal listGoalCheck = new ChecklistGoal(_nameGoalChecklist,_descriptioGoalChecklist,_pointsGoalsChecklist,_attemptGoalsChecklist,_bonusGoalsChecklist);
                    AddGoal(listGoalCheck);
                    break;
                case "quit":
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Thread.Sleep(3000);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while creating the goal, error: {ex.Message}\nPlease try again.");
            Thread.Sleep(5000);
        }    
    }
    public void RemoveGoal(List<Goal> goal)
    {
        try
        {
            if (goal.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Choose a goal to remove:\n");
                for (int i = 0; i < goal.Count; i++)
                {
                    Console.WriteLine($" {i+1}. {goal[i].GetNameOfGoal()} ({goal[i].GetDescriptionOfGoal()}) - Complete: {goal[i].GetStatus()}");
                }
                Console.Write("\nSelect a goal: ");
                int choice = int.Parse(Console.ReadLine());
                Goal selectGoal = goal[choice-1];
                _removePoints += selectGoal.GetPointsAccumulated();
                goal.RemoveAt(choice - 1);
                Console.WriteLine("\nGoal removed successfully");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("You don't have goals yet, please add goals");
                Thread.Sleep(3000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nThere was an error removing the goal. Error: {ex.Message}\nTry again");
            Thread.Sleep(5000);
        }    
    }
    // Method to Record Event of a goal
    public void DisplayRecordEvent(List<Goal> goal)
    {
        try
        {
            if(goal.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Choose a goal to record an event:\n");
                for (int i = 0; i < goal.Count; i++)
                {
                    if (goal[i] is EternalGoal)
                    {
                        Console.WriteLine($" {i+1}. {goal[i].GetNameOfGoal()} -- {goal[i].GetNameKinfOfGoal()}");
                    } else {
                        Console.WriteLine($" {i+1}. {goal[i].GetNameOfGoal()} -- Complete: {goal[i].GetStatus()} -- Complete Again: {goal[i].GetStatusAgain()}");
                    }
                }
                Console.Write("\nSelect a goal: ");
                int choice = int.Parse(Console.ReadLine());
                Goal selectedGoal = goal[choice - 1];
                selectedGoal.RecordEvent();
            } else
            {
                Console.WriteLine("You don't have goals yet, please add goals");
                Thread.Sleep(3000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nThere was an error choosing the goal you want to make an event record. Error: {ex.Message}\nTry again");
            Thread.Sleep(5000);
        }    
    }
    // Method to Calculate the total points for the user
    public void CalculateTotalPoints()
    { 
        float totalPoints = 0;
        foreach (Goal goal in _goalsList)
        {
            if(goal.GetPointsAccumulated() > 0)
            {
                totalPoints += goal.GetPointsAccumulated();
            }
        }
        Console.WriteLine($"Total points: {totalPoints + _removePoints}");
    }
    // Method to save the goals in a json file
    public void SaveGoals(List<Goal> goals, GoalsManager goalsManager, string fileName)
    {
        // Create an anonymous instance and assign the list of goals and the removePoints value
        var dataToSerialize = new 
        {
            Goals = goals,
            RemovePoints = goalsManager._removePoints,
        };
        // Create an instance of JsonSerializerSettings and configure the handling of type names
        JsonSerializerSettings settingsSave = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        try
        {
            // Serialize the anonymous instance to JSON format using the specified configuration options
            string json = JsonConvert.SerializeObject(dataToSerialize, Formatting.Indented, settingsSave);
            // Write the serialized JSON to a file with the specified name
            File.WriteAllText($"{fileName}.json", json);
            // Call a ProgressBar function to update a progress bar or inform the user that the operation has completed successfully
            ProgressBar(fileName, "Saved");
        }
        catch (Exception ex)
        {
            // If an exception occurs, display an error message on the console
            Console.WriteLine($"\nException while saving goals: {ex.Message}");
            Thread.Sleep(5000);
        }
    }
    // Method to load the goals in a json file, I used 'out' to indicate that a parameter is an output variable
    public List<Goal> LoadGoals(string fileName, out float removePoints)
    {
        // Verify if the file exist or not
        if(!File.Exists($"{fileName}.json"))
        {
            Console.WriteLine($"\nThe file {fileName}.json no exist");  
        }
        // Assign a default value to the removePoints output parameter
        removePoints = 0;
        // Create an instance of JsonSerializerSettings and configure the handling of type names
        JsonSerializerSettings settingsLoad = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        try
        {
            // Read the content of the JSON file and store it in a string
            string json = File.ReadAllText($"{fileName}.json");
            // Deserialize the JSON into an anonymous variable using the specified configuration options
            var data = JsonConvert.DeserializeAnonymousType(json, new { Goals = new List<Goal>(), RemovePoints = 0.0f }, settingsLoad);
            // Assign the list of goals and the removePoints value to the local variables
            List<Goal> goals = data.Goals;
            removePoints = data.RemovePoints;
            // Call a ProgressBar function to update a progress bar or inform the user that the operation has completed successfully
            ProgressBar(fileName, "Loaded");
            // Return the list of goals
            return goals;
        }
        catch (Exception ex)
        {
            // If an exception occurs, display an error message on the console
            Console.WriteLine($"Exception while loading goals: {ex.Message}");
            Thread.Sleep(5000);
            // Return an empty list of goals
            return new List<Goal>();
        }
    }
    // Method to display a progress bar
    public void ProgressBar(string filename, string message){
        int progress = 0;
        int total = 100;
        int barLength = Console.WindowWidth - message.Length - filename.Length - 22;
        while (progress <= total) {
            //Display Progress Bar
            int completedLength = (int)((float)progress / total * barLength);
            int remainingLength = barLength - completedLength;
            Console.Write("\r{0}% [{1}{2}]", 
                progress, 
                new string('#', completedLength), 
                new string(' ', remainingLength)
            );
            progress++;
            Thread.Sleep(5);
        }
        Console.WriteLine($"\n{message} {filename}.json file successful!!");
        Thread.Sleep(3000);
    }
}