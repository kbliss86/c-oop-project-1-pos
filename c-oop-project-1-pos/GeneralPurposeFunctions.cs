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
            CenterText("Press any key to continue...");
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
                // Validate users input is Y or N
                whatUserTyped = CenteredInput();

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
                    CenterText("Please enter a valid 'Y' or 'N' value");
                }
            } while (getInput); // Loop while we get input

            return isThereInput;

        }  // End of moreInput()


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

                // Get the input from the user
                string userInput = CenteredInput();

                try // We want to handle an Exception that might occur in this block of code
                {
                    // Convert the user input to a double
                    theValue = int.Parse(userInput); // Could cause an Exception
                    isValidNumber = true;  // if .Parse() worked we have a valid number
                }
                // catch (Exception exceptionBlock) will handle every Exception that can occur
                catch (FormatException exceptionBlock) // Handle a FormatException in previous try block
                {
                    Console.WriteLine("");
                    CenterText("----- Please Enter a Valid number ------");
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
        /************************************************************************************
         * Method to center-align the users cursor for centered input 
         ***********************************************************************************/
        public string CenteredInput()
        {
            string input = "";
            int windowWidth = Console.WindowWidth;
            int cursorLeft = (windowWidth - input.Length) / 2;

            //Set Cursos position to similate Centered input
            Console.SetCursorPosition(cursorLeft, Console.CursorTop);

            //Capture Input
            input = Console.ReadLine();

            return input;
        }

    } // End of class GeneralPurposeFunctions
}
