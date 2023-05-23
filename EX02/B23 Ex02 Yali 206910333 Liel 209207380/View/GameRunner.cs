using System;
using Ex02;

namespace View
{
    class GameRunner
    {
        private static Game s_Game;

        public static void Main()
        {
            runGame();
        }

        private static void runGame()
        {
            bool isAnotherGameWanted = true;

            init();
            while (isAnotherGameWanted)
            {
                runMiniGame();
                isAnotherGameWanted = endGame();
            }
        }

        private static void init()
        {
            int selectedBoardSize;
            ePlayerTypes selectedPlayerType;

            ConsoleRenderer.initScreen();
            selectedBoardSize = getBoardSizeFromUser();
            selectedPlayerType = getPlayerTypeFromUser();
            s_Game = new Game(selectedBoardSize, selectedPlayerType);
            ConsoleRenderer.printBoard(s_Game.GetBoardState());
        }

        private static void runMiniGame()
        {
            bool isGameFinished = false;

            while (!isGameFinished)
            {
                (int, int) i_UserCoordinateInput = getCoordinateFromUser();
                s_Game.DoNextGameMove(i_UserCoordinateInput, out isGameFinished);
                ConsoleRenderer.printBoard(s_Game.GetBoardState());
            }
        }

        private static bool endGame()
        {
            bool isAnotherGameWanted = false;

            ConsoleRenderer.DeclareWinner(s_Game.Players);
            if (ConsoleRenderer.getUserNewGameInput())
            {
                s_Game.ResetGame();
                ConsoleRenderer.printBoard(s_Game.GetBoardState());
                isAnotherGameWanted = true;
            }

            return isAnotherGameWanted;
        }

        private static (int, int) getCoordinateFromUser()
        {
            Console.WriteLine("Please Enter Coordinates:");
            return (getRowFromUser(), getColumnFromUser());
        }

        private static int getRowFromUser()
        {
            string userRowInput = ConsoleRenderer.AskUserForInput("Please Enter Row: ", "Please Enter A Valid Row Number!", isValidIndexNumber);

            return int.Parse(userRowInput);
        }

        private static int getColumnFromUser()
        {
            string userColumnInput = ConsoleRenderer.AskUserForInput("Enter Column: ", "Please Enter A Valid Column Number!", isValidIndexNumber);

            return int.Parse(userColumnInput);
        }

        private static ePlayerTypes getPlayerTypeFromUser()
        {
            string userTypeInput = ConsoleRenderer.AskUserForInput("Please Enter Opponent Type (1-P2 2-CPU): ", "Please Enter 1 For P2 Or 2 For CPU",
                isValidPlayerTypeInput);

            return (ePlayerTypes)Enum.Parse(typeof(ePlayerTypes), userTypeInput);
        }

        private static int getBoardSizeFromUser()
        {
            string userSizeInput = ConsoleRenderer.AskUserForInput("Please Enter Board Size: ", "Please Enter Legal Board Size", isValidBoardSize);

            return int.Parse(userSizeInput);
        }

        private static int getNewGameInputFromUser()
        {
            string userNewGameInput = ConsoleRenderer.AskUserForInput("P")
        }

        private static bool isValidIndexNumber(string i_UserInput)
        {
            int userIndexInput;
            bool isNumericInput = int.TryParse(i_UserInput, out userIndexInput);
            bool isIndexInBound = isNumericInput && (userIndexInput >= 1 && userIndexInput <= s_Game.GetBoardSize());

            return isIndexInBound;
        }

        private static bool isValidPlayerTypeInput(string i_UserInput)
        {
            ePlayerTypes selectedPlayerType;

            return Enum.TryParse<ePlayerTypes>(i_UserInput, out selectedPlayerType);
        }

        private static bool isValidBoardSize(string i_UserInput)
        {
            int userIndexInput;
            bool isNumericInput = int.TryParse(i_UserInput, out userIndexInput);
            bool isValidBoardSize = isNumericInput && (userIndexInput >= Game.MinBoardSize && userIndexInput <= Game.MaxBoardSize);

            return isValidBoardSize;
        }

        private static bool isValidNewGameInput(string i_UserInput)
        {
            return i_UserInput == "Y" || i_UserInput == "y" || i_UserInput == "N" || i_UserInput == "n";
        }
    }
}
