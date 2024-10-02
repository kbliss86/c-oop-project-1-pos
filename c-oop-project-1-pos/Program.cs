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
    //Move the subtotal/Grandtotal/Tax into a sub class and create a display total method instead having them on the main - DONE
    //Create a subclass that operates a single "shopping instance" that we call from main instead of having on main - that way we cna have multiple shopping experiences without haveing to close and reopen the program - DONE
        //Code lines 19 - 86 - remove line 37 and leave in Program Loop - DONE
        //add in master do while, runs the POS transaction, then once payment is complete, restart POS - DONE
    //XXX the credit card number
    //Create a Gift Card Payment Type
    //change values in CSV to make it a different store
    //Add config file to customize Console.Outputs ("Hey Welcome to hot topic") etc.

    internal class Program
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions(); //Can probably getting rid of

        static void Main(string[] args)
        {
            //bool to control session loop
            bool keepShopping = true;
            //do while to loop through shopping sessions
            do
            {
                //Create a new shopping session
                ShoppingSession session = new ShoppingSession();
                //Start the shopping session
                session.StartShopping();
                //Ask the user if they want to keep shopping
                keepShopping = myFuncs.moreSession();
            }
            while (keepShopping);//End do-while loop

            Console.WriteLine("Thank you for shopping with us!");//Thank you Message

        }//End Main
    }//End Class
}//End NameSpace
