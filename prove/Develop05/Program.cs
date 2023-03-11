// Goal Tracker Program
// Author: Jorge A. Chavez
// Course: CSE 210: Programming with classes - Winter 2023 - BYU-Idaho
// Tutor: Duane Richards 

using System;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Instace for GoalsManager Class
        GoalsManager _managerGoal = new GoalsManager();
        bool _exitProgram = false;
        while (!_exitProgram)
        {
            // Menu
            Console.WriteLine("Welcome to Eternal Quest Program\n");
            _managerGoal.CalculateTotalPoints();
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Remove Goals");
            Console.WriteLine(" 4. Save Goals");
            Console.WriteLine(" 5. Load Goals");
            Console.WriteLine(" 6. Record Event");
            Console.WriteLine(" 7. Exit");
            Console.Write("\nPlease choose a option: ");
            string _option = Console.ReadLine().ToLower();
            switch (_option)
            {
                case "1":
                    Console.Clear();
                    _managerGoal.CreateNewGoal();
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "2":
                    _managerGoal.DisplayGoals(_managerGoal.GetListGoal());
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "3":
                    _managerGoal.RemoveGoal(_managerGoal.GetListGoal());
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Save File\n");
                    Console.Write("Please enter the filename(e.g. goals) or write 'quit' to return menu: ");
                    string filenameSave = Console.ReadLine();
                    if (filenameSave == "quit")
                    {
                        _exitProgram = false;
                        Console.Clear();
                        break;
                    }
                    _managerGoal.SaveGoals(_managerGoal.GetListGoal(),_managerGoal,filenameSave);
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Load File\n");
                    Console.Write("Please enter the filename(e.g. goals) or write 'quit' to return menu: ");
                    string filenameLoad = Console.ReadLine();
                    if (filenameLoad == "quit")
                    {
                        _exitProgram = false;
                        Console.Clear();
                        break;
                    }
                    _managerGoal.SetListGoal(_managerGoal.LoadGoals(filenameLoad,out float removePoints));
                    _managerGoal.SetRemovePoints(removePoints);
                    Console.Clear();
                    _exitProgram = false;
                    break;
                case "6":
                    _managerGoal.DisplayRecordEvent(_managerGoal.GetListGoal());
                    _exitProgram = false;
                    Console.Clear();
                    break;
                case "7": // Option to exit the game
                    Console.WriteLine("Thanks for used the program!!");
                    _exitProgram = true;
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

/* For me "Shows creativity and exceeds core requirements", I have created several features in the program, such as showing the list of goals according to their type, deleting a goal, a progress bar to make the user interface more dynamic when loading and saving your goals.
I have also implemented for Simple Goals and Checklist Goal the user can perform the goal one more time and get some extra scores for doing the goal again. You will only have one chance to do the goal again.

For the save and load method, I have done it for json files because I feel that it is more readable to read and understand the file. */