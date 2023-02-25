using System;

public class BreathingActivity : Activity
{   
    //Atributtes
    private string _breathIn;
    private string _breathOut;
    // Constructor to set the name of activity, description and atributtes
    public BreathingActivity() : base("Breathing Activity","This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breathIn = "Breath In...";
        _breathOut = "Breath Out...";
    }  
    // Method to display the Breath In activity
    public void BreathIn(){
        StartActivityCounter(4,_breathIn);
    }
    // Method to display the Breath Out activity
    public void BreathOut(){
        StartActivityCounter(6,_breathOut);
    }
}