using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    //Add Comments/Fix Comments
    public class Cash : ProcessPayment
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();

        static Validator validation = new Validator();

        private decimal cashTendered;


        public Cash(decimal theSub, decimal theGrand, decimal theTax) : base(theSub, theGrand, theTax) { }

        public override void ProcessPayments()
        {
            //ask for cash amount entered

            decimal cashAmount = validation.ValidatePaymentAmount(base.GrandTotal);
            cashTendered = cashAmount;
            //caclualte change

        }

        public override void DisplayReciept(List<Product> purchasedItems)
        {
            Art.GenerateDollarImage();
            //display items purchased            
            Product.DisplayCartList(purchasedItems);
            //subtotal
            //Console.WriteLine($"Sub total: ${base.SubTotal}");
            //tax
            myFuncs.CenterText($"Total tax: ${base.TaxTotal}");
            //grand total            
            myFuncs.CenterText($"Grand total: ${base.GrandTotal}");
            //cash tendered (From process payment)
            //change due (from process payment)
            myFuncs.CenterText($"Change due: ${cashTendered - base.GrandTotal}");
        }

    }
}
