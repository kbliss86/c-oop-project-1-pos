using GeneralPurposeFunctions;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    //Validates the inputs for Cash, Check, Card (also controls the loging of purchases)
    public class Validator
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();

        //Method to validate a proper payment method and construct an object of its type
        public ProcessPayment ValidatePaymentMethod(decimal subTotal, decimal grandTotal, decimal taxTotal)
        {
            bool methodIsValid = false;
            ProcessPayment userPaymentMethod = null;
            int loopIteration = 0;
            do
            {
                if (loopIteration > 0)//if unsuccesful after previous loop display an error message
                {
                    myFuncs.CenterText("Invalid payment method. Please enter a valid payment method\n");
                }
                myFuncs.CenterText("How would you like to pay? (Cash/Card/Check)");
                string givenMethod = myFuncs.CenteredInput().ToLower();//to lower to avoid capitilaziton differences
                switch (givenMethod)//switch statement to validate and construct the paymnet type
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
            } while (!methodIsValid);//loop doesn't break until a valid payment method has been provided
            return userPaymentMethod;//return valid payment method that user selected
        }
        //Method to validate the Cash payment method to ensure the given amount is greater than the amount owed and ensure input is a number
        public decimal ValidatePaymentAmount(decimal productCost)
        {
            decimal givenAmount = 0;
            int loopIteration = 0;
            do
            {
                //if amount is lower than amount due, iteration amount increases to 1 and loops
                if (loopIteration > 0)
                {
                    myFuncs.CenterText("Amount too low. Please supply a valid amount.\n");
                }
                myFuncs.CenterText("Please enter the amount of money you will be paying with\n");
                givenAmount = myFuncs.GetANumber();//makes sure its a valid number
                loopIteration++;
            } while (givenAmount < productCost);
            return givenAmount;//Returns given amount used to calculat the reciept and change in the payment type class
        }
        //Method to validate the card payment method to ensure the expiration date is not in the past
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
                try//try catch block to avoid exceptions from date not entered as numbers or no '/' to split by
                {
                    string[] currentValues = formattedDate.Split('/');
                    //int parse the month and year values to ensure numbers were entered and be able to compare 
                    if (int.Parse(currentValues[1]) == int.Parse(expirationValues[1])) // if the year is the same
                    {
                        if (int.Parse(currentValues[0]) <= int.Parse(expirationValues[0]))// if the expiration month is greater or the same
                        {
                            isValidDate = true;// the date is valid
                        }

                    }
                    else if (int.Parse(currentValues[1]) < int.Parse(expirationValues[1])) // if the expiration year is larger than current year
                    {
                        isValidDate = true;//the date is valid
                    }

                }
                catch (Exception)
                {
                   myFuncs.CenterText("Please ensure date is entered in correct format.\n");//gives user an error message if date is not input correctly
                }
                loopIteration++;
            } while (!isValidDate);//loop continues to a valid expiration date is provided
            return expirationDate;//return valid expiration date
        }
        //Method to validate the card payment class to ensure a 16 digit card numer is used (comes in as a string so no number validation needed)
        public string ValidateCardNumber()
        {
            string cardNumber = "";
            int loopIteration = 0;
            bool isValidCardNumber = false;
            do
            {
                //loop until valid card number
                if (loopIteration > 0)
                {
                    myFuncs.CenterText("Invalid card number.\n");
                }
                myFuncs.CenterText("Please enter your card number");
                cardNumber = myFuncs.CenteredInput();
                if (cardNumber.Length == 16)//validate 16 digit card number
                {
                    try//try/catch block to attempt a parse and ensure only numbers have been entered
                    {
                        long.Parse(cardNumber);
                        isValidCardNumber = true;
                    }
                    catch (Exception)
                    {
                        myFuncs.CenterText("Please ensure all entered characters are numbers");
                    }
                }
            } while (!isValidCardNumber);//loop continues until valid card number is provided
            return cardNumber;//return valid card number
        }
        //Method used to validate the card payment type method is using a proper 3 digit cvv code (comes in as a string so no number validation needed)
        public string ValidateCVV()
        {
            string cvvNumber = "";
            int loopIteration = 0;
            bool isValidCVVNumber = false;
            do
            {
                //loop until proper cvv is input
                if (loopIteration > 0)
                {
                    myFuncs.CenterText("Invalid CVV.\n");
                }
                myFuncs.CenterText("Please enter your CVV code");
                cvvNumber = myFuncs.CenteredInput();
                if (cvvNumber.Length == 3)//validate input lenght is 3
                {
                    try//try/catch block to attempt a parse and ensure only numbers have been entered
                    {
                        int.Parse(cvvNumber);
                        isValidCVVNumber = true;
                    }
                    catch (Exception)
                    {
                        myFuncs.CenterText("Please ensure all entered characters are numbers");
                    }
                }
            } while (!isValidCVVNumber);//loop continues until valid cvv code is provided
            return cvvNumber;//return valid cvv
        }
        //Method to validate the check payment type to ensure a proper check number is given and is 3 or 4 characters long (assuming all check #s start at 100)
        public string ValidateCheckNumber()
        {
            string checkNumber = "";
            int loopIteration = 0;
            bool isValidCheckNumber = false;
            do
            {
                if (loopIteration > 0)//display error message if previous loop was unsuccessful
                {
                    myFuncs.CenterText("Invalid check number.\n");
                }
                myFuncs.CenterText("Please enter your check number");
                checkNumber = myFuncs.CenteredInput();
                if (checkNumber.Length >= 3 && checkNumber.Length <= 4)//ensure check number length is valid
                {
                    try//try/catch block to attempt a parse and ensure only numbers have been entered
                    {
                        int.Parse(checkNumber);
                        isValidCheckNumber = true;
                    }
                    catch (Exception)
                    {
                        myFuncs.CenterText("Please ensure all entered characters are numbers");
                    }
                }
            } while (!isValidCheckNumber);//continue loop until valid check number is provided
            return checkNumber;//return valid check number
        }

        //Method to take in Payment Type, Subtotal, TaxTotal, Grand Total, Number of Items and write them to PurchaseLog.csv using streamwriter
        public void LogPurchase(string paymentType, decimal subTotal, decimal taxTotal, decimal grandTotal, int itemNum)
        {
            StreamWriter writer = new StreamWriter("../../PurchaseLog.csv", true);

            writer.AutoFlush = true;

            //Write items to csv file PaymentType, Subtotal, TaxTotal, GrandTotal, NumberOfItems
            writer.WriteLine($"{paymentType},{subTotal},{taxTotal},{grandTotal},{itemNum}");
            writer.Close();
        }
    }
}
