using System;

class SaveJournal{
    /* We create a method with a one object and string */
    public void Save(Journal _journal, string _filename){

        List<Entry> _entriesList = _journal.GetEntries();
        /* We create a loop to roam in the file */
        using (StreamWriter _streamWriter = new StreamWriter(_filename)){
            foreach (Entry entry in _entriesList){
                _streamWriter.WriteLine(entry.ToString());
            }
        }

    }
}