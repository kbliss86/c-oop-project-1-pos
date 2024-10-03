using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    //ADD COMMENTS
    public abstract class ProcessPayment
    {
        private decimal subTotal;

        private decimal grandTotal;

        private decimal taxTotal;

        public decimal SubTotal
        {
            get { return subTotal; }
        }
        public decimal GrandTotal
        {
            get { return grandTotal; }
        }
        public decimal TaxTotal
        {
            get { return taxTotal; }
        }
        protected ProcessPayment(decimal theSub, decimal theGrand, decimal theTax)
        {
            subTotal = theSub;
            grandTotal = theGrand;
            taxTotal = theTax;
        }

        public abstract void ProcessPayments();

        public abstract void DisplayReciept(List<Product> purchasedItems);
    }


}
