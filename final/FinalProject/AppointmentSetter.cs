using System;
using System.Collections.Generic;
using System.IO;

public class AppointmentSetter
{
    private List<LendingSpecialist> _listOfSpecialists;
    private Applicant _applicant;
    private string _appointmentDay;
    private string _appointmentTime;


    public AppointmentSetter(Applicant applicant, string appointmentDay, string appointmentTime)
    {
       
        string filename = "specialists.txt"; //reads from file to create lending specialist objects

       _listOfSpecialists = LoadFile(filename);
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

     private List<LendingSpecialist> LoadFile(string file)
    {
        List<LendingSpecialist> staff = new List<LendingSpecialist>();

        string filename = file; //filename

        if (File.Exists(filename)) //Load successfully if file exists
        {
            string [] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                //each line on the file will look like this {name}~~{phone}~~{email}~~{days,etc}~~{timestart-finish,etc}

                string[] parts = line.Split("~~");
            
                //parts[0] - name
                //parts[1] - phone
                //parts[2] - email
                //parts[3] - days (needs to be split by , )
                //parts[4] - time (needs to be split by , )

                string name = parts[0];
                string phone = parts[1];
                string email = parts[2];
                string days = parts[3];
                string time = parts[4];

                LendingSpecialist newStaff = new LendingSpecialist(name, phone, email);

                //split days to create a list of days
                string [] listOfDays = days.Split(",");

                foreach (string day in listOfDays)
                {
                    newStaff.SetAvailableDays(day);
                }

                //split time to create a list of time slots
                string [] listOfTime = time.Split(",");

                foreach (string times in listOfTime)
                {
                    newStaff.SetAvailableTime(times);
                }

                staff.Add(newStaff);
    
            }
            

            return staff;

        }

        else //handle file doesn't exist error so program doesn't crash
        {
            Console.WriteLine("\nERROR!");
            Console.WriteLine("File doesn't exist. Please create it or load a different file");

            return staff; //returns nothing
        }

    }



}