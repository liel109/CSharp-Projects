using System;
using System.Text;
using Ex02.ConsoleUtils;

namespace Ex02
{
    class View
    {
        public static void Main()
        {
            //Game game = new Game(5);
            //int counter = 0;
            //int row;
            //int column;
            //PlayerMarks player;
            //while (true)
            //{
            //    if (counter % 2 == 0)
            //    {
            //        player = PlayerMarks.Player1;
            //    }
            //    else
            //    {
            //        player = PlayerMarks.Player2;
            //    }

            //    printBoard(game.getBoardState());
            //    Console.WriteLine("enter row");
            //    row = int.Parse(Console.ReadLine()) - 1;
            //    Console.WriteLine("enter column");
            //    column = int.Parse(Console.ReadLine()) - 1;
            //    if (!game.UpdateBoard((row, column), player))
            //    {
            //        Console.WriteLine("error");
            //        continue;
            //    }
            //    counter++;
            //    if (game.IsGameFinished())
            //    {
            //        printBoard(game.getBoardState());
            //        Console.WriteLine("game finished");
            //        game.ResetBoard();
            //        printBoard(game.getBoardState());
            //        break;
            //    }
            //}
            //DeclareWinner(new string[] { "Liel","10","Yali","4"});
            //Console.WriteLine("Press Enter...");
            //Console.ReadLine();
        }

        static internal void initScreen()
        {
            Console.WriteLine("Welcome to Reverse Tic-Tac-Toe!");
        }

        static internal void printBoard(Board i_GameBoard)
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

        internal static (string, string) getCoordinateFromUser(Player player)
        {
            Console.WriteLine($"{player.Type}, Please enter coordinates:");
            return (getRowFromUser(), getColumnFromUser());
        }

        internal static string getRowFromUser()
        {
            Console.WriteLine("Enter Row: ");
            return Console.ReadLine();
        }

        internal static string getColumnFromUser()
        {
            Console.WriteLine("Enter Column: ");
            return Console.ReadLine();
        }

        internal static string getBoardSizeFromUser()
        {
            Console.Write("Please Enter Board Size:");
            return Console.ReadLine();
        }

        internal static string getPlayerType()
        {
            Console.Write("Please Select Opponent (1-P2 , 2-CPU): ");
            return Console.ReadLine();
        }

        internal static string getUserNewGameInput()
        {
            Console.Write("Do you wish to play again? (Y/N)");
            return Console.ReadLine();
        }
    }
}
