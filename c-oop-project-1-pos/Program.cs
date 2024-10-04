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

    internal static class Program
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();
        //Code used to Open Console at full Screen size - this helps with centering the text/input in the center of the app
        //--Console Code Start--\\
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MAXIMIZE = 3;
        //--Console Code End--\\
        static void Main(string[] args)
        {
            //Open Console at full Screen size
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);

            //Generate the POS image
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

                // Ask the user if they have any numbers to enter (Y/N)
                Console.WriteLine("");
                myFuncs.CenterText("Would you like to start another transaction? (Y/N)?");
                //Ask the user if they want to keep shopping
                keepShopping = myFuncs.moreInput();
            }
            while (keepShopping);//End do-while loop
            Console.WriteLine("");
            Console.WriteLine("");
            myFuncs.CenterText($"Thank you for shopping at {Art.DisplayCompanyName()}");//Thank you Message
            myFuncs.PauseProgram();

        }//End Main
    }//End Class
}//End NameSpace
