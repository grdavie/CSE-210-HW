using System;
using System.Collections.Generic;

public class AppointmentSetter
{
    private List<LendingSpecialist> _listOfSpecialists;
    private Applicant _applicant;
    private string _appointmentDay;
    private string _appointmentTime;

    private LendingSpecialist _lendingSpecialist;

    public AppointmentSetter(Applicant applicant, string appointmentDay, string appointmentTime)
    {
       
       List<LendingSpecialist> listOfSpecialists = new List<LendingSpecialist>();
       _listOfSpecialists = listOfSpecialists;
       _applicant = applicant;

       _appointmentDay = appointmentDay;
       _appointmentTime = appointmentTime;

    }

    public void AssignLendingSpecialist()
    {
        //method to randomly match applicant's appointment to a specialist that fits the schedule
    }

    public void DisplayAppointmentConfirmation()
    {
        //method to display assigned lending specialist
    }


    //add capability to read from text file and create new lending specialist objects to be added to the list of lending specialists
}