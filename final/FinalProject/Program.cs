using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
       DisplayHeader();
       Console.WriteLine("Welcome! To get started, kindly provide the requested information:\n");
       
       Console.WriteLine("+ STEP 1: ABOUT YOU +\n");
       //Contact details
       Console.Write("     Name: ");
       string name = Console.ReadLine();
       Console.Write("     Phone number: ");
       string phoneNumber = Console.ReadLine();
       Console.Write("     Email address: ");
       string emailAddress = Console.ReadLine();
       int status = 0;
       bool isSingle = true;

       while(status != 1 || status !=2)
       {
            try
            {
                    Console.Write("     Relationship Status -  enter (1) if Single or (2) if Partnered: ");
                    status = int.Parse(Console.ReadLine());

                    if(status == 1)
                    {
                        isSingle = true;
                        break;
                    }

                    else if(status == 2)
                    {
                        isSingle = false;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("         You have entered an invalid option!");
                        Console.WriteLine("         Please selected between 1 and 2 only");
                    }

                }

                catch(FormatException)
                {

                    Console.WriteLine("         Invalid input. Please enter a valid integer.");

                }
        }
 
       
       int dependant = -999999999;
       Console.Write("     Dependants - enter 0 if none: ");
       

       while(dependant < 0)
       {
            try
            {
                dependant = int.Parse(Console.ReadLine());
                   
                if(dependant >= 0)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("         You cannot have a negative number of dependants!");
                    Console.WriteLine("         Please input a number equal or higher than 0");

                    Console.Write("     Dependants - enter 0 if none: ");
                    //dependant = int.Parse(Console.ReadLine());
                }
            
            }

            catch(FormatException)
            {

                Console.WriteLine("         Invalid input. Please enter a valid integer.");
                Console.Write("     Dependants - enter 0 if none: ");
                //dependant = int.Parse(Console.ReadLine());

            }
        }

       DisplaySaveMessage();
       DisplayHeader();
       Console.WriteLine("Welcome! To get started, kindly provide the requested information:\n");

       //Applicant information
       Console.WriteLine("+ STEP 2: YOUR INCOME & EXPENSES +\n");

       int creditLimit = 0;
       int otherLoans =  0;
       int baseIncome = 0;
       int partnerIncome = 0;

       //ask base income if single
       if(status==1)
       {
            Console.Write("     What is your base annual income? : ");
            baseIncome = int.Parse(Console.ReadLine());
            Console.Write("     What is your total credit card limit? - enter 0 if none : ");
            creditLimit = int.Parse(Console.ReadLine());

       }
    
        //if partnerned, ask partner income
       else if(status==2)
       {
            Console.Write("     What is your base annual income? : ");
            baseIncome = int.Parse(Console.ReadLine());
            Console.Write("     What is your partner's base annual income? : ");
            partnerIncome = int.Parse(Console.ReadLine());
            Console.Write("     What is your total combined credit card limit? - enter 0 if none: ");
            creditLimit = int.Parse(Console.ReadLine());

       }

       Console.Write("     What is your estimated monthly bills and living expenses? : ");
       int livingCosts = int.Parse(Console.ReadLine());
       
       string choice = "";
       Console.WriteLine("     Do you have a current mortgage or other loan repayments (personal, car, student, etc)?  - y or n");

       while(choice!="y" || choice!="n")
       {
             
            Console.Write("     > ");
            choice = Console.ReadLine().ToLower();
            

            if(choice=="y")
            {
                    Console.Write("     What is your total monthly repayments for all existing loans (rounded to the nearest dollar)? : ");
                    otherLoans = int.Parse(Console.ReadLine());
                    break;
            }

            else if(choice=="n")
            {

                    otherLoans = 0;
                    break;
            }

            else
            {
                    Console.WriteLine("         Please type y or n only!");
                
            }

       }

       //create Applicant object
       Applicant applicant = new Applicant(name, phoneNumber, emailAddress, isSingle, dependant, livingCosts, creditLimit, otherLoans);

       double netIncome = applicant.CalcuateNetIncome(baseIncome) + applicant.CalcuateNetIncome(partnerIncome);
       applicant.SetNetIncome(netIncome);

       DisplaySaveMessage();
       DisplayHeader();

        //Loan information
       Console.WriteLine("+ STEP 3: YOUR LOAN DETAILS +\n");

       int type = 0;

       //ADD ERROR HANDLING - ENSURE THAT DEPOSIT IS NO LESS THAN 20% OF PROPERTY VALUE
       Console.Write("     What is the value of the property you want to purchase? : ");
       int securityValue = int.Parse(Console.ReadLine());
       Console.Write("     What is your deposit amount? : ");
       int depositAmount = int.Parse(Console.ReadLine());
       Console.Write("     How many years would you like to pay off the loan? - maximum 30 years : ");
       int loanTerm = int.Parse(Console.ReadLine());
       Console.Write("     Is this a (1) house to live-in or an (2) investment property? : ");
       type = int.Parse(Console.ReadLine());

       if(type==1) //owner-occupied home
       {
            OwnerOccupied loan = new OwnerOccupied(securityValue, depositAmount, loanTerm);
            loan.SetInterestRate();
            loan.SetAssessmentRate();

            Step4(applicant, loan);
            Step5(applicant);

       }
       
       else if(type==2) //investment property
       {
            Investment loan = new Investment(securityValue, depositAmount, loanTerm);
            loan.SetInterestRate();
            loan.SetAssessmentRate();

            Step4(applicant, loan);
            Step5(applicant);

       }

       else
       {

            Console.WriteLine("         You have entered an invalid option!");
            Console.WriteLine("         Please selected between 1 and 2 only");

       }
       

    }

    static void Step4(Applicant applicant, Loan loan)
    {
       DisplaySaveMessage();
       DisplayHeader();

        //Check Eligibility for the loan
       Console.WriteLine("+ STEP 4: CHECK ELIGIBILITY FOR LOAN +\n");

       EligibilityCalculator calculator = new EligibilityCalculator(applicant, loan);

       calculator.CalculateNetDisposableIncome();
       calculator.CalculateNdiRatio();

       applicant.DisplayContactDetails();
       Console.WriteLine();
       Console.WriteLine("Applicant Details: ");
       applicant.DisplayApplicationDetails();
       Console.WriteLine();
       Console.WriteLine("Loan Details: ");
       loan.DisplayLoanDetails();

       Console.WriteLine();


       Console.WriteLine("Calculating NDI ratio...");
       PauseSpinner(5);
       Console.WriteLine();
       
       bool eligibility = calculator.IsEligble();
       double ratio = calculator.GetNdiRatio();
       string formattedRatio = ratio.ToString("F2");

       if(eligibility==true)
       {
            Console.WriteLine($"CONGRATULATIONS! Your NDI ratio is {formattedRatio}:1.");
            Console.WriteLine($"You are eligible to take out a loan of ${loan.GetPrincipal()}.");
       }

       else
       {

            Console.WriteLine($"SORRY! Your NDI ratio is {formattedRatio}:1.");
            Console.WriteLine($"You are not eligible to take out a loan of ${loan.GetPrincipal()}.");
       }


    }

    static void Step5(Applicant applicant)
    {

        string book = " ";
        string appointmentDay = "";
        string appointmentTime = "";

        //Book an appointment
        Console.WriteLine("\n     Would you like to book an appointment with a lending specialist to discuss further? - y or n : ");
        Console.Write("     > ");
        book = Console.ReadLine().ToLower();

        if(book=="y")
        {
            Console.WriteLine();
            Console.Write("     Please enter your preferred date (dd-mm-yyyy): ");
            string dateString = Console.ReadLine();
            DateTime dateTime;
           

            if (DateTime.TryParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                appointmentDay = dateTime.ToString("dddd");
            }

            Console.Write("     Please enter your preferred time (24 hr format): ");
            appointmentTime = Console.ReadLine();


            AppointmentSetter appointmentSetter = new AppointmentSetter(applicant, appointmentDay, appointmentTime);

            Console.WriteLine("\nMatching you with a lending specialist...");
            PauseSpinner(5);

            appointmentSetter.AssignLendingSpecialist();
            appointmentSetter.DisplayAppointmentConfirmation();
            
        }

        else if(book=="n")
        {
            Console.WriteLine("\nThank you for using LoanCheck!");
            Console.WriteLine("Should you wish to speak with one of our lending specialists, send us an email to hello@loancheck.com.au");
            Console.WriteLine();
        }


        else
        {
            Console.WriteLine("         Please type y or n only!");
        }


    }



    static void DisplayHeader()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("         LoanCheck: Simple Loan Eligibility Assessment Tool");
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine();
        
    }

    static void PauseSpinner(int spinnerDuration) //pause while displaying a spinner for a specified duration
    {
        int i = 0;

        int duration = spinnerDuration;

        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i == duration) //end the loop if index reaches the duration even if not completely done iterating through the objects
            {
                break;
            }

            else if (i >= animationStrings.Count) //end the loop at duration set even if duration is more than the object count (reset loop until duration ends)
            {
                i = 0;
            }

        }

    }

    static void DisplaySaveMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Saving information...");
        PauseSpinner(5);

    }
}