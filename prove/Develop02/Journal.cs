using System;

class Journal{
    
    /* List for the User entries */
    private List<Entry> _entriesJournal;
    /* We can use this: private List<Entry> _entriesJournal = new List<Entry>() 
    but we create a new method for more order*/

    /* Method to created the list of the user entries */
    public Journal(){
        _entriesJournal = new List<Entry>();
    }

    /* Method to add the data in the list */
    public void AddEntry(string _promt, string _userResponse){
        Entry _newEntry = new Entry(_promt,_userResponse);
        _entriesJournal.Add(_newEntry);
    }

    /* Method to return the _entriesJournal list  */
    public List<Entry> GetEntries(){
        return _entriesJournal;
    }

    /* Method to display the list */
    public void Display(){
        foreach (Entry entry in _entriesJournal){
            Console.WriteLine(entry.ToString());
        }
    }
    
}