using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
       DisplayHeader();
       Console.WriteLine("Welcome! To get started, kindly provide the requested information:\n");
       
       Console.ForegroundColor = ConsoleColor.Yellow;
       Console.WriteLine("+ STEP 1: ABOUT YOU +\n");
       Console.ResetColor();
       
       //Contact details
       Console.Write("     Name: ");
       string name = Console.ReadLine();
       Console.Write("     Phone number: ");
       string phoneNumber = Console.ReadLine();
       Console.Write("     Email address: ");
       string emailAddress = Console.ReadLine();
       int status = 0;
       bool isSingle = true;

       //check relationship status
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("         You have entered an invalid option!");
                        Console.WriteLine("         Please selected between 1 and 2 only");
                        Console.ResetColor();
                    }

                }

                catch(FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         Invalid input. Please enter a valid integer.");
                    Console.ResetColor();
                }
        }
 
       //check number of dependants
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You cannot have a negative number of dependants!");
                    Console.WriteLine("         Please input a number equal or higher than 0");
                    Console.ResetColor();
                    Console.Write("     Dependants - enter 0 if none: ");
                    //dependant = int.Parse(Console.ReadLine());
                }
            
            }

            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         Invalid input. Please enter a valid integer.");
                Console.ResetColor();
                Console.Write("     Dependants - enter 0 if none: ");
                //dependant = int.Parse(Console.ReadLine());

            }
        }
       
       //TRANSITION TO STEP 2
       DisplaySaveMessage();
       DisplayHeader();
       Console.WriteLine("Welcome! To get started, kindly provide the requested information:\n");

       //Applicant information
       Console.ForegroundColor = ConsoleColor.Yellow;
       Console.WriteLine("+ STEP 2: YOUR INCOME & EXPENSES +\n");
       Console.ResetColor();

       int creditLimit = -1;
       int otherLoans =  -1;
       int baseIncome = -1;
       int partnerIncome = -1;

       //ask base income if single
       if(status==1)
       {
            
            baseIncome = DisplayBaseIncomeQuestion(baseIncome, "base");
            creditLimit = DisplayCreditLimitQuestion(creditLimit, "total");
            partnerIncome = 0;
        
       }
    
        //if partnerned, ask partner income
       else if(status==2)
       {
            
            baseIncome = DisplayBaseIncomeQuestion(baseIncome, "base");
            partnerIncome = DisplayBaseIncomeQuestion(partnerIncome, "partner's base");
            creditLimit = DisplayCreditLimitQuestion(creditLimit, "total combined");

       }

       //ask living costs     
       int livingCosts = -1;
       Console.Write("     What is your estimated monthly bills and living expenses? : ");

       while(livingCosts < 0)
       {
            try
            {
                livingCosts = int.Parse(Console.ReadLine());

                if(livingCosts >=0)
                {
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You cannot have a negative bill or expenses!");
                    Console.WriteLine("         Please input an amount equal or higher than 0");
                    Console.ResetColor();
                    Console.Write("     What is your estimated monthly bills and living expenses? : ");

                }
            }

            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         Invalid input. Please enter a valid integer.");
                Console.ResetColor();
                Console.Write("     What is your estimated monthly bills and living expenses? : ");
            
            }
        
            
       }
            
       string choice = "";
       Console.WriteLine("     Do you have a current mortgage or other loan repayments (personal, car, student, etc)?  - y or n");

       while(choice!="y" || choice!="n")
       {
             
            Console.Write("     > ");
            choice = Console.ReadLine().ToLower();
            

            if(choice=="y")
            {
                    
                    Console.Write("     What is your total monthly repayments for all existing loans (rounded to the nearest dollar)? : ");
                    
                    while(otherLoans < 0)
                    {
                        try
                        {
                            otherLoans = int.Parse(Console.ReadLine());

                            if(otherLoans >= 0)
                            {
                                break;
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("         You cannot have a negative monthly repayment!");
                                Console.WriteLine("         Please input an amount equal or higher than 0");
                                Console.ResetColor();
                                Console.Write("     What is your total monthly repayments for all existing loans (rounded to the nearest dollar)? : ");
                            }

                        }

                        catch(FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("         Invalid input. Please enter a valid integer.");
                            Console.ResetColor();
                            Console.Write("     What is your total monthly repayments for all existing loans (rounded to the nearest dollar)? : ");
                            
                        
                        }

                    }
                    
                    break;

            }

            else if(choice=="n")
            {

                    otherLoans = 0;
                    break;
            }

            else
            {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         Please type y or n only!");
                    Console.ResetColor();
                
            }

       }

       //create Applicant object
       Applicant applicant = new Applicant(name, phoneNumber, emailAddress, isSingle, dependant, livingCosts, creditLimit, otherLoans);

       double netIncome = applicant.CalcuateNetIncome(baseIncome) + applicant.CalcuateNetIncome(partnerIncome);
       applicant.SetNetIncome(netIncome);


       //TRANSITION TO STEP 3 
       DisplaySaveMessage();
       DisplayHeader();

        //Loan information
       Console.ForegroundColor = ConsoleColor.Yellow;
       Console.WriteLine("+ STEP 3: YOUR LOAN DETAILS +\n");
       Console.ResetColor();

       int type = -1;
       double securityValue = -1;
       double depositAmount = -1;
       int loanTerm = -1;

       
       //ask Security Value
       Console.Write("     What is the value of the property you want to purchase? : ");

       while(securityValue < 0)
            
        {
            try 
            {
               
                securityValue = int.Parse(Console.ReadLine());
                
                if(securityValue >= 0)
                {
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You cannot have a negative security value!");
                    Console.WriteLine("         Please input a value equal or higher than 0");
                    Console.ResetColor();

                    Console.Write("     What is the value of the property you want to purchase? : ");
                
                }

            }

            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         Invalid input. Please enter a valid integer.");
                Console.ResetColor();

                Console.Write("     What is the value of the property you want to purchase? : ");
            
            }

        }

       //ask deposit amount - must not be lower than 20% of the property value (LVR 80 or lower)
       
       Console.Write("     What is your deposit amount? : ");
       double percentage = -1;

       while(depositAmount <= 0 || percentage < 20)
            
        {
            try 
            {
            
                depositAmount = int.Parse(Console.ReadLine());
                percentage = (double)(depositAmount / securityValue) * 100;
                
                if(depositAmount > 0 && percentage >= 20)
                {
                
                    break;

                }

                else
                {
              
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You cannot have a deposit amount lower than 20% of your security value!");
                    Console.ResetColor();
                    Console.Write("     What is your deposit amount? : ");
                
                }

            }

            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         Invalid input. Please enter a valid integer.");
                Console.ResetColor();
                Console.Write("     What is your deposit amount? : ");
            
            }

        }

       //ask loan term
       Console.Write("     How many years would you like to pay off the loan? - maximum 30 years : ");

       while(loanTerm <= 0 || loanTerm > 30)
            
        {
            try 
            {
               
                loanTerm = int.Parse(Console.ReadLine());
                
                if(loanTerm > 0 && loanTerm <= 30) //term at least 1 year and no greater than 30 yrs
                {
                    break;
                }

                else if(loanTerm <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You cannot have a negative or 0 loan term");
                    Console.ResetColor();
                    Console.Write("     How many years would you like to pay off the loan? - maximum 30 years : ");
                
                }

                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You cannot have a loan term greater than 30 years");
                    Console.ResetColor();
                    Console.Write("     How many years would you like to pay off the loan? - maximum 30 years : ");
                }

            }

            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         Invalid input. Please enter a valid integer.");
                Console.ResetColor();
                Console.Write("     How many years would you like to pay off the loan? - maximum 30 years : ");
            
            }

        }


       //ask loan type
       Console.Write("     Is this a (1) house to live-in or an (2) investment property? : ");
       
       while(type < 1)
       {
            try
            {
                type = int.Parse(Console.ReadLine());
            
                if(type==1) //owner-occupied home
                {
                    OwnerOccupied loan = new OwnerOccupied(securityValue, depositAmount, loanTerm);
                    loan.SetInterestRate();
                    loan.SetAssessmentRate();

                    Step4(applicant, loan);
                    Step5(applicant);

                    break;

                }
                
                else if(type==2) //investment property
                {
                    Investment loan = new Investment(securityValue, depositAmount, loanTerm);
                    loan.SetInterestRate();
                    loan.SetAssessmentRate();

                    Step4(applicant, loan);
                    Step5(applicant);

                    break;

                }

                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You have entered an invalid option!");
                    Console.WriteLine("         Please selected between 1 and 2 only");
                    Console.ResetColor();
                    Console.Write("     Is this a (1) house to live-in or an (2) investment property? : ");

                }

            }

            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         Invalid input. Please select between 1 and 2 only");
                Console.ResetColor();
                Console.Write("     Is this a (1) house to live-in or an (2) investment property? : ");
            
            }
        
       }
       

    }

    static void Step4(Applicant applicant, Loan loan)
    {
       DisplaySaveMessage();
       DisplayHeader();

        //Check Eligibility for the loan
       Console.ForegroundColor = ConsoleColor.Yellow;
       Console.WriteLine("+ STEP 4: CHECK ELIGIBILITY FOR LOAN +\n");
       Console.ResetColor();

       EligibilityCalculator calculator = new EligibilityCalculator(applicant, loan);

       calculator.CalculateNetDisposableIncome();
       calculator.CalculateNdiRatio();

       applicant.DisplayContactDetails();
       Console.WriteLine();
       Console.BackgroundColor = ConsoleColor.Yellow;
       Console.WriteLine("Applicant Details: ");
       Console.ResetColor();
       applicant.DisplayApplicationDetails();
       Console.WriteLine();
       Console.BackgroundColor = ConsoleColor.Yellow;
       Console.WriteLine("Loan Details: ");
       Console.ResetColor();
       loan.DisplayLoanDetails();

       Console.WriteLine();

       Console.ForegroundColor = ConsoleColor.Cyan;
       Console.WriteLine("Calculating NDI ratio...");
       Console.ResetColor();
       PauseSpinner(5);
       Console.WriteLine();
       
       bool eligibility = calculator.IsEligble();
       double ratio = calculator.GetNdiRatio();
       string formattedRatio = ratio.ToString("F2");

       if(eligibility==true)
       {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"CONGRATULATIONS! Your NDI ratio is {formattedRatio}:1.");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"You are eligible to take out a loan of ${loan.GetPrincipal()}.");
            Console.ResetColor();
       }

       else
       {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"SORRY! Your NDI ratio is {ratio}:1.");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"You are not eligible to take out a loan of ${loan.GetPrincipal()}");
            Console.ResetColor();
       }

       Console.ForegroundColor = ConsoleColor.DarkGray;
       Console.WriteLine("\nNote: The results from this calculator should be used as an indication only. Results do not represent either quotes or pre-qualifications for a loan.\nThe specific details of your loan will be provided to you in your loan contract. It is advised that you get in touch with us before taking out a \nloan so that we can provide you with advice that is tailored to your situation.");
       Console.ResetColor();


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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nThank you for using LoanCheck!");
            Console.WriteLine("Should you wish to speak with one of our lending specialists, send us an email to hello@loancheck.com.au");
            Console.ResetColor();
            Console.WriteLine();
        }


        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("         Please type y or n only!");
            Console.ResetColor();
        }


    }



    static void DisplayHeader()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("         LoanCheck: Simple Loan Eligibility Assessment Tool");
        Console.ResetColor();
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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Saving information...");
        Console.ResetColor();
        PauseSpinner(5);

    }

    static int DisplayBaseIncomeQuestion(int baseIncome, string type)
    {
        
        string incomeType = type;
        
        Console.Write($"     What is your {incomeType} annual income? : ");
            
        while(baseIncome < 0)
            
        {
            try 
            {
               
                baseIncome = int.Parse(Console.ReadLine());
                
                if(baseIncome >= 0)
                {
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You cannot have a negative base income!");
                    Console.WriteLine("         Please input an income equal or higher than 0");
                    Console.ResetColor();
                    Console.Write($"     What is your {incomeType} annual income? : ");
                
                }

            }

            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         Invalid input. Please enter a valid integer.");
                Console.ResetColor();
                Console.Write($"     What is your {incomeType} annual income? : ");
            
            }

        }

        return baseIncome;


    }

    static int DisplayCreditLimitQuestion(int creditLimit, string type)
    {
        
        string description = type;
        
        Console.Write($"     What is your {description} credit card limit? - enter 0 if none : ");
            
        while(creditLimit < 0)
            
        {
            try 
            {
               
                creditLimit = int.Parse(Console.ReadLine());
                
                if(creditLimit >= 0)
                {
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         You cannot have a negative credit limit!");
                    Console.WriteLine("         Please input a limit equal or higher than 0");
                    Console.ResetColor();
                    Console.Write($"     What is your {description} credit card limit? - enter 0 if none : ");
                
                }

            }

            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         Invalid input. Please enter a valid integer.");
                Console.ResetColor();
                Console.Write($"     What is your {description} credit card limit? - enter 0 if none : ");
            
            }

        }

        return creditLimit;


    }



}