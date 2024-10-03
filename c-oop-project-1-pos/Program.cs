using GeneralPurposeFunctions;
using System;
using System.Runtime.InteropServices;
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
    //change values in CSV to make it a different store
    //Add config file to customize Console.Outputs ("Hey Welcome to hot topic") etc.
    //Add Color to Console Output

    internal static class Program
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions(); //Can probably getting rid of

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MAXIMIZE = 3;
        static void Main(string[] args)
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);

            Art.GeneratePosImage();
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

            myFuncs.CenterText("Thank you for shopping with us!");//Thank you Message

        }//End Main
    }//End Class
}//End NameSpace
