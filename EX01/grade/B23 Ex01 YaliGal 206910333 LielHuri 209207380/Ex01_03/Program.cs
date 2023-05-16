using System;

namespace Ex01_03
{
    // $G$ CSS-999 (-2) The Class must have an access modifier
    class Program
    {
        // $G$ CSS-999 (-0) The method must have an access modifier
        static void Main()
        {
            printAsterikDiamond();
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }
        // $G$ CSS-999 (-0) The method must have an access modifier
        static void printAsterikDiamond()
        {
            int heightOfDiamond = getUserInput();

            Ex01_02.Program.PrintAsterikDiamond(heightOfDiamond);
        }

        // $G$ CSS-999 (-0) The method must have an access modifier
        static int getUserInput()
        {
            int userInputInt;
            string userInputString;
            
            Console.WriteLine("Please enter the height of the desired asterik diamond (only positive integers): ");
            userInputString = Console.ReadLine();

            while (!isValid(userInputString, out userInputInt))
            {
                Console.WriteLine("Please enter the height of the desired asterik diamond (only positive integers): ");
                userInputString = Console.ReadLine();
                
            }

            if (userInputInt % 2 == 0)
            {
                userInputInt++;
            }

            return userInputInt;
        }

        // $G$ CSS-999 (-0) The method must have an access modifier
        // $G$ CSS-999 (-0) Missing blank line, after local variable.
        static bool isValid(string i_UserInput, out int o_UserInputInt)
        {
            bool isNumber = int.TryParse(i_UserInput, out o_UserInputInt);
            return (isNumber && o_UserInputInt > 0);
        }
    }
}
