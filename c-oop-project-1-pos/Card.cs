using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    public class Card : ProcessPayment
    {
        //Add Comments/Fix Comments
        static Validator validation = new Validator();

        private string cardNumber;

        private string expirationDate;

        private string cvv;

        private decimal cashTendered;
        public Card(decimal theSub, decimal theGrand, decimal theTax) : base(theSub, theGrand, theTax) { }
        public const decimal TAX_AMOUNT = .06m;
        public override void ProcessPayments()
        {
            //prompt for card number
            cardNumber = validation.ValidateCardNumber();
            //prompt for expiry date
            //prompt for CVV code
            cvv = validation.ValidateCVV();
            //amount owed will be equal to the amount "given" - no calculation needed
        }
        //Find a way to obscure the First 12 numbers in card display
        //sub string to start at 12 character and join with another "xxx" string
        public override void DisplayReciept(List<Product> purchasedItems)
        {
            //display items purchased
            Product.DisplayCartList(purchasedItems);
            //subtotal
            // Console.WriteLine($"Sub total: ${base.SubTotal}");
            //tax
            Console.WriteLine($"Total tax: ${base.TaxTotal}");
            //grand total            
            Console.WriteLine($"Grand total: ${base.GrandTotal}");
            //display Card number (redacted) from process payment
            Console.WriteLine($"Card number: {cardNumber}");
        }
    }
}
