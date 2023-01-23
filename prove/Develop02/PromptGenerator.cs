using System;

class PromptGenerator{

    private List<string> _promptsGenerator;

    /* We create the list for the prompts to show the user. In this list, a series of questions will be displayed for the user to answer. */
    public PromptGenerator(){
        _promptsGenerator = new List<string>(){"Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of God in my life today?", "What was the strongest emotion I felt today?", "If I could do one thing today, what would it be?", "Do you like who you've become?","What has caused you joy this week?","When you tell your grandchildren about your life, what do you want to tell them about?","Are you doing what you really want to do?"};
    }

    /* Method to generate a random question from _promptsGenerator list */
    public string GetRandomPrompt(){
        Random random = new Random();
        int randomIndex = random.Next(_promptsGenerator.Count);
        return _promptsGenerator[randomIndex];
    }

}