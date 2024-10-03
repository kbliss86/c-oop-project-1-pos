using GeneralPurposeFunctions;
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
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();

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
        }
    }
}
