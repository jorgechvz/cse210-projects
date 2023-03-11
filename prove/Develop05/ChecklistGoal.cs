using System;
using Newtonsoft.Json;

public class ChecklistGoal : Goal
{
    // Attributes
    [JsonProperty("RequieredAttempts")]
    private int _numRequieredGoals {get;set;}
    [JsonProperty("Attempts")]
    private int _numAttemptGoals {get;set;}
    [JsonProperty("BonusPoints")]
    private float _bonusPoints {get;set;}
    [JsonProperty("BonusPointsStart")]
    private float _pointsBonusStart {get;set;}
    [JsonProperty("isComplete")]
    private bool _isComplete {get;set;}
    [JsonProperty("isCompleteAgain")]
    private bool _isCompletedAgain;
    [JsonProperty("TotalPoints")]
    private float _checkTotalPoints;
    [JsonProperty("TotalPointsAgain")]
    private float _checkTotalPointsAgain;
    // Constructor for ChecklistGoal
    public ChecklistGoal(string name, string description,float points, int numRequieredGoals, float bonusPoints) : base("Checklist Goal", name, description,points)
    {
        _numAttemptGoals = 0;
        _numRequieredGoals = numRequieredGoals;
        _bonusPoints = bonusPoints;
        _isComplete = false;
        _checkTotalPoints = 0;
        _isCompletedAgain = false;
        _pointsBonusStart = _bonusPoints;
    }
    // Getter for Number of Requiered Goals
    public int GetNumRequieredGoals()
    {
        return _numRequieredGoals;
    }
    // Getter for a Attempts number
    public int GetAttemptGoals()
    {
        return _numAttemptGoals;
    }
    // Override for RecordEvent
    public override float RecordEvent()
    {
        if (_isComplete && !_isCompletedAgain)
        {
            Console.WriteLine("\nYou have completed this goal before. Would you like to try again for double bonus points? (y/n)");
            var response = Console.ReadLine();
            if (response == "y")
            {
                _isCompletedAgain = true;
                _isComplete = false;
                _numAttemptGoals = 0;
                _bonusPoints *= 2;
                _checkTotalPointsAgain = _checkTotalPoints;
                Console.WriteLine($"\nYou have chosen to attempt this goal again for double bonus points! \nYou now have {_checkTotalPoints} total points for this goal. And you will get a {_bonusPoints} bonus when this goal is complete");
                Thread.Sleep(5000);
            } else 
            {
                Console.WriteLine("\nPlease select another goal.");
                Thread.Sleep(4000);
            }
        } else if (_isCompletedAgain  && _isComplete )
        {
            Console.WriteLine("\nThis goal has already been completed again.");
            Console.WriteLine("Please select another goal.");
            Thread.Sleep(4000);
        }
        /* -------------------------------------------- */
        if (!_isComplete)
        {
            _numAttemptGoals++;
            if (_numAttemptGoals >= _numRequieredGoals)
            {
                _numAttemptGoals = _numRequieredGoals;
                _isComplete = true;
                _checkTotalPoints = _numAttemptGoals * GetPoints() + _bonusPoints;
                Console.WriteLine($"\nEvent recorded! You earned {GetPoints()} points and a bonus of {_bonusPoints} points");
                Thread.Sleep(4000);
                return _checkTotalPoints;
            } else
            {
                _checkTotalPoints = _numAttemptGoals * GetPoints();
                Console.WriteLine($"\nEvent recorded! You earned {GetPoints()} points.");
                Thread.Sleep(4000);
                return _checkTotalPoints;
            }
        }
        return _checkTotalPoints;       
    }
    // Override for GetPointsAccumulated
    public override float GetPointsAccumulated()
    {
        if (_isCompletedAgain)
        {
            return _checkTotalPoints + _checkTotalPointsAgain;
        } else
        {
            return _checkTotalPoints;
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