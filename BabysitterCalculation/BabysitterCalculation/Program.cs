using System;
using System.Collections;


namespace BabysitterCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserName;
            string Family;
            Double TimeStart;
            Double TimeEnd;
            string Input;
            bool Token;
            int PayTotal;
            Console.WriteLine("Enter Name:");
            UserName = Console.ReadLine();
            Console.WriteLine("Enter Time Started Baby Sitting in HHMM format:");
            Input = Console.ReadLine();
            TimeStart = Convert.ToDouble(Input);
            //Detects if time less than 500 is input
            while (TimeStart < 500)
            {

                if (TimeStart < 500)
                {
                    Console.WriteLine("Enter Time Started Baby Sitting, Your Previous Value Was Invalid:");
                    Input = Console.ReadLine();
                    TimeStart = Convert.ToDouble(Input);
                }
            }
            //Rounds to nearest hour worked in military time
            TimeStart = StartTimeRounder(TimeStart);


            Console.WriteLine("Enter Time Ended Baby Sitting in HHMM format");
            Input = Console.ReadLine();
            TimeEnd = Convert.ToDouble(Input);
            TimeEnd = EndTimeRounder(TimeEnd);
            
            Console.WriteLine("Enter Family Worked For 'A','B' or 'C'");
            Input = Console.ReadLine();
            Family = Input;
            
            Token = false;
            //Checks for invalid Family input
            while (!Token)
            {
                if (!(Family == "A" || Family == "B" || Family == "C" || Family == "c" || Family == "b" || Family == "a"))
                {

                    Console.WriteLine("Enter Family Worked For");
                    Token = false;

                }
                else
                    Token = true;
            }
            //Sets lowercase to uppercase decisions for Family Variable for ease 
            Family = SetFamilyCase(Family);
            Console.WriteLine("Your Total Pay is: $", Calculate(Family, TimeStart, TimeEnd),".00");
            

           



        }
      private static double StartTimeRounder(double Time)
        {
            if (Time > 500 && Time < 600)
            {
                Time = 17;
            }
            else if (Time > 600 && Time < 700)
            {
                Time = 18;
            }
            else if (Time > 700 && Time < 800)
            {
                Time = 19;
            }
            else if (Time > 800 && Time < 900)
            {
                Time = 20;
            }
            else if (Time > 900 && Time < 1000)
            {
                Time = 21;
            }
            else if (Time > 1000 && Time < 1100)
            {
                Time = 22;
            }
            else if (Time > 1100 && Time < 1200)
            {
                Time = 23;
            }
            return Time;
        }
        private static double EndTimeRounder(double Time)
        {
            if (Time > 100 && Time < 200)
            {
                Time = 25;
            }
            else if (Time > 200 && Time < 300)
            {
                Time = 26;
            }
            else if (Time > 300 && Time < 400)
            {
                Time = 27;
            }
            else if (Time > 1200)
            {
                Time = 24;
            }
            return Time;
        }
        private static string SetFamilyCase(string Case)
        {
            if (Case == "a" || Case == "b" || Case == "c")
            {
                if (Case == "a")
                {
                    Case = "A";
                }
                if (Case == "b")
                {
                    Case = "B";
                }
                if (Case == "c")
                {
                    Case = "C";
                }
            }
            return Case;
        }
        private static double Calculate(string FamilyType,double ST,double ET)
        {
            double a;
            double b;
            double PayTotal;
            PayTotal = 0;
            switch (FamilyType)
            {
                case "A":
                    if (ST < 24)
                    {
                        PayTotal = (ET - ST) * 15;
                    }
                    else
                    {
                        
                        a = (23-ST) * 15;
                        PayTotal = (a) + (ET - 24) * 20;
                    }

                    break;
                case "B":
                    if(ST<22)
                    {
                        PayTotal = (ET - ST) * 12;
                    }
                    else if(ST>22 && ET<25)
                    {
                        a = (20 - ST) * 12;
                        PayTotal = a + (ET - 22) * 8;
                        
                    }
                    else
                    {
                        a = (20 - ST) * 12;
                        b = (ET-25)*8;
                        PayTotal = a + b + (ET - 24) * 16;

                    }
                    break;
                case "C":
                    if (ST < 22)
                    {
                        PayTotal = (ET - ST) * 21;
                    }
                    else
                    {
                        a = (21-ST) * 21;
                        PayTotal = a + (ET - 21) * 15;
                    }
                    break;
            }
            return PayTotal;
        }
    }
}
