using System;

class Entry{
    public string _prompt;
    public string _userResponse;
    public DateTime _dateCreated;

    /* We created the Methods */
    public Entry(string _prompt, string _userResponse){
        this._prompt = _prompt;
        this._userResponse = _userResponse;
        _dateCreated = DateTime.Now;
    }

    /* Method to get the Prompt */

    public string GetPrompt(){
        return _prompt;
    }   

    /* Method to get the user response */
    public string GetResponse(){
        return _userResponse;
    }

    /* Method to get the date created */
    public DateTime GetDateCreated(){
        return _dateCreated;
    }

    /* Method to display the, date, prompt and response */

    public override string ToString()
    {
        return $"\nDate: {_dateCreated.ToShortDateString()} - Prompt: \n{_prompt} \n{_userResponse}";
    }
}