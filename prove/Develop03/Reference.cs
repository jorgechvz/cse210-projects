using System;

class Reference
{
    // Attributes for Book, Chapter, Verse and End Verse
    private string _book; 
    private int _chapter; 
    private int _verse; 
    private int? _endVerse;

    // Constructor for a single verse reference.
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }

    // Constructor for a range of verses reference.
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    // Overridden method that returns the string representation of the Reference object.
    public override string ToString()
    {
        if (_endVerse == null)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}