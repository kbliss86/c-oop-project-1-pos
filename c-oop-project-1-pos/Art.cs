using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralPurposeFunctions;

namespace c_oop_project_1_pos
{
    //Class for handling and displaying ASCII images
    public static class Art
    {
        //displays the POS logo at the begining of the program
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();//Connect to Commonly Used Functions
        public static void GeneratePosImage() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("");
            myFuncs.CenterText("PPPPPPPPPPPPPPPPP                OOOOOOOOO                SSSSSSSSSSSSSSS              ");
            myFuncs.CenterText("P::::::::::::::::P             OO:::::::::OO            SS:::::::::::::::S            ");
            myFuncs.CenterText("P::::::PPPPPP:::::P          OO:::::::::::::OO         S:::::SSSSSS::::::S            ");
            myFuncs.CenterText("PP:::::P     P:::::P        O:::::::OOO:::::::O        S:::::S     SSSSSSS            ");
            myFuncs.CenterText("  P::::P     P:::::P        O::::::O   O::::::O        S:::::S                        ");
            myFuncs.CenterText("  P::::P     P:::::P        O:::::O     O:::::O        S:::::S                        ");
            myFuncs.CenterText("  P::::PPPPPP:::::P         O:::::O     O:::::O         S::::SSSS                     ");
            myFuncs.CenterText("  P:::::::::::::PP          O:::::O     O:::::O          SS::::::SSSSS                ");
            myFuncs.CenterText("  P::::PPPPPPPPP            O:::::O     O:::::O            SSS::::::::SS              ");
            myFuncs.CenterText("  P::::P                    O:::::O     O:::::O               SSSSSS::::S             ");
            myFuncs.CenterText("  P::::P                    O:::::O     O:::::O                    S:::::S            ");
            myFuncs.CenterText("  P::::P                    O::::::O   O::::::O                    S:::::S            ");
            myFuncs.CenterText("PP::::::PP                  O:::::::OOO:::::::O        SSSSSSS     S:::::S            ");
            myFuncs.CenterText("P::::::::P           ......  OO:::::::::::::OO  ...... S::::::SSSSSS:::::S ......      ");
            myFuncs.CenterText("P::::::::P           .::::.    OO:::::::::OO    .::::. S:::::::::::::::SS  .::::.      ");
            myFuncs.CenterText("PPPPPPPPPP           ......      OOOOOOOOO      ......  SSSSSSSSSSSSSSS    ......      ");
            myFuncs.CenterText("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Displays Dollare sign $$ for reciept
        public static void GenerateDollarImage()
        {            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            myFuncs.CenterText("       $$$$$      ");
            myFuncs.CenterText("       $:::$      ");
            myFuncs.CenterText("   $$$$$:::$$$$$$ ");
            myFuncs.CenterText(" $$::::::::::::::$");
            myFuncs.CenterText("$:::::$$$$$$$::::$");
            myFuncs.CenterText("$::::$       $$$$$");
            myFuncs.CenterText("$::::$            ");
            myFuncs.CenterText("$::::$            ");
            myFuncs.CenterText("$:::::$$$$$$$$$   ");
            myFuncs.CenterText(" $$::::::::::::$$ ");
            myFuncs.CenterText("   $$$$$$$$$:::::$");
            myFuncs.CenterText("            $::::$");
            myFuncs.CenterText("            $::::$");
            myFuncs.CenterText("$$$$$       $::::$");
            myFuncs.CenterText("$::::$$$$$$$:::::$");
            myFuncs.CenterText("$::::::::::::::$$ ");
            myFuncs.CenterText(" $$$$$$:::$$$$$   ");
            myFuncs.CenterText("      $:::$       ");
            myFuncs.CenterText("      $$$$$       ");
            myFuncs.CenterText("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Parse the Logo.txt file for a custom brand ASCII logo provided by the customer
        public static void DisplayCustomLogo()
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Check if the file exists
            if (File.Exists("../../Logo.txt"))//Validate File exists before running streamreader
            {
                // Use StreamReader to read the file line by line
                StreamReader reader = new StreamReader("../../Logo.txt", Encoding.UTF8);//StreamReader to locate and read file
                Console.WriteLine("");
                Console.WriteLine("");
                using (reader)
                {
                    //Change Color to Red (make this a configurable value in the future)
                    Console.ForegroundColor = ConsoleColor.Red;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        myFuncs.CenterText(line);
                    }
                }
                reader.Close();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                myFuncs.CenterText("The specified file could not be found.");
            }
        }

        //Pull Company name from config.txt file and store is a string variable using StreamReader
        public static string DisplayCompanyName()
        {
            string companyName = "point of sale terminal";
            if (File.Exists("../../Config.txt"))//Validate File exists before running streamreader
            {
                StreamReader reader = new StreamReader("../../Config.txt");//StreamReader to locate and read file
                using (reader)
                {
                    companyName = reader.ReadLine();
                }
            }
            return companyName;
        }
    }
}
