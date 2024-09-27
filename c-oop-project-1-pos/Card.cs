using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    public class Card : ProcessPayment
    {
        public string CardNumber { get; set; }//needed for car processing - reciept display
        public string ExpirationDate { get; set; }//needed for card processing - reciept display
        public string CVV { get; set; }//needed for card processing - reciept display
        public decimal Subtotal { get; set; }//needed for reciept display - tax Caclulation
        public decimal Tax { get; set; }//needed for reciept display - static 6% tax rate
        public decimal Total { get; set; }//needed for reciept display - total of all goods at purchase + Tax
        public override void ProcessPayments(decimal amount)
        {
            //prompt for card number
            //prompt for expiry date
            //prompt for CVV code
            //amount owed will be equal to the amount "given" - no calculation needed
            return;
        }
        public override string DisplayReciept(List<Product> purchasedItems)
        {
            //display items purchased
            //subtotal
            //tax
            //grand total
            //display Card number (redacted) from process payment
            return "Card Number: " + CardNumber + " Expiration Date: " + ExpirationDate + " CVV: " + CVV;//example of reciept display
        }
    }
}
