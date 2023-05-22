using System;

public class Word 
{
    private string _word;
    private bool _hidden; //word visibility

    public Word (string word)
    {
        _word = word;
    }

    public void Hide() //set visibility to hide word
    {
        _hidden = true;
    }

    public void Show() //set visibility to show word
    {
        _hidden = false;
    }

    public bool IsHidden() //return visibility status
    {
        return _hidden;
    }

    public string GetRenderedText()
    {
        if (_hidden == false) //if visibility is not hidden (false) return word text
        {
            return _word;
        }

        else //if visibility is hidden (true) return hidden word or underscores
        {
            
            string hiddenWord = ""; //empty string

            foreach (char letter in _word) //iterate through each letter or "char" in the word string

            {
                hiddenWord += "_"; //for every letter, append an "_" to the hiddenWord string
            }

            return hiddenWord; //hiddenWord should now be a string of underscores equal to the word length or letter count.


        }

    }
}