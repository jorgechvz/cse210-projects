using System;

class SaveJournal{
    public void Save(Journal _journal, string _filename){

        List<Entry> _entriesList = _journal.GetEntries();
        
        using (StreamWriter _streamWriter = new StreamWriter(_filename)){
            foreach (Entry entry in _entriesList){
                _streamWriter.WriteLine(entry.ToString());
            }
        }

    }
}