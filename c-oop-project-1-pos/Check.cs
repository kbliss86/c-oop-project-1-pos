using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    //Uses Process Payment Class as Parent Class
    public class Check : ProcessPayment
    {
        //pull in general purpose functions
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();

        static Validator validation = new Validator();

        public string checkNumber;

        public decimal checkAmount;

        private int itemCount;

        public Check(decimal theSub, decimal theGrand, decimal theTax) : base(theSub, theGrand, theTax) { }
        ////Override abstract method to process check specific payments (check number)
        public override void ProcessPayments()
        {
            //prompt for check number
            checkNumber = validation.ValidateCheckNumber();
            //prompt for check amount
            checkAmount = validation.ValidatePaymentAmount(base.GrandTotal);
            //Validate check amount is greater than or equal to amount owed - possibly use the validator class
        }
        //Override abstract method to display a check specific reciept (check number)
        public override void DisplayReciept(List<Product> purchasedItems)
        {
            itemCount = purchasedItems.Count;
            Art.GenerateDollarImage();
            //display items purchased            
            Product.DisplayCartList(purchasedItems);//subtotal
            //tax
            myFuncs.CenterText($"Total tax: ${base.TaxTotal}");
            //grand total            
            myFuncs.CenterText($"Grand total: ${base.GrandTotal}");
            //Display check number from process payment
            myFuncs.CenterText($"Check number: {checkNumber}");
            //display check amount from process payment
            myFuncs.CenterText($"Check amount: {checkAmount}");
            //display check change from process payment           
            myFuncs.CenterText($"Change due: ${checkAmount - base.GrandTotal}");
            validation.LogPurchase("Check", base.SubTotal, base.TaxTotal, base.GrandTotal, itemCount);//logs info about purchase to a CSV file
        }
    }
}
