using System;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            runProgram();
            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }

        static void runProgram()
        {
            Console.Write("Hello, Please enter a 6 characters long number or word: ");
            string userInputStr = Ex01_01.Program.GetUserInput("Please enter only a 6 character long word or 6 digit long number!", isInputValid);
            PrintStatistics(userInputStr);
        }

        static bool isInputValid(string i_UserInput)
        {
            return (IsNumeric(i_UserInput) || isLettersOnly(i_UserInput)) && i_UserInput.Length == 6;
        }

        public static bool IsDivisibleByThree(int i_UserInput)
        {
            return (i_UserInput % 3) == 0;
        }

        static int countUpperCaseLetters(string i_UserInput)
        {
            int upperCaseCounter = 0;
            foreach(char character in i_UserInput)
            {
                if (isUpperCase(character))
                {
                    upperCaseCounter++;
                }
            }

            return upperCaseCounter;
        }

        static bool isLettersOnly(string i_String)
        {
            bool isLettersOnly = true;

            foreach(char character in i_String)
            {
                isLettersOnly &= isCharALetter(character);
                if (!isLettersOnly)
                {
                    break;
                }
            }

            return isLettersOnly;
        }

        static bool isUpperCase(char i_Character)
        {
            return i_Character >= 'A' && i_Character <= 'Z';
        }

        static bool isLowerCase(char i_Character)
        {
            return i_Character >= 'a' && i_Character <= 'z';
        }

        static bool isCharALetter(char i_Character)
        {
            return isLowerCase(i_Character) || isUpperCase(i_Character);
        }

        public static bool IsNumeric(string i_String)
        {
            return int.TryParse(i_String, out _);
        }


        static void PrintStatistics(string i_UserInput)
        {
            Console.WriteLine();
            Console.WriteLine(isConditionMetMessageBuilder(i_UserInput, Ex01_01.Program.IsPalindrome, "a Palindrome"));
            if (isLettersOnly(i_UserInput))
            {
                Console.WriteLine(string.Format("Number of Uppercase letters: {0}", countUpperCaseLetters(i_UserInput)));
            }
            else
            {
                int userInputInteger = int.Parse(i_UserInput);
                Console.WriteLine(isConditionMetMessageBuilder(userInputInteger, IsDivisibleByThree, "Divisble By 3"));
            }

            Console.WriteLine();
        }

        static string isConditionMetMessageBuilder<T>(T i_ElementToCheck, Func<T, bool> isConditionMet, string i_ConditionMessage)
        {
            string isConditionMetMessage = "";

            if (!isConditionMet(i_ElementToCheck))
            {
                isConditionMetMessage = "not ";
            }

            return string.Format("The input is {0}{1}", isConditionMetMessage, i_ConditionMessage);
        }
    }
}
