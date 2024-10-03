using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralPurposeFunctions;

namespace c_oop_project_1_pos
{
    public static class Art
    {
        static CommonlyUsedFunctions myFuncs = new CommonlyUsedFunctions();//Connect to Commonly Used Functions
        public static void GeneratePosImage() 
        {
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
        }

        public static void GenerateDollarImage()
        {            
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
        }

        public static void DisplayCustomLogo()
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Check if the file exists
            if (File.Exists("../../Logo.txt"))//Needs File Path
            {
                // Use StreamReader to read the file line by line
                using (StreamReader reader = new StreamReader("../../Logo.txt", Encoding.UTF8))//Needs File Path
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    // Read and display the content line by line
                    //string[] lines = File.ReadAllLines(filePath);
                    //foreach (string line in lines)
                    {
                        myFuncs.CenterText(line);
                    }
                }
            }
            else
            {
                myFuncs.CenterText("The specified file could not be found.");
            }
        }
    }
}
