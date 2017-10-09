using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();

            Console.WriteLine("Welcome!");

            user.FirstName = AskQuestion("What is your first name?");
            Console.WriteLine("Great! Hello " + user.FirstName);

            user.LastName = AskQuestion("What is your last name?");
            Console.WriteLine("Great! Your last name is " + user.LastName);

            Console.WriteLine("And your full name is "+ user.FirstName + " " + user.LastName);

            user.IsAccountOwner = AskBoolQuestion("Are you the account owner?");
            Console.WriteLine("Great! You are the account owner: " + user.IsAccountOwner);

            user.AccountName = AskQuestion("What is the name of your account?");
            Console.WriteLine("Great! Your account name is " + user.AccountName);

            user.PinNumber = AskPinNumber("What is your four digit pin number?", 4);
            Console.WriteLine("Your pin number is "+ user.PinNumber);
          
            Console.WriteLine("Thank You! Have a nice day!");
            Console.ReadLine();
        }

        public static string AskQuestion(string question)
        {
           Console.WriteLine(question);
           return Console.ReadLine();
        }

        static bool AskBoolQuestion(string question)
        {
            var hasAnswered = false;
            var responseBool = false;

            while (!hasAnswered) //!=has not so, while the user has not answered
            {
                var response = AskQuestion(question + " (y/n)");

                if (response == "y")
                {
                    responseBool = true;
                    hasAnswered = true;

                }
                else if (response == "n")
                { 
                    Console.WriteLine("Sorry! Only the owner can continue!"); 
                    //prevents everyone but the account owner from advancing
                }
            }
            return true;
        }
        /// <summary>
        /// The purpose of this method is to ask an int question
        /// </summary>
        /// <param name="question">question to be asked to the Compiler</param>
        /// <param name="length">limits the pin to 4 numbers</param>
        /// <returns></returns>
        static string AskPinNumber(string question, int length)
        {
            string numberString = null;
            while (numberString == null)
            {
                var response = AskQuestion(question);

                if (response.Length == length && Int32.TryParse(response, out int _))
                {
                    numberString = response;
                }
                else
                    Console.WriteLine("Please enter a valid four digit pin number!");
            }
            return numberString;
        }
    }
}
