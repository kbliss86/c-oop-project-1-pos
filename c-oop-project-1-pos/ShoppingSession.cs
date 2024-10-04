using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    public class ShoppingSession
    {    /************************************************************************************
         * Initialize Elements
         ************************************************************************************/
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();//Connect to Commonly Used Functions
        static Validator validation = new Validator();
        static List<Product> productList = new List<Product>();//list to be filled out by GenerateProductList()
        static List<Product> cart = new List<Product>();//List to generate as user adds items to card
        static decimal subTotal;
        /************************************************************************************
         * Main Program
         ************************************************************************************/
        public ShoppingSession()//Constructor
        {           
            productList = Product.GenerateProductList();//Generate Product List
            cart = new List<Product>();//Clear out the cart for a new order
        }
        public void StartShopping()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            myFuncs.CenterText($"Welcome to {Art.DisplayCompanyName()}");//Welcome Message
            Art.DisplayCustomLogo();

            //puase program to user can admire the logo
            myFuncs.PauseProgram();

            do//do-while loop - prompt user to pick an item by the item number in the list
            {
                /************************************************************************************
                * Menu Display
                ***********************************************************************************/
                bool displayProducts = true;//bool variable for if the user needs to see the menu again - ask user if they want to see the menu again after selecting they want to add more items
                if (cart.Count > 0)//if cart count is greater than one - ask question - if not then skip this and display the menu
                {
                    
                    Console.WriteLine("");
                    myFuncs.CenterText("Would you like view the menu again? (Y/N)?");

                    //Ask user to see if they want to view the menu
                    displayProducts = myFuncs.moreInput();
                }
                if (displayProducts)//if user wants to look at menu - display it - otherwise skip it and just add more stuff
                {
                    myFuncs.WriteSeparatorLine("Product Menu");//Display Product Menu
                    Product.DisplayProductList();
                }
                /************************************************************************************
                * Add Items to Card
                ***********************************************************************************/
                Console.WriteLine("");
                myFuncs.CenterText("Please Select an Item # from the menu to add to your cart: ");//Prompt user to select an item
                int item = myFuncs.GetANumber();//Item that will be added
                while(item > productList.Count() || item < 0)
                {
                    myFuncs.CenterText("Please Enter a Valid Number from the menu list");
                    item = myFuncs.GetANumber();
                }
                myFuncs.CenterText("How many do you want to add to your cart?");//Prompt user for quantity
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

                
                Console.WriteLine("");
                myFuncs.CenterText("Would you like to continue shopping? (Y/N)?");
            }
            while (myFuncs.moreInput());//ASk user if the want to add more items

            /************************************************************************************
            * Display Subtotal, tax, grand total using product class method
            ***********************************************************************************/
            myFuncs.WriteSeparatorLine("Grand Totals");//Display a separator line
            var (taxTotal, grandTotal) = Product.DisplayTotals(subTotal);//Display Totals from the method in Product class takes in subtotal and returns grand total and Tax total

            /************************************************************************************
            * Ask Payment Section
            ***********************************************************************************/
            myFuncs.WriteSeparatorLine("Payment Section");
            ProcessPayment userPaymentMethod = validation.ValidatePaymentMethod(subTotal, grandTotal, taxTotal);

            /************************************************************************************
            * Display Reciept
            ***********************************************************************************/
            myFuncs.WriteSeparatorLine("Reciept Section");
            myFuncs.CenterText(Art.DisplayCompanyName());
            userPaymentMethod.DisplayReciept(cart);

            //Return to the original menu for a new order. Clear Card, Clear SubTotal
            productList.Clear();
            cart.Clear();
            subTotal = 0;
        }//End Main
    }//End Class
}//End Namespace
