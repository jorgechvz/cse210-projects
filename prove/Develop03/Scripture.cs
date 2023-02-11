using System;

class Scripture
{
    // Attributes for Reference, words and random 
    private Reference _reference;
    private List<Word> _words;
    private Random rng = new Random();

    // Constructor to initialize the Scripture object
    public Scripture(Reference reference, string text)
    {   
        // Assign the reference object to the private member variable
        _reference = reference;
        // Split the text into words, convert each word into a Word object and store in the words list
        _words = text.Split(' ').Select(x => new Word(x)).ToList();
    }

    // Method to hide a random word from the scripture
    public void HideWords()
    {
        // Get a random word index from the words list
        int wordIndex = rng.Next(_words.Count);
        // If the selected word is not hidden, hide it
        if (!_words[wordIndex].IsHidden)
        {
            _words[wordIndex].IsHidden = true;
        }
        else  // If the selected word is already hidden, keep selecting random words until an unhidden word is found
        {
            while (_words[wordIndex].IsHidden)
            {
                wordIndex = rng.Next(_words.Count);
            }
            _words[wordIndex].IsHidden = true;
        }   
    }

    // Method to display the scripture
    public string DisplayScripture()
    {
        string scripture = "";
        foreach (Word word in _words)
        {
            scripture += word.WordText + " ";
        }
        return $"Reference: {_reference.ToString()} - Scripture: {scripture}";
    }

    // Method to display the scripture with hidden words
    public string DisplayScriptureHidden(){
        string scripture = " ";
            foreach (Word word in _words)
            {
                scripture += word.ToString() + " ";
            }
        return $"Reference: {_reference.ToString()} - Scripture: {scripture}";
    }

    // Method to check if all words in the scripture are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            //Loop through each word in the words list and check if any of them are not hidden
            if (!word.IsHidden)
            {
                // If any word is not hidden, return false
                return false;
            }
        }
        // If all words are hidden, return true
        return true;
    }
}   

