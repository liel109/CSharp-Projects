using System;
using Ex02.ConsoleUtils;

namespace Ex02
{
    class View
    {
        public static void Main()
        {
            DeclareWinner(new string[] { "Liel","10","Yali","4"});
            Console.WriteLine("Press Enter...");
            Console.ReadLine();
        }

        static internal void initScreen()
        {
            Console.WriteLine("Welcome to Reverse Tic-Tac-Toe!");

        }

        static internal void printBoard(PlayerMarks[,] i_GameBoard)
        {
            printBoardIndexBar(i_GameBoard.GetLength(0));
            for (int i = 0; i < i_GameBoard.GetLength(0); i++)
            {
                Console.Write(String.Format("{0}|", i + 1));
                for (int j = 0; j < i_GameBoard.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0,2}{1,2}", (char)i_GameBoard[i, j], "|"));
                }

                Console.WriteLine();
                printRowSeperation(i_GameBoard.GetLength(1) * 4 + 2);
            }
        }

        private static void printRowSeperation(int i_SeperationLength)
        {
            for (int i = 0; i < i_SeperationLength; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        private static void printBoardIndexBar(int i_MaxIndex)
        {
            for (int i = 1; i <= i_MaxIndex; i++)
            { 
                Console.Write(String.Format("{0,4}", i));
            }
            Console.WriteLine();
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
{2,8}{3,8}", i_Players[0].Name, i_Players[0].Score, i_Players[1].Name, i_Players[1].Score));
        }

        internal static void DeclareWinner(string[] i_Players)
        {
            Console.WriteLine(String.Format(@"{0} is The Winner!
Score Table:

{0,8}{1,8}
{2,8}{3,8}", i_Players[0], i_Players[1], i_Players[2], i_Players[3]));
        }

        internal static string getCoordinateFromUser(Player player)
        {
            Console.Write($"{player.Name}, Please enter coordinates:");
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
