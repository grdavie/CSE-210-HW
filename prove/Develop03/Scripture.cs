using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private string _scriptureText;
    private List<Word> _listOfWords;
    private bool _completelyHidden;
    private List<int> _listOfIndex;

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
            newWord.Show(); //set visibility of each word to not hidden

            listOfWords.Add(newWord); //add word objects to list of words
        }

        _listOfWords = listOfWords; 

        List<int> listOfIndex = new List<int>(); //create an empty list to store index numbers for later
        _listOfIndex = listOfIndex;
        
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

    public void HideWords() //MODFIY!!
    {

        int randomIndex = GetRandomIndex();
        
        while (_listOfIndex.Contains(randomIndex))
        {
           randomIndex = GetRandomIndex();
        }

        _listOfIndex.Add(randomIndex);

        _listOfWords[randomIndex].Hide();
          
    }

    private int GetRandomIndex()
    {
        Random randNum = new Random();

        int randIndex =  randNum.Next(0, _listOfWords.Count);

        return randIndex;

    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _listOfWords)
        {
            if (word.IsHidden() == false)
            {
                _completelyHidden = false;

            }

            else
            {
                _completelyHidden = true;
            }
        }

        return _completelyHidden;
    }

    //public int GetListCount()
    //{
   //    int listOfIndexCount = _listOfIndex.Count;
//
    //    return listOfIndexCount;
   // }

}