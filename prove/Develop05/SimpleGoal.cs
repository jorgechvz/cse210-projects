using System;
using Newtonsoft.Json;

public class SimpleGoal : Goal
{
    // Attributes
    [JsonProperty("isComplete")]
    private bool _isComplete {set;get;}
    [JsonProperty("TotalPoints")]
    private float _simplePointsTotal {get;set;}
    [JsonProperty("isCompleteAgain")]
    private bool _isCompletedAgain;
    // Constructor for SimpleGoal
    public SimpleGoal(string name, string description,float points) :base("Simple Goal", name, description,points)
    {
        _simplePointsTotal = 0;
        _isComplete = false;
        _isCompletedAgain = false;
    }
    public float GetPointsTotal()
    {
        return _simplePointsTotal;
    }
    // Override for RecordEvent
    public override float RecordEvent()
    {
        if(!_isComplete)
        {
            _isComplete = true;
            _simplePointsTotal = GetPoints(); 
            Console.WriteLine($"\nEvent recorded! You earned {GetPoints()} points.");
            Thread.Sleep(4000);
            return _simplePointsTotal;
        }
        else if (!_isCompletedAgain)
        {
            Console.WriteLine("\nThis goal has already been completed.");
            Console.Write("Do you want to complete it again and earn an extra 100 points? (y/n): ");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                _isCompletedAgain = true;
                _simplePointsTotal *= 2;
                Console.WriteLine($"Goal completed again! You earned {_simplePointsTotal/2 + 100} total points for this goal, including the 100 extra points.");
                Thread.Sleep(5000);
                return _simplePointsTotal;
            }
            else
            {
                Console.WriteLine("\nPlease select another goal.");
                Thread.Sleep(4000);
            }
        }
        else
        {
            Console.WriteLine("\nThis goal has already been completed again.");
            Console.WriteLine("Please select another goal.");
            Thread.Sleep(4000);
        }
        return _simplePointsTotal;
    }
    // Override for GetPointsAccumulated
    public override float GetPointsAccumulated()
    {
        if (_isCompletedAgain)
        {
            return _simplePointsTotal + 100;
        } else {
            return _simplePointsTotal;
        }
    }
    // Override for IsComplete
    public override bool IsComplete()
    {
        return _isComplete;
    }
    // Override for IsCompleteAgain
    public override bool IsCompleteAgain()
    {
        return _isCompletedAgain;
    }
}