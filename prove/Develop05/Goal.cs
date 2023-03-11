using System;
using Newtonsoft.Json;
public abstract class Goal
{
    // [JsonProperty("")] JsonPropertyAttribute.JsonPropertyAttribute(string propertyName) }
    // propertyName: Name of the property.
    // Attributes 
    [JsonProperty("TypeGoal")]
    private string _nameKindOfGoal {set;get;}
    [JsonProperty("NameGoal")]
    private string _nameOfGoal {set;get;}
    [JsonProperty("DescriptionGoal")]
    private string _descriptionOfGoal {set;get;}
    [JsonProperty("PointsPerGoal")]
    private float _pointPerGoal {set;get;}
    // Constructor for Goal
    public Goal(string nameKindOfGoal,string nameOfGoal,string descriptionOfGoal,float pointPerGoal)
    {
        _nameKindOfGoal = nameKindOfGoal;
        _nameOfGoal = nameOfGoal;
        _descriptionOfGoal = descriptionOfGoal;
        _pointPerGoal = pointPerGoal;
    }
    // Getters for KindOfGoal, NameOfGoal, DescriptionOfGoal and Points
    public string GetNameKinfOfGoal()
    {
        return _nameKindOfGoal;
    }
    public string GetNameOfGoal()
    {
        return _nameOfGoal;
    }
    public string GetDescriptionOfGoal()
    {
        return _descriptionOfGoal;
    }
    public float GetPoints()
    {
        return _pointPerGoal;
    }
    // Abstract Method to Record Event of a goal
    public abstract float RecordEvent();
    // Abstract Method to verify if the goal is complete or not
    public abstract bool IsComplete();
    public abstract bool IsCompleteAgain();
    // Abstract Method to Accumulated the points in total
    public abstract float GetPointsAccumulated();
    // Method to return a string for a Goal, return [x] when a goal is complete and return [ ] when a goal is not complete
    public string GetStatus()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }
    // Method to return a string for a Goal, return [x] when a goal is complete Again and return [ ] when a goal is not complete Again
    public string GetStatusAgain()
    {
        return IsCompleteAgain() ? "[X]" : "[ ]"; 
    }
}