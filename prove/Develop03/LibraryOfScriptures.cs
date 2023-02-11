using System;

class LibraryOfScriptures{

    // Attribute to set a List of Dictionary
    private List<Dictionary<string, object>> _scriptureDictionarie;

    // Constructor to initialize the private attribute
    public LibraryOfScriptures(){
        _scriptureDictionarie = new List<Dictionary<string,object>>();
    }

    // Method to add a new scripture to the list
    public void AddScripture(string book, int chapter, int verse, int? endVerse, string scripture){
        var newScripture = new Dictionary<string, object>();
        // Assign the ID of the scripture as the current count of scriptures in the list
        newScripture["ID"] = _scriptureDictionarie.Count;
        newScripture["book"] = book;
        newScripture["chapter"] = chapter;
        newScripture["verse"] = verse;
        newScripture["endVerse"] = endVerse;
        newScripture["scripture"] = scripture;
        // Add the new scripture to the list of scriptures
        _scriptureDictionarie.Add(newScripture);
    }

    // Method to get a scripture by it's ID
    public Dictionary<string, object> GetScripturyById(int id){
        if (_scriptureDictionarie.Count == 0){
            return null;
        }
        // Loop through each scripture in the list and compare its ID with the specified id
        foreach (var scripture in _scriptureDictionarie) {
            if (scripture["ID"].Equals(id)) {
                return scripture;
            }
        }
        // If no scripture is found with the specified id, print an error message
        Console.WriteLine($"There are not a scripture with ID: {id}");
        return null;
    }

    //Method to return a random scripture from the list
    public Dictionary<string, object> RandomScripture()
    {
        // Check if there are any scriptures in the list
        if (_scriptureDictionarie.Count == 0){
            Console.WriteLine("There are not scriptures in the game, please add scriptures.");
            return null;
        }
        // Create a random number generator
        Random rnd = new Random();
        // Generate a random index within the range of the number of scriptures in the list
        int index = rnd.Next(0, _scriptureDictionarie.Count);
        // Get the scripture at the specified index
        var scripture = _scriptureDictionarie[index];
        // Get the end verse of the scripture
        int? endVerse = (int?)scripture["endVerse"];

        Reference reference;
        // If there is no end verse specified, create a reference with just the book, chapter, and verse
        if (endVerse == null)
        {
            reference = new Reference((string)scripture["book"], (int)scripture["chapter"], (int)scripture["verse"]);
        }// if there is an end verse specified, create a reference with the book, chapter, verse, and end verse
        else
        {
            reference = new Reference((string)scripture["book"], (int)scripture["chapter"], (int)scripture["verse"], (int)endVerse);
        }
         // Add the reference to the scripture
        scripture["reference"] = reference;

        return scripture;
    }

    // Method to display all the scriptures in the list
    public void DisplayScriptures()
    {
        if(_scriptureDictionarie.Count != 0){
            foreach (var scripture in _scriptureDictionarie)
            {
                Console.WriteLine("Scripture ID: " + scripture["ID"]);
                Console.WriteLine("Reference: "+ scripture["book"] + " " + scripture["chapter"] + ":" + scripture["verse"] + (scripture["endVerse"] != null ? "-" + scripture["endVerse"] : ""));
                Console.WriteLine("Scripture: " + scripture["scripture"]);
                Console.WriteLine();
            }
        } else{
            Console.WriteLine("Library of Scriptures is empty, please add scriptures");
        }    
    }

    // Method to get the length in the list
    public int GetNumberOfScriptures(){
        return _scriptureDictionarie.Count;
    }
}

/* LibraryOfScriptures class explained */
/* 
    This class is responsible for storing information about the scriptures. The class contains a list of dictionaries that represent the scriptures and the attributes associated with them.
    The class has several methods, such as "AddScripture" which allows to add a new scripture to the list, "GetScripturyById" which allows to get a specific scripture by its ID, "RandomScripture" which returns a random scripture from the list and "DisplayScriptures", which displays all the scripture in the list on the console.
    In addition, there are other methods that provide information about the list of Writes, such as the number of scriptures in the list and the representation of a string reference for each scripture.

 */