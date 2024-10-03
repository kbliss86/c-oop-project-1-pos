using System;
using System.Diagnostics.Eventing.Reader;

namespace GeneralPurposeFunctions
{
    public class CommonlyUsedFunctions
    {
        /************************************************************************************
         * Display a separator line block with a message
         ************************************************************************************/
        public void WriteSeparatorLine(string message)
        {
            Console.WriteLine("");
            CenterText("------------------------------------------------------------------------------");
            CenterText($"{message}");
            CenterText("----------------------------------------------------------------------------\n");

        } // End of WriteSeparatorLine()

        /************************************************************************************
         * Pause program until user presses the enter key
         ***********************************************************************************/
        public void PauseProgram()
        {
            Console.WriteLine("");
            CenterText("Press enter to continue...");
            Console.ReadLine();
        } // End of PauseProgram()

        /************************************************************************************
         * Return a boolean value to indicate if the user has more input
         ************************************************************************************/
        public bool moreInput()
        {
            bool isThereInput = false;  // Hold teh return value 

            string whatUserTyped = "";     // Hold what the user enters

            bool getInput = true;   // Control the user interaction loop

            do
            {
                // Ask the user if they have any numbers to enter (Y/N)
                Console.WriteLine("");
                CenterText("Would you like to continue shopping? (Y/N)?");
                whatUserTyped = CenteredInput();
                //whatUserTyped = Console.ReadLine();

                whatUserTyped = whatUserTyped.ToUpper();

                string firstChar = whatUserTyped.Substring(0, 1);

                if (firstChar == "Y")
                {
                    getInput = false;
                    isThereInput = true;
                }
                else if (firstChar == "N")
                {
                    getInput = false;
                    isThereInput = false;
                }
                else
                {
                    getInput = true;
                }
            } while (getInput); // Loop while we get input

            return isThereInput;

        }  // End of moreInput()

        /************************************************************************************
        * Return a boolean value to indicate if the user has more inputwants to continue to view the menu
        * ***********************************/
        public bool moreMenu()
        {
            bool isThereInput = false;  // Hold teh return value 

            string whatUserTyped = "";     // Hold what the user enters

            bool getInput = true;   // Control the user interaction loop

            do
            {
                // Ask the user if they have any numbers to enter (Y/N)
                Console.WriteLine("");
                CenterText("Would you like view the menu again? (Y/N)?");
                whatUserTyped = CenteredInput();
                //whatUserTyped = Console.ReadLine();

                whatUserTyped = whatUserTyped.ToUpper();

                string firstChar = whatUserTyped.Substring(0, 1);

                if (firstChar == "Y")
                {
                    getInput = false;
                    isThereInput = true;
                }
                else if (firstChar == "N")
                {
                    getInput = false;
                    isThereInput = false;
                }
                else
                {
                    getInput = true;
                }
            } while (getInput); // Loop while we get input

            return isThereInput;

        }  // End of moreInput()

        /************************************************************************************
        * Return a boolean value to indicate if the user has more input wants to continue to start a new session
        * ***********************************/
        public bool moreSession()
        {
            bool isThereInput = false;  // Hold teh return value 

            string whatUserTyped = "";     // Hold what the user enters

            bool getInput = true;   // Control the user interaction loop

            do
            {
                // Ask the user if they have any numbers to enter (Y/N)
                Console.WriteLine("");
                CenterText("Would you like to start another transaction? (Y/N)?");
                whatUserTyped = CenteredInput();
                //whatUserTyped = Console.ReadLine();

                whatUserTyped = whatUserTyped.ToUpper();

                string firstChar = whatUserTyped.Substring(0, 1);

                if (firstChar == "Y")
                {
                    getInput = false;
                    isThereInput = true;
                }
                else if (firstChar == "N")
                {
                    getInput = false;
                    isThereInput = false;
                }
                else
                {
                    getInput = true;
                }
            } while (getInput); // Loop while we get input

            return isThereInput;

        }  // End of moreSession()

        /************************************************************************************
         * This method will get a numeric value from the user
         ***********************************************************************************/

        public int GetANumber()
        {
            // define a variable for the return value
            int theValue = 0;

            // Ask the user for a numeric value and have them keep trying until we get one

            bool isValidNumber = false;  // Determine is user entered a valid value

            // Loop until we get a valid numeric value

            do  // do loop is used so we ask the user for a number at least once
            {
                // Prompt the user to enter a numeric value
                CenterText("Please enter a number");

                // Get the input from the user
                string userInput = CenteredInput();
                //string userInput = Console.ReadLine();

                try // We want to handle an Exception that might occur in this block of code
                {
                    // Convert the user input to a double
                    theValue = int.Parse(userInput); // Could cause an Exception
                    isValidNumber = true;  // if .Parse() worked we have a valid number
                }
                // catch (Exception exceptionBlock) will handle every Exception that can occur
                catch (FormatException exceptionBlock) // Handle a FormatException in previous try block
                {
                    CenterText("\n----- Uh-oh Uh-oh Uh-oh ------");
                    CenterText("There is problem with " + userInput);
                    CenterText(exceptionBlock.Message); // Display the system message for the error
                    CenterText("------ Uh-oh Uh-oh Uh-oh ------\n");
                }
            } while (!isValidNumber); // Loop while we don't have a valid number

            // return the double value from the user input
            return theValue;
        } // End of getANumber() method

        /************************************************************************************
         * Method to center-align a string based on the console width
         ***********************************************************************************/
        public void CenterText(string text)
        {
            // Get the current console width
            int windowWidth = Console.WindowWidth;

            // Calculate the starting position to center the text
            int leftPadding = (windowWidth - text.Length) / 2;

            // Print the line with leading spaces to center it
            Console.WriteLine(new string(' ', Math.Max(leftPadding, 0)) + text);
        }

        public string CenteredInput()
        {
            string input = "";
            int windowWidth = Console.WindowWidth;
            int cursorLeft = (windowWidth - input.Length) / 2;

            //Set Cursos position to similate Centered input
            Console.SetCursorPosition(cursorLeft, Console.CursorTop);

            //Capture Input
            input = Console.ReadLine();

            //Center users input
            //CenterText(input);

            return input;
        }

    } // End of class GeneralPurposeFunctions
}
