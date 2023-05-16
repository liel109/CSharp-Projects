using System;

namespace Ex01_03
{
    class Program
    {
        static void Main()
        {
            printAsterikDiamond();
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

        static void printAsterikDiamond()
        {
            int heightOfDiamond = getUserInput();

            Ex01_02.Program.PrintAsterikDiamond(heightOfDiamond);
        }

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

        static bool isValid(string i_UserInput, out int o_UserInputInt)
        {
            bool isNumber = int.TryParse(i_UserInput, out o_UserInputInt);
            return (isNumber && o_UserInputInt > 0);
        }
    }
}
