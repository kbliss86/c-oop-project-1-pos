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

        //getters to access private properties from sub classes
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
        //public class for payment types to use
        public abstract void ProcessPayments();
        //public class for payment types to use - provide the product list
        public abstract void DisplayReciept(List<Product> purchasedItems);
    }


}
