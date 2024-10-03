using GeneralPurposeFunctions;
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
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();

        static Validator validation = new Validator();

        private string cardNumber;

        private string expirationDate;

        private string cvv;

        const string INFO_OBSCURE = "XXXXXXXXXXXX";
        public Card(decimal theSub, decimal theGrand, decimal theTax) : base(theSub, theGrand, theTax) { }
        public const decimal TAX_AMOUNT = .06m;
        public override void ProcessPayments()
        {
            
            expirationDate = validation.ValidateCardExpiration();//check date first so they can use a different card if expired
            
            cardNumber = validation.ValidateCardNumber();
            
            cvv = validation.ValidateCVV();
            //amount owed will be equal to the amount "given" - no calculation needed
        }

        //Find a way to obscure the First 12 numbers in card display
        //sub string to start at 12 character and join with another "xxx" string
        public override void DisplayReciept(List<Product> purchasedItems)
        {
            Art.GenerateDollarImage();
            //display items purchased
            Product.DisplayCartList(purchasedItems);//subtotal
            //tax
            myFuncs.CenterText($"Total tax: ${base.TaxTotal}");
            //grand total            
            myFuncs.CenterText($"Grand total: ${base.GrandTotal}");
            //display Card number (redacted) from process payment
            myFuncs.CenterText($"Card number: {INFO_OBSCURE}{cardNumber.Substring(12,4)}");
        }
    }
}
