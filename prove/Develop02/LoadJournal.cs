using System;

class LoadJournal{

    public Journal Load(string _filename){

        Journal _journal = new Journal();
        if (!File.Exists(_filename)){
            Console.WriteLine("The file no exist");
            return _journal;
        }
        using (StreamReader _streamReader = new StreamReader(_filename))
        {
            while (!_streamReader.EndOfStream)
            {
                string _prompt = _streamReader.ReadLine();
                string _userResponse = _streamReader.ReadLine();
                if (!string.IsNullOrWhiteSpace(_prompt)){
                    _journal.AddEntry(_prompt,_userResponse);
                }
            }
        }
        return _journal;
    }
} 
