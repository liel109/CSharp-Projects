using System;

namespace Ex01_05
{
    // $G$ CSS-999 (-2) The Class must have an access modifier
    class Program
    {
        public static void Main()
        {
            runProgram();
            Console.WriteLine();
            Console.Write("Press enter to exit...");
            Console.ReadLine();

        }

        // $G$ CSS-999 (-0) The method must have an access modifier
        // $G$ CSS-999 (-0) Missing blank line, after local variable.
        static void runProgram()
        {
            Console.Write("Please enter a 6 digit long number: ");
            string userInputStr = Ex01_01.Program.GetUserInput("please enter only a 6 digit long number!", isInputValid);
            int userInput = int.Parse(userInputStr);
            printStatistics(userInputStr);
        }

        // $G$ CSS-999 (-0) The method must have an access modifier
        static bool isInputValid(string i_UserInput)
        {
            return Ex01_04.Program.IsNumeric(i_UserInput) && i_UserInput.Length == 6;
        }

        // $G$ CSS-001 (-0) Bad input parameter name -  It's important to name variables meaningfully and understandably
        static int countDigitsDivisibleByThree(string i_Number)
        {
            int digitsDivisibleCounter = 0;

            foreach(char digitChar in i_Number)
            {
                int digit = asciiNumberToInteger(digitChar);
                if (Ex01_04.Program.IsDivisibleByThree(digit))
                {
                    digitsDivisibleCounter++;
                }
            }

            return digitsDivisibleCounter;
        }
        // $G$ CSS-999 (-0) The method must have an access modifier
        static int countDigitsLargerThanUnitsDigit(string i_Number)
        {
            int unitsDigitIndex = i_Number.Length - 1;
            int digitsLargerCounter = 0;
            char unitsDigit = i_Number[unitsDigitIndex];

            foreach(char digit in i_Number)
            {
                if(digit > unitsDigit)
                {
                    digitsLargerCounter++;
                }
            }

            return digitsLargerCounter;
        }

        // $G$ CSS-999 (-0) The method must have an access modifier
        static char getSmallestDigit(string i_Number)
        {
            char smallestDigit = i_Number[0];

            foreach(char digit in i_Number)
            {
                if(digit < smallestDigit)
                {
                    smallestDigit = digit;
                }
            }

            return smallestDigit;
        }

        // $G$ CSS-999 (-0) The method must have an access modifier
        static float digitsAverage(string i_Number)
        {
            int sumOfDigits = 0;

            foreach(char digit in i_Number)
            {
                sumOfDigits += asciiNumberToInteger(digit);
            }

            return (float) sumOfDigits / i_Number.Length;
        }

        static int asciiNumberToInteger(char i_Character)
        {
            return i_Character - '0';
        }

        //$G$ CSS-999 (-0) You should have used verbatim string(@)
        static void printStatistics(string i_UserInput)
        {
            Console.WriteLine();
            Console.WriteLine("Statistics:");
            Console.WriteLine(string.Format("Number of digits larger than the unit's digit: {0}", countDigitsLargerThanUnitsDigit(i_UserInput)));
            Console.WriteLine(string.Format("Smallest digit in the number: {0}", getSmallestDigit(i_UserInput)));
            Console.WriteLine(string.Format("Number of digits divisible by 3: {0}", countDigitsDivisibleByThree(i_UserInput)));
            Console.WriteLine(string.Format("Average of digits: {0}", digitsAverage(i_UserInput)));
            Console.WriteLine();
        }
    
    }

}
