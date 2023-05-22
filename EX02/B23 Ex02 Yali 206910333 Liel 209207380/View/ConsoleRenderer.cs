using System;
using System.Text;
using Ex02.ConsoleUtils;
using Ex02;

namespace Ex02
{
    class ConsoleRenderer
    {
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

        private static void printRowSeperation(int i_SeperationLength)
        {
            StringBuilder seperationBuilder = new StringBuilder();

            for (int i = 0; i < i_SeperationLength; i++)
            {
                seperationBuilder.Append("=");
            }

            Console.WriteLine(seperationBuilder.ToString());
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

        internal static void RaiseInputInvalidError(string i_ErrorMessage)
        {
            Console.WriteLine(i_ErrorMessage);
        }

        internal static void DeclareWinner(Player[] i_Players)
        {
            Console.WriteLine(String.Format(@"{0} is The Winner!
Score Table:

{0,8}{1,8}
{2,8}{3,8}", i_Players[0].Type, i_Players[0].Score, i_Players[1].Type, i_Players[1].Score));
        }

        internal static void DeclareWinner(string[] i_Players)
        {
            Console.WriteLine(String.Format(@"{0} is The Winner!
Score Table:

{0,8}{1,8}
{2,8}{3,8}", i_Players[0], i_Players[1], i_Players[2], i_Players[3]));
        }

        internal static (int, int) getCoordinateFromUser()
        {
            return (getRowFromUser(), getColumnFromUser());
        }

        internal static int getRowFromUser()
        {
            return AskUserForNumericInput("Enter Row: ", "Please Enter A Valid Row Number!");
        }

        internal static int getColumnFromUser()
        {
            return AskUserForNumericInput("Enter Column: ", "Please Enter A Valid Column Number!");

        }

        internal static int AskUserForNumericInput(string i_MessageForUser, string i_InvalidInputMessage)
        {
            int userInput = 0;
            bool isValid = false;
            string userInputString;

            Console.Write(i_MessageForUser);
            while (!isValid)
            {
                userInputString = Console.ReadLine();
                isValid = int.TryParse(userInputString, out userInput);

                if (!isValid)
                {
                    Console.WriteLine(i_InvalidInputMessage);
                }
            }

            return userInput;
        }

        internal static ePlayerTypes getPlayerType(string i_MessageForUser, string i_InvalidInputMessage)
        {
            bool isInputValid = false;
            string userInput;
            ePlayerTypes selectedPlayerType = ePlayerTypes.NONE;

            Console.WriteLine(i_MessageForUser);
            while (!isInputValid)
            {
                userInput = Console.ReadLine();

                try
                {
                    selectedPlayerType = (ePlayerTypes)Enum.Parse(typeof(ePlayerTypes), userInput);
                    isInputValid = true;
                }
                catch
                {
                    Console.WriteLine(i_InvalidInputMessage);
                }
            }

            return selectedPlayerType;
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
    }
}
