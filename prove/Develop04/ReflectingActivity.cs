using System;

public class ReflectingActivity : Activity
{
    //Atributtes
    private List<string> _promptsReflecting;
    private List<string> _questionsReflecting;
    private List<string> _usedQuestionsReflecting;
    private List<string> _usedPromptsReflecting;
    //Constructor to set the Activity name, description, prompts and questions
    public ReflectingActivity() : base("Reflection Activity","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _promptsReflecting = new List<string>{"Think of a time when you stood up for someone else.","Think of a time when you did something really difficult","Think of a time when you helped someone in need.","Think of a time when you did something truly selfless."};
        _questionsReflecting = new List<string>{"Why was this experience meaningful to you?","Have you ever done anything like this before?","How did you get started?","How did you feel when it was complete?","What made this time different than other times when you were not as successful?","What is your favorite thing about this experience?","What could you learn from this experience that applies to other situations?","What did you learn about yourself through this experience?","How can you keep this experience in mind in the future?"};
        _usedQuestionsReflecting = new List<string>();
        _usedPromptsReflecting = new List<string>();
    }
    // Method to display a prompt
    public void GetPromptReflecting()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"\n---{CheckRandomPrompt(_promptsReflecting,_usedPromptsReflecting)}---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue");
        Console.ReadKey();
        Console.WriteLine("\nNow ponder on each of the following questions as the related to this experience");
        StartActivityCounter(5,"You may begin in: ");
    }
    // Method to display a questions
    public string GetQuestionsReflecting()
    {
        string question = CheckRandomPrompt(_questionsReflecting,_usedQuestionsReflecting); 
        return $"> {question} ";
    }
}   