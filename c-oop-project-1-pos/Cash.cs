using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    public class Cash : ProcessPayment
    {
        public decimal CashTendered { get; set; }
        public decimal CashChange { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public override void ProcessPayments(decimal amount)
        {
            //ask for cash amount entered
            //Validate cash amount is greater than or equal to amount owed - possibly use the validator class
            //caclualte change
            return;
        }
        public override string DisplayReciept(List<Product> purchasedItems)
        {
            //display items purchased
            //subtotal
            //tax
            //grand total
            //cash tendered (From process payment)
            //change due (from process payment)
            return "Cash Tendered: " + CashTendered;//example of reciept display
        }

    }
}
