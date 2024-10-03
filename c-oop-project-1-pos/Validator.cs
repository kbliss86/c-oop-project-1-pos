using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    //Add Comments
    internal class Validator
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();
        public ProcessPayment ValidatePaymentMethod(decimal subTotal, decimal grandTotal, decimal taxTotal)
        {
            bool methodIsValid = false;
            ProcessPayment userPaymentMethod = null;
            int loopIteration = 0;
            do
            {
                if (loopIteration > 0)
                {
                    myFuncs.CenterText("Invalid payment method. Please enter a valid payment method\n");
                }
                myFuncs.CenterText("How would you like to pay? (Cash/Card/Check)");
                string givenMethod = myFuncs.CenteredInput().ToLower();
                switch (givenMethod)
                {
                    case "cash":
                        {
                            userPaymentMethod = new Cash(subTotal, grandTotal, taxTotal);
                            userPaymentMethod.ProcessPayments();
                            methodIsValid = true;
                            break;
                        }
                    case "card":
                        {
                            userPaymentMethod = new Card(subTotal, grandTotal, taxTotal);
                            userPaymentMethod.ProcessPayments(); ;
                            methodIsValid = true;
                            break;
                        }
                    case "check":
                        {
                            userPaymentMethod = new Check(subTotal, grandTotal, taxTotal);
                            userPaymentMethod.ProcessPayments();
                            methodIsValid = true;
                            break;
                        }
                }
                loopIteration++;
            } while (!methodIsValid);
            return userPaymentMethod;
        }
        public decimal ValidatePaymentAmount(decimal productCost)
        {
            decimal givenAmount = 0;
            int loopIteration = 0;
            do
            {
                if (loopIteration > 0)
                {
                    myFuncs.CenterText("Amount too low. Please supply a valid amount.\n");
                }
                myFuncs.CenterText("What amount will you be paying with?\n");
                givenAmount = myFuncs.GetANumber();
                loopIteration++;
            } while (givenAmount < productCost);
            return givenAmount;
        }
        public string ValidateCardExpiration()
        {
            string expirationDate = "";
            int loopIteration = 0;
            bool isValidDate = false;
            do
            {
                if (loopIteration > 0)
                {
                   myFuncs.CenterText("Invalid date, please ensure your card is not expired.\n");
                }
               myFuncs.CenterText("Please enter your card's expiration date (MM/yy)");
                expirationDate = myFuncs.CenteredInput();

                string formattedDate = DateTime.Now.ToString("MM/yy");//get the current date and format it into a string
                //split the dates into an array to compare
                string[] expirationValues = expirationDate.Split('/');
                string[] currentValues = formattedDate.Split('/');
                try
                {
                    //int parse the month and year values to ensure numbers were entered and be able to compare 
                    if (int.Parse(currentValues[1]) == int.Parse(expirationValues[1])) // if the year is the same
                    {
                        if (int.Parse(currentValues[0]) >= int.Parse(expirationValues[0]))// if the expiration month is smaller or the same
                        {
                            isValidDate = true;// the date is valid
                        }

                    }
                    else if (int.Parse(currentValues[1]) < int.Parse(expirationValues[1])) // if the expiration year is larger than current year
                    {
                        isValidDate = true;
                    }

                }
                catch (Exception)
                {
                   myFuncs.CenterText("Please ensure date is entered in correct format.\n");
                }
                loopIteration++;
            } while (!isValidDate);
            return expirationDate;
        }
        public string ValidateCardNumber()
        {
            string cardNumber = "";
            int loopIteration = 0;
            bool isValidCardNumber = false;
            do
            {
                if (loopIteration > 0)
                {
                    myFuncs.CenterText("Invalid card number.\n");
                }
                myFuncs.CenterText("Please enter your card number");
                cardNumber = myFuncs.CenteredInput();
                if (cardNumber.Length == 16)
                {
                    try
                    {
                        long.Parse(cardNumber);
                        isValidCardNumber = true;
                    }
                    catch (Exception)
                    {
                        myFuncs.CenterText("Please ensure all entered characters are numbers");
                    }
                }
            } while (!isValidCardNumber);
            return cardNumber;
        }

        public string ValidateCVV()
        {
            string cvvNumber = "";
            int loopIteration = 0;
            bool isValidCVVNumber = false;
            do
            {
                if (loopIteration > 0)
                {
                    myFuncs.CenterText("Invalid CVV.\n");
                }
                myFuncs.CenterText("Please enter your CVV code");
                cvvNumber = myFuncs.CenteredInput();
                if (cvvNumber.Length == 3)
                {
                    try
                    {
                        int.Parse(cvvNumber);
                        isValidCVVNumber = true;
                    }
                    catch (Exception)
                    {
                        myFuncs.CenterText("Please ensure all entered characters are numbers");
                    }
                }
            } while (!isValidCVVNumber);
            return cvvNumber;
        }

        public string ValidateCheckNumber()
        {
            string checkNumber = "";
            int loopIteration = 0;
            bool isValidCheckNumber = false;
            do
            {
                if (loopIteration > 0)
                {
                    myFuncs.CenterText("Invalid check number.\n");
                }
                myFuncs.CenterText("Please enter your check number");
                checkNumber = myFuncs.CenteredInput();
                if (checkNumber.Length >= 3 && checkNumber.Length <= 4)
                {
                    try
                    {
                        int.Parse(checkNumber);
                        isValidCheckNumber = true;
                    }
                    catch (Exception)
                    {
                        myFuncs.CenterText("Please ensure all entered characters are numbers");
                    }
                }
            } while (!isValidCheckNumber);
            return checkNumber;
        }
    }
}
