using System;
using System.Text;
using Ex02.ConsoleUtils;

namespace Ex02
{
    class GameUI
    {
        internal static void InitScreen()
        {
            Console.WriteLine("Welcome to Reverse Tic-Tac-Toe!");
        }

        internal static void PrintBoard(Board i_GameBoard)
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

            while (!isValid)
            {
                Console.Write(i_MessageForUser);
                userInputString = Console.ReadLine();
                isValid = i_Validate(userInputString);

                if (userInputString == "Q" || userInputString == "q")
                {
                    throw new Exception();
                }

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
            if (i_WinnerMark == ePlayerMarks.NONE)
            {
                Console.WriteLine("It's A Tie!");
            }
            else
            {
                Console.WriteLine(String.Format("{0} Is The Winner!", i_WinnerMark));
            }

            Console.WriteLine(String.Format(@"Score Table:

{1,8}{2,8}
{3,8}{4,8}", i_WinnerMark, i_Players[0].Mark, i_Players[0].Score, i_Players[1].Mark, i_Players[1].Score));
        }

        private static void printBoardIndexBar(int i_MaxIndex)
        {
            for (int i = 1; i <= i_MaxIndex; i++)
            {
                Console.Write(String.Format("{0,4}", i));
            }
            Console.WriteLine();
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

    }
}
