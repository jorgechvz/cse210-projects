using System;
using Newtonsoft.Json;

public class EternalGoal : Goal
{
    // Attributes
    [JsonProperty("Attempts")]
    private int _numberOfGoalComplete {get;set;}
    [JsonProperty("TotalPoints")]
    private float _eternalPointsTotal {get;set;}
    // Constructor for EternalGoal
    public EternalGoal(string name, string description,float points) : base("Eternal Goal", name, description,points)
    {
        _eternalPointsTotal = 0;
        _numberOfGoalComplete = 0;
    }
    public int GetNumberOfAttempts()
    {
        return _numberOfGoalComplete;
    }
    // Override for RecordEvent
    public override float RecordEvent()
    {
        _numberOfGoalComplete++;
        _eternalPointsTotal = _numberOfGoalComplete * GetPoints();
        Console.WriteLine($"\nEvent recorded! You earned {GetPoints()} points.");
        Thread.Sleep(5000);
        return _eternalPointsTotal;
    }
    // Override for GetPointsAccumulated
    public override float GetPointsAccumulated()
    {
        return _eternalPointsTotal;
    }
    // Override for IsComplete
    public override bool IsComplete()
    {
        return false;
    }
    // Override for IsCompleteAgain
    public override bool IsCompleteAgain()
    {
        return false;
    }
}