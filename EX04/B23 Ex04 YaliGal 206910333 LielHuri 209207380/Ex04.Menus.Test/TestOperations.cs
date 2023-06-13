using System;

namespace Ex04.Menus.Test
{
    public class TestOperations
    {
        public static void PrintCurrentDate()
        {
            Console.WriteLine(string.Format("Today Is {0}", DateTime.Now.ToString("dddd, dd/MM/yy")));
            printContinueMessageForUser();
        }

        public static void PrintCurrentTime()
        {
            Console.WriteLine(string.Format("The Time Is: {0}", DateTime.Now.ToString("HH:mm:ss")));
            printContinueMessageForUser();
        }

        public static void PrintVersionInfo()
        {
            Console.WriteLine("App Version: 23.2.4.9805");
            printContinueMessageForUser();
        }

        public static void CountCapitals()
        {
            string userInput;

            Console.Write("Please Enter A String: ");
            userInput = Console.ReadLine();
            Console.WriteLine(string.Format("Your String Has {0} Capital Letters", countCapitalsInString(userInput)));
            printContinueMessageForUser();
        }

        private static int countCapitalsInString(string i_StringToCount)
        {
            int capitalsCounter = 0;

            foreach (char character in i_StringToCount)
            {
                if (char.IsUpper(character))
                {
                    capitalsCounter++;
                }
            }

            return capitalsCounter;
        }

        private static void printContinueMessageForUser(string i_Message = "Press Enter To Continue...")
        {
            Console.Write(i_Message);
            Console.ReadLine();
        }
    }
}