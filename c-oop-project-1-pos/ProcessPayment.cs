using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    public abstract class ProcessPayment
    {
        //takes ain an "amount" = to total of all goods at purchase and processes payment/reciept based on payment type (Cash/Credit/Debit)
        public decimal Amount { get; set; }//Do we need this?
        //main program will provide the total amount for all items purchased
        public abstract void ProcessPayments(decimal amount);
        //main program will provide a list of all items purchased
        public abstract string DisplayReciept(List<Product> purchasedItems);
        //public abstract class for validation of payment - should verify the payment amount is greater than or equal to the amount owed

        //public abstract class for inputing valid card information (number 16 digits, date format 10/2020, cvv 3 digits)

    }


}
