using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private string _scriptureText;
    private List<Word> _listOfWords;
    private bool _completelyHidden;

    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;
        _scriptureText = scriptureText;

        //convert _scriptureText to a list of word objects
        List<Word> listOfWords = new List<Word>();

        string [] words = _scriptureText.Split(" ");
        
        foreach (string word in words)
        {
            Word newWord = new Word(word);
            newWord.Show();

            listOfWords.Add(newWord);
        }

        _listOfWords = listOfWords;
        
    }

    public string GetRenderedText()
    {
        string reference = _reference.GetReferenceString();
        
        string renderedText = reference + " ";

        foreach (Word word in _listOfWords)
        {
            renderedText += word.GetRenderedText() + " ";
        }

        return renderedText;
    }



}