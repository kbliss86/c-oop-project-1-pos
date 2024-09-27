using GeneralPurposeFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop_project_1_pos
{
    internal class Program
    {    /************************************************************************************
         * Initialize Elements
         ************************************************************************************/
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();//Connect to Commonly Used Functions
        static List<Product> productList = new List<Product>();//list to be filled out by GenerateProductList()
        static List<Product> cart = new List<Product> ();//List to generate as user adds items to card
        /************************************************************************************
         * Main Program
         ************************************************************************************/
        static void Main(string[] args)
        {

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
                Product.DisplayCartList(cart);//Display Contents of Cart from the method in Product class
            }
                while (myFuncs.moreInput()) ;//ASk user if the want to add more items

            /************************************************************************************
            * Ask Payment Section
            ***********************************************************************************/
            myFuncs.WriteSeparatorLine("Payment Section");
            //prompt user to select payment type - use a switch statment and run different class methods with polymorphism

            /************************************************************************************
            * Display Reciept
            ***********************************************************************************/
            myFuncs.WriteSeparatorLine("Reciept Section");
                //Display Reciept - use a switch statement to display different reciepts based on payment type chosen using polymorphism

            
         }//End Main
    }//End Class
}//End NameSpace
