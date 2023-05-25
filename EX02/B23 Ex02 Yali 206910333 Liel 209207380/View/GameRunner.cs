using System;

namespace Ex02
{
    public class GameRunner
    {
        private static Game s_Game;

        public static void Main()
        {
            runGame();
        }

        private static void runGame()
        {
            bool isAnotherGameWanted = true;
            bool isInitSuccessfull = false;

            while (!isInitSuccessfull)
            {
                try
                {
                    initGame();
                    isInitSuccessfull = true;
                }
                catch (Exception e)
                {
                    isAnotherGameWanted = getUserNewGameInput();
                    
                    if (!isAnotherGameWanted)
                    {
                        break;
                    }
                }
            }

            while (isAnotherGameWanted)
            {
                runMiniGame();
                isAnotherGameWanted = endGame();
            }
        }

        private static void initGame()
        {
            int selectedBoardSize;
            ePlayerType selectedPlayerType;

            GameUI.InitScreen();
            selectedBoardSize = getBoardSizeFromUser();
            selectedPlayerType = getPlayerTypeFromUser();
            s_Game = new Game(selectedBoardSize, selectedPlayerType);
        }

        private static void runMiniGame()
        {
            bool isGameFinished = false;
            bool isLegalCoordinateInput;

            GameUI.PrintBoard(s_Game.GetBoardState());
            while (!isGameFinished)
            {
                try
                {
                    (int, int) i_UserCoordinateInput = getCoordinateFromUser();
                    isLegalCoordinateInput = s_Game.DoNextGameMove(i_UserCoordinateInput, out isGameFinished);

                    GameUI.PrintBoard(s_Game.GetBoardState());
                    if (!isLegalCoordinateInput)
                    {
                        GameUI.RaiseInputInvalidError("Cell is taken!");
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            }
        }

        private static bool endGame()
        {
            GameUI.DeclareWinner(s_Game.GetWinner(), s_Game.Players);
            bool isAnotherGameWanted = getUserNewGameInput();
            if (isAnotherGameWanted)
            {
                s_Game.ResetGame();
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
            string userRowInput = GameUI.AskUserForInput("Please Enter Row: ", "Please Enter A Valid Row Number!", isValidIndexNumber);

            return int.Parse(userRowInput);
        }

        private static int getColumnFromUser()
        {
            string userColumnInput = GameUI.AskUserForInput("Enter Column: ", "Please Enter A Valid Column Number!", isValidIndexNumber);

            return int.Parse(userColumnInput);
        }

        private static ePlayerType getPlayerTypeFromUser()
        {
            string userTypeInput = GameUI.AskUserForInput("Please Enter Opponent Type (1-P2 2-CPU): ", "Please Enter 1 For P2 Or 2 For CPU", isValidPlayerTypeInput);

            return (ePlayerType)Enum.Parse(typeof(ePlayerType), userTypeInput);
        }

        private static int getBoardSizeFromUser()
        {
            string userSizeInput = GameUI.AskUserForInput("Please Enter Board Size: ", "Please Enter Legal Board Size", isValidBoardSize);

            return int.Parse(userSizeInput);
        }

        private static bool getUserNewGameInput()
        {
            string userSizeInput = GameUI.AskUserForInput("Do you wish to play again? (Y/N) ", "Please Enter Y / N", isValidNewGameInput);

            return (userSizeInput == "Y") || (userSizeInput == "y");
        }

        private static bool isValidIndexNumber(string i_UserInput)
        {
            int userIndexInput;

            return int.TryParse(i_UserInput, out userIndexInput) && s_Game.isIndexLegal(userIndexInput);
        }

        private static bool isValidPlayerTypeInput(string i_UserInput)
        {
            int userInputInt;

            return int.TryParse(i_UserInput, out userInputInt) && Enum.IsDefined(typeof(ePlayerType), userInputInt);
        }

        private static bool isValidBoardSize(string i_UserInput)
        {
            int userIndexInput;
            bool isNumericInput = int.TryParse(i_UserInput, out userIndexInput);
            bool isValidBoardSize = isNumericInput && Game.IsBoardSizeLegal(userIndexInput);

            return isValidBoardSize;
        }

        private static bool isValidNewGameInput(string i_UserInput)
        {
            return i_UserInput == "Y" || i_UserInput == "y" || i_UserInput == "N" || i_UserInput == "n";
        }
    }
}
