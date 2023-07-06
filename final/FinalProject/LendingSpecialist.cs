using System;
using System.Collections.Generic;

public class LendingSpecialist : Person
{
    private List<string> _availableDays;
    private List<string> _availableTime;

    public LendingSpecialist(string name, string phoneNumber, string emailAddress)
    : base(name, phoneNumber, emailAddress)
    {
        List<string> availableDays = new List<string>();
        _availableDays = availableDays;

        List<string> availableTime = new List<string>();
        _availableTime = availableTime;

    }

    public void SetAvailableDays(string day)
    {
        _availableDays.Add(day);
    }

    public void SetAvailableTime(string time)
    {
        _availableTime.Add(time);
    }

    public List<string> GetAvailableDays()
    {
        return _availableDays;
    }

    public List<string> GetAvailableTime()
    {
        return _availableTime;
    }
}   
