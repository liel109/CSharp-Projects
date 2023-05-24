using System;
using System.Text;
using Ex02.ConsoleUtils;
using Ex02;

namespace Ex02
{
    class ConsoleRenderer
    {
        private const string k_QuitGameKey = "q";

        internal static void initScreen()
        {
            Console.WriteLine("Welcome to Reverse Tic-Tac-Toe!");
        }

        internal static void printBoard(Board i_GameBoard)
        {
            int rowSeperationLength = i_GameBoard.GetSize() * 4 + 2;

            Screen.Clear();
            printBoardIndexBar(i_GameBoard.GetSize());
            for (int i = 0; i < i_GameBoard.GetSize(); i++)
            {
                Console.Write(String.Format("{0}|", i + 1));
                for (int j = 0; j < i_GameBoard.GetSize(); j++)
                {
                    char currentPlayerMark = getCharMarkForPlayer(i_GameBoard.GetPlayerAt((i, j)));

                    Console.Write(String.Format("{0,2}{1,2}", currentPlayerMark, "|"));
                }

                Console.WriteLine();
                printRowSeperation(rowSeperationLength);
            }
        }

        internal static string AskUserForInput(string i_MessageForUser, string i_InvalidInputMessage, Func<string, bool> i_Validate)
        {
            bool isValid = false;
            string userInputString = null;

            Console.Write(i_MessageForUser);
            while (!isValid)
            {
                userInputString = Console.ReadLine();
                isValid = i_Validate(userInputString) || userInputString == k_QuitGameKey;

                if (!isValid)
                {
                    Console.WriteLine(i_InvalidInputMessage);
                }
            }

            return userInputString;
        }

        internal static void RaiseInputInvalidError(string i_ErrorMessage)
        {
            Console.WriteLine(i_ErrorMessage);
        }

        internal static void DeclareWinner(ePlayerMarks i_WinnerMark, Player[] i_Players)
        {
            Console.WriteLine(String.Format(@"{0} is The Winner!
Score Table:

{1,8}{2,8}
{3,8}{4,8}", i_WinnerMark, i_Players[0].Mark, i_Players[0].Score, i_Players[1].Mark, i_Players[1].Score));
        }

        internal static bool getUserNewGameInput()
        {
            bool isInputValid = false;
            string userInput = null;

            Console.Write("Do you wish to play again? (Y/N)");
            while (!isInputValid)
            {
                userInput = Console.ReadLine();
                isInputValid = (userInput == "Y") || (userInput == "N");

                if (!isInputValid)
                {
                    Console.WriteLine("Please Enter Y/N");
                }
            }

            return userInput == "Y";
        }

        private static void printBoardIndexBar(int i_MaxIndex)
        {
            for (int i = 1; i <= i_MaxIndex; i++)
            {
                Console.Write(String.Format("{0,4}", i));
            }
            Console.WriteLine();
        }

        private static char getCharMarkForPlayer(ePlayerMarks i_PlayerType)
        {
            char i_PlayerUniqueChar;

            switch (i_PlayerType)
            {
                case ePlayerMarks.Player1:
                    i_PlayerUniqueChar = 'X';
                    break;
                case ePlayerMarks.Player2:
                    i_PlayerUniqueChar = 'O';
                    break;
                default:
                    i_PlayerUniqueChar = ' ';
                    break;
            }

            return i_PlayerUniqueChar;
        }

        private static void printRowSeperation(int i_SeperationLength)
        {
            StringBuilder seperationBuilder = new StringBuilder();

            for (int i = 0; i < i_SeperationLength; i++)
            {
                seperationBuilder.Append("=");
            }

            Console.WriteLine(seperationBuilder.ToString());
        }
    }
}
