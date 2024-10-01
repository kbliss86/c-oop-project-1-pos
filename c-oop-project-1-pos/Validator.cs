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
                    Console.WriteLine("Invalid payment method. Please enter a valid payment method\n");
                }
                Console.WriteLine("How would you like to pay? (Cash/Card/Check)");
                string givenMethod = Console.ReadLine().ToLower();
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
                    Console.WriteLine("Amount too low. Please supply a valid amount.\n");
                }
                Console.Write("What amount will you be paying with? ");
                givenAmount = myFuncs.GetANumber();
                loopIteration++;
            } while (givenAmount < productCost);
            return givenAmount;
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
                    Console.WriteLine("Invalid card number.\n");
                }
                Console.WriteLine("Please enter your card number");
                cardNumber = Console.ReadLine();
                if (cardNumber.Length == 16)
                {
                    try
                    {
                        long.Parse(cardNumber);
                        isValidCardNumber = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please ensure all entered characters are numbers");
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
                    Console.WriteLine("Invalid CVV.\n");
                }
                Console.WriteLine("Please enter your CVV code");
                cvvNumber = Console.ReadLine();
                if (cvvNumber.Length == 3)
                {
                    try
                    {
                        int.Parse(cvvNumber);
                        isValidCVVNumber = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please ensure all entered characters are numbers");
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
                    Console.WriteLine("Invalid check number.\n");
                }
                Console.WriteLine("Please enter your check number");
                checkNumber = Console.ReadLine();
                if (checkNumber.Length >= 3 && checkNumber.Length <= 4)
                {
                    try
                    {
                        int.Parse(checkNumber);
                        isValidCheckNumber = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please ensure all entered characters are numbers");
                    }
                }
            } while (!isValidCheckNumber);
            return checkNumber;
        }
    }
}
