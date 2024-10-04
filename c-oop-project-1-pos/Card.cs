using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    //Uses Process Payment Class as Parent Class
    public class Card : ProcessPayment
    {
        //pull in general purpose functions
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();

        static Validator validation = new Validator();

        private string cardNumber;

        private string expirationDate;

        private string cvv;

        private int itemCount;
        //string used to obscure first 12 digits in card number
        const string INFO_OBSCURE = "XXXXXXXXXXXX";
        
        public Card(decimal theSub, decimal theGrand, decimal theTax) : base(theSub, theGrand, theTax) { }
        public const decimal TAX_AMOUNT = .06m;
        //Override abstract method to process card paymenr (card number, expiry date, cvv) - No Change calculated
        public override void ProcessPayments()
        {
            
            expirationDate = validation.ValidateCardExpiration();//check date first so they can use a different card if expired
            
            cardNumber = validation.ValidateCardNumber();
            
            cvv = validation.ValidateCVV();
            //amount owed will be equal to the amount "given" - no calculation needed
        }
        //Override abstract method to display a card specific reciept(obscured card #)
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
            //display Card number (redacted) from process payment
            myFuncs.CenterText($"Card number: {INFO_OBSCURE}{cardNumber.Substring(12,4)}");
            validation.LogPurchase("Card", base.SubTotal, base.TaxTotal, base.GrandTotal, itemCount);//logs info about purchase to a CSV file
        }
    }
}
