using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    /************************************************************************************
    * Extra Stuff to Add since we have time
    ************************************************************************************/
    //Move the subtotal/Grandtotal/Tax into a sub class and create a display total method instead having them on the main
    //Create a subclass that operates a single "shopping instance" that we call from main instead of having on main - that way we cna have multiple shopping experiences without haveing to close and reopen the program
        //Code lines 19 - 86 - remove line 37 and leave in Program Loop
        //add in master do while, runs the POS transaction, then once payment is complete, restart POS
    //XXX the credit card number
    //Create a Gift Card Payment Type
    //change values in CSV to make it a different store
    //Add config file to customize Console.Outputs ("Hey Welcome to hot topic") etc.

    internal class Program
    {    /************************************************************************************
         * Initialize Elements
         ************************************************************************************/
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();//Connect to Commonly Used Functions
        static Validator validation = new Validator();
        static List<Product> productList = new List<Product>();//list to be filled out by GenerateProductList()
        static List<Product> cart = new List<Product> ();//List to generate as user adds items to card
        const decimal TAX_AMOUNT = .06m;//Move to Sub Class -
        /************************************************************************************
         * Main Program
         ************************************************************************************/
        static void Main(string[] args)
        {
            decimal subTotal = 0;
            decimal grandTotal = 0;//***********Move these to sub class - Create New Method for Displaying Cart Totals After user ends loop**********
            decimal taxTotal = 0;

            Console.WriteLine("Welcome to the point of sale terminal");//Welcome Message
            productList = Product.GenerateProductList();//Generate Product List
            do//do-while loop - prompt user to pick an item by the item number in the list
            {
                /************************************************************************************
                * Menu Display
                ***********************************************************************************/
                bool displayProducts = true;//bool variable for if the user needs to see the menu again - ask user if they want to see the menu again after selecting they want to add more items
                if (cart.Count > 0)//if cart count is greater than one - ask question - if not then skip this and display the menu
                    {
                        //Ask user to see if they want to view the menu
                        displayProducts = myFuncs.moreMenu();
                    }
                    if (displayProducts)//if user wants to look at menu - display it - otherwise skip it and just add more stuff
                {
                    myFuncs.WriteSeparatorLine("Product Menu");//Display Product Menu
                    Product.DisplayProductList();
                }
                /************************************************************************************
                * Add Items to Card
                ***********************************************************************************/
                Console.WriteLine("Please Select an Item # from the menu to add to your cart: ");//Prompt user to select an item
                int item = myFuncs.GetANumber();//Item that will be added
                Console.WriteLine("How many do you want to add to your cart?");//Prompt user for quantity
                int quantity = myFuncs.GetANumber();//Quantitity of items to be added
                    for (int i = 0; i < quantity; i++)//Loop to add quantity of items user selected
                    {
                        cart.Add(productList[item - 1]);//add to list using IdNum
                    }
                /************************************************************************************
                * Display Items in Card and Running Sub Totals
                ***********************************************************************************/
                myFuncs.WriteSeparatorLine("Shopping Cart");//Display Shopping Card
                subTotal = Product.DisplayCartList(cart);//Display Contents of Cart from the method in Product class

            }
                while (myFuncs.moreInput()) ;//ASk user if the want to add more items
            taxTotal = Math.Round(subTotal * TAX_AMOUNT, 2);//*********Move these to sub class - Create New Method for Displaying Cart Totals After user ends loop*********
            grandTotal = taxTotal + subTotal;//***********Move these to sub class - Create New Method for Displaying Cart Totals After user ends loop**********
            /************************************************************************************
            * Ask Payment Section
            ***********************************************************************************/
            myFuncs.WriteSeparatorLine("Payment Section");
            Console.WriteLine($"Sub total: ${subTotal}\nTax total: ${taxTotal}\nGrand total: ${grandTotal}");//***********Move these to sub class - Create New Method for Displaying Cart Totals After user ends loop**********
            ProcessPayment userPaymentMethod = validation.ValidatePaymentMethod(subTotal, grandTotal, taxTotal);

            /************************************************************************************
            * Display Reciept
            ***********************************************************************************/
            myFuncs.WriteSeparatorLine("Reciept Section");
            userPaymentMethod.DisplayReciept(cart);

            //Return to the original menu for a new order. (Hint: you’ll want an array or List to keep track of what’s been ordered!)

        }//End Main
    }//End Class
}//End NameSpace
