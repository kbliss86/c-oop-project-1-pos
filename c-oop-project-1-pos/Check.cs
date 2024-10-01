using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    //Add Comments/Fix Comments
    public class Check : ProcessPayment
    {
        static Validator validation = new Validator();

        public string checkNumber;
        public decimal checkAmount;

        public Check(decimal theSub, decimal theGrand, decimal theTax) : base(theSub, theGrand, theTax) { }

        public override void ProcessPayments()
        {
            //prompt for check number
            checkNumber = validation.ValidateCheckNumber();
            //prompt for check amount
            checkAmount = validation.ValidatePaymentAmount(base.GrandTotal);
            //Validate check amount is greater than or equal to amount owed - possibly use the validator class
        }
        public override void DisplayReciept(List<Product> purchasedItems)
        {
            //display items purchased            
            Product.DisplayCartList(purchasedItems);
            //subtotal
            //Console.WriteLine($"Sub total: ${base.SubTotal}");
            //tax
            Console.WriteLine($"Total tax: ${base.TaxTotal}");
            //grand total            
            Console.WriteLine($"Grand total: ${base.GrandTotal}");
            //Display check number from process payment
            Console.WriteLine($"Check number: {checkNumber}");
            //display check amount from process payment
            Console.WriteLine($"Check amount: {checkAmount}");
            //display check change from process payment           
            Console.WriteLine($"Change due: ${checkAmount - base.GrandTotal}");
        }
    }
}
