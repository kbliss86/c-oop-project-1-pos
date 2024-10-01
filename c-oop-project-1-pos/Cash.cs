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
            //display items purchased            
            Product.DisplayCartList(purchasedItems);
            //subtotal
            //Console.WriteLine($"Sub total: ${base.SubTotal}");
            //tax
            Console.WriteLine($"Total tax: ${base.TaxTotal}");
            //grand total            
            Console.WriteLine($"Grand total: ${base.GrandTotal}");
            //cash tendered (From process payment)
            //change due (from process payment)
            Console.WriteLine($"Change due: ${cashTendered - base.GrandTotal}");
        }

    }
}
