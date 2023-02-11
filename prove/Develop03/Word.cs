using System;

class Word
{
    // Attributes for Word Text and IsHidden to set the initial value of the word to false, indicating that the word is not hidden
    private string _wordText;
    private bool _isHidden;
    public Word(string wordText)
    {
        _wordText = wordText;
        _isHidden = false;
    }
    //Getters and Setters, I used the methods get and set 
    // Getter for the text of the word
    public string WordText
    {
        get { return _wordText; }
    }
    // Getter and setter for the hidden word
    public bool IsHidden
    {
        get { return _isHidden; }
        set { _isHidden = value; }
    }

    /* Display the words */
    public override string ToString()
    {
        // If the word is hidden, return a series of underscores with the same length as the word text
        if (_isHidden)
        {
            return new string('_',_wordText.Length);
        }
        else // If the word is not hidden, return the text of the word
        {
            return _wordText;
        }
    }
}