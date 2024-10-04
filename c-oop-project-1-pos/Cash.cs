using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    //Uses Process Payment Class as Parent Class
    public class Cash : ProcessPayment
    {
        //pull in general purpose functions
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();

        static Validator validation = new Validator();

        private decimal cashTendered;

        private int itemCount;


        public Cash(decimal theSub, decimal theGrand, decimal theTax) : base(theSub, theGrand, theTax) { }
        //Override abstract method to process cash specific payment and return tax/total/change
        public override void ProcessPayments()
        {
            //ask for cash amount entered

            decimal cashAmount = validation.ValidatePaymentAmount(base.GrandTotal);
            cashTendered = cashAmount;
            //caclualte change

        }
        //Override abstract method to show Cash Specific Reciept
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
            //change due (from process payment)
            myFuncs.CenterText($"Change due: ${cashTendered - base.GrandTotal}");

            validation.LogPurchase("Cash",base.SubTotal,base.TaxTotal,base.GrandTotal,itemCount);//logs info about purchase to a CSV file
        }

    }
}
