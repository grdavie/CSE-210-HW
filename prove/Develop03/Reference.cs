using System;

public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _endVerse;

    public Reference(string book, string chapterNumber, string verseNumber) //constructor for single verse scripture
    {
        _book = book;
        _chapter = chapterNumber;
        _verse = verseNumber;
    }

    public Reference(string book, string chapterNumber, string verseNumber, string endVerse) //constructor for multiple verse scripture
    {
        _book = book;
        _chapter = chapterNumber;
        _verse = verseNumber;
        _endVerse = endVerse;
    }

    public string GetReferenceString()
    {
        if (_endVerse == null) //single verse (e.g. John 3:16)
        {
            return _book + " " + _chapter + ":" + _verse;        
        }

        else //multiple verse (e.g. Proverbs 3:5-6)
        {
            return _book + " " + _chapter + ":" + _verse + "-" + _endVerse; 
        }

    }
}