using System;
using System.Text;
using System.Linq;

namespace Ex01_01
{
    public class Program
    {
        const int k_NumberOfNumbersToRead = 3;
        const bool v_One = true;
        const bool v_Zero = false;

        public static void Main()
        {
            runProgram();
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

        public static void runProgram()
        {
            string[] stringUserInputsArray = new string[k_NumberOfNumbersToRead];
            int[] decimalUserInputsArray = new int[k_NumberOfNumbersToRead];

            manageUserInput(stringUserInputsArray, decimalUserInputsArray);
            printUserNumbersDescending(decimalUserInputsArray);
            printStatistics(stringUserInputsArray, decimalUserInputsArray);
        }

        public static string GetUserInput(string i_MessageForInvalidInput, Func<string, bool> i_ValidateMethod)
        {
            string userInput = Console.ReadLine();

            while (!i_ValidateMethod(userInput))
            {
                Console.WriteLine(i_MessageForInvalidInput);
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        static void manageUserInput(string[] o_stringUserInputsArray, int[] o_decimalUserInputsArray)
        {
            string invalidInputMessageForUser = "Please enter only 8 digits long binary numbers!";

            Console.WriteLine(string.Format("Please enter {0} binary numbers", k_NumberOfNumbersToRead));
            for (int i = 0; i < k_NumberOfNumbersToRead; i++)
            {
                string userInput = GetUserInput(invalidInputMessageForUser, isInputValid);
                o_stringUserInputsArray[i] = userInput;
                o_decimalUserInputsArray[i] = convertBinaryToDecimal(userInput);
            }
        }

        static int convertBinaryToDecimal(string i_UserInput)
        {
            int userIntInput = 0;
            int powerRank = i_UserInput.Length - 1;

            foreach (char digit in i_UserInput)
            {
                if (digit == '1')
                {
                    userIntInput += (int)Math.Pow(2, powerRank);
                }

                powerRank--;
            }

            return userIntInput;
        }

        static bool isInputValid(string i_UserInputStr)
        {
            bool isInputBinary = true;

            foreach (char digit in i_UserInputStr)
            {
                if (digit != '1' && digit != '0')
                {
                    isInputBinary = false;
                    break;
                }
            }

            return isInputBinary && i_UserInputStr.Length == 8;
        }

        static bool isPow2Number(string i_BinaryNumber)
        {
            return countNumberOfBinaryDigit(i_BinaryNumber, v_One) == 1;
        }

        static bool isDivisbleByFour(string i_BinaryNumber)
        {
            int stringLength = i_BinaryNumber.Length;
            
            return (i_BinaryNumber[stringLength - 2] == i_BinaryNumber[stringLength - 1]) && (i_BinaryNumber[stringLength - 1] == '0');
        }

        static bool isStrictlyDescendingNumber(int i_Number)
        {
            bool strictlyDescending = true;
            int currentDigit;
            int previousDigit = i_Number % 10;

            while ((i_Number / 10) > 0)
            {
                i_Number /= 10;
                currentDigit = i_Number % 10;
                if (!(currentDigit > previousDigit))
                {
                    strictlyDescending = false;
                    break;
                }
                previousDigit = currentDigit;
            }

            return strictlyDescending;
        }

        public static bool IsPalindrome(int i_Number)
        {
            return IsPalindrome(i_Number.ToString());
        }

        public static bool IsPalindrome(string i_Str)
        {
            int userNumberLength = i_Str.Length;
            bool isPalindromeBool = false;

            if (userNumberLength == 1 || userNumberLength == 0)
            {
                isPalindromeBool = true;
            }
            else if (i_Str[0] == i_Str[userNumberLength - 1])
            {
                isPalindromeBool = IsPalindrome(i_Str.Substring(1, userNumberLength - 2));
            }

            return isPalindromeBool;
        }

        static int countNumberOfBinaryDigit(string i_BinaryNumber, bool i_ZerosOrOnes)
        {
            int numberOfMatchingDigits = 0;

            foreach (char digit in i_BinaryNumber)
            {
                if ((i_ZerosOrOnes && digit == '1') || (!i_ZerosOrOnes && digit == '0'))
                {
                    numberOfMatchingDigits++;
                }
            }

            return numberOfMatchingDigits;
        }

        static float averageNumOfDigit(string[] i_binaryNumbersArray, bool i_ZerosOrOnes)
        {
            int numberOfMatchingDigits = 0;

            foreach (string binaryNumber in i_binaryNumbersArray)
            {
                numberOfMatchingDigits += countNumberOfBinaryDigit(binaryNumber, i_ZerosOrOnes);
            }

            return (float)numberOfMatchingDigits / i_binaryNumbersArray.Length;

        }

        static void sortDescending(int[] i_Arr)
        {
            Array.Sort(i_Arr);
            Array.Reverse(i_Arr);
        }

        static void printUserNumbersDescending(int[] i_UserInputIntArr)
        {
            StringBuilder userDecimalNumbersDescendingMsg = new StringBuilder();

            userDecimalNumbersDescendingMsg.Append("The numbers in descending order: ");
            sortDescending(i_UserInputIntArr);
            foreach (int number in i_UserInputIntArr)
            {
                userDecimalNumbersDescendingMsg.Append(number);
                userDecimalNumbersDescendingMsg.Append(", ");
            }

            userDecimalNumbersDescendingMsg.Remove(userDecimalNumbersDescendingMsg.Length - 2, 1);
            Console.WriteLine(userDecimalNumbersDescendingMsg.ToString());
        }

        static void printStatistics(string[] i_stringUserInputsArray, int[] i_decimalUserInputsArray)
        {
            string countPow2NumbersMsg = string.Format("The amount of numbers that are power of two: {0}", i_stringUserInputsArray.Count(isPow2Number));
            string countDivisibleByFourMsg = string.Format("The amount of numbers that are divisible by four: {0}", i_stringUserInputsArray.Count(isDivisbleByFour));
            string averageNumOfOnesMsg = string.Format("The average amount of one's: {0}", averageNumOfDigit(i_stringUserInputsArray, v_One));
            string averageNumOfZerosMsg = string.Format("The average amount of zero's: {0}", averageNumOfDigit(i_stringUserInputsArray, v_Zero));
            string countStrictlyDescendingSeriesNumbersMsg = string.Format("The amount of strictly descending series numbers: {0}", i_decimalUserInputsArray.Count(isStrictlyDescendingNumber));
            string countPalindromesMsg = string.Format("The amount of palindromes: {0}", i_decimalUserInputsArray.Count(IsPalindrome));

            Console.WriteLine();
            Console.WriteLine(countPow2NumbersMsg);
            Console.WriteLine(countDivisibleByFourMsg);
            Console.WriteLine(averageNumOfOnesMsg);
            Console.WriteLine(averageNumOfZerosMsg);
            Console.WriteLine(countStrictlyDescendingSeriesNumbersMsg);
            Console.WriteLine(countPalindromesMsg);
            Console.WriteLine();
        }
    }
}