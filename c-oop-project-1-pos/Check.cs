using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    public class Check : ProcessPayment
    {
        public string CheckNumber { get; set; }//Needed for check processing - reciept display
        public decimal CheckAmount { get; set; }//needed for check processing - reciept display
        public decimal CheckChange { get; set; }//needed for check processing - reciept display
        public decimal Subtotal { get; set; }//needed for reciept display - tax Caclulation
        public decimal Tax { get; set; }//needed for reciept display - static 6% tax rate
        public decimal Total { get; set; }//needed for reciept display - total of all goods at purchase + Tax

        public override void ProcessPayments(decimal amount)
        {
            //prompt for check number
            //prompt for check amount
            //Validate check amount is greater than or equal to amount owed - possibly use the validator class
            //calculate change
            return;
        }
        public override string DisplayReciept(List<Product> purchasedItems)
        {
            //display items purchased
            //subtotal
            //tax
            //grand total
            //Display check number from process payment
            //display check amount from process payment
            //display check change from process payment
            return "Check Number: " + CheckNumber + " Check Amount: " + CheckAmount + " Check Change: " + CheckChange;//example of reciept display
        }
    }
}
