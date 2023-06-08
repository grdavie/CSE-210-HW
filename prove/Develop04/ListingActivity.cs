using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private string _listPrompt;
    private List<string> _listAnswers;

    public ListingActivity()
    {
        _activityName = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }
}