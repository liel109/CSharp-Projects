using System;

namespace Ex02
{
    internal class Controller
    {
        private const int k_NumOfPlayers = 2;

        private static Game m_Game;
        private static Player[] m_Players;


        // ===========================================================================================================================
        internal static void RunGame()
        {
        }

        private static void initGame()
        {
            int selectedBoardSize;
            ePlayerTypes selectedPlayerType;

            View.initScreen();
            selectedBoardSize = getBoardSizeFromUser();
            selectedPlayerType = getPlayerTypeFromUser();
            m_Game = new Game(selectedBoardSize);
            m_Players[0] = new Player(ePlayerTypes.USER, ePlayerMarks.Player1);
            m_Players[1] = new Player(selectedPlayerType, ePlayerMarks.Player2);
            View.printBoard(m_Game.getBoardState());

        }

        private static void runMiniGame() 
        {
            int playTurn = 0;

            while (!m_Game.IsGameFinished())
            {
                Player currentPlayingPlayer = m_Players[playTurn];

                (int, int) selectedCoordinate = takeTurn(currentPlayingPlayer);
                m_Game.UpdateBoard(selectedCoordinate, currentPlayingPlayer.Mark);
                playTurn = (playTurn + 1) % 2;
            }

        }

        private static (int, int) takeTurn(Player i_CurrentPlayer)
        {
            (int, int) selectedCoordinate;

            if (i_CurrentPlayer.Type == ePlayerTypes.CPU)
            {
                selectedCoordinate = AIPlayerLogic.getCoordinate(m_Game.getBoardState());
            }
            else
            {
                selectedCoordinate = getCoordinateFromUser();
            }

            return selectedCoordinate;
        }

        private static void endGame()
        {

        }

        private static void resetMiniGame()
        {

        }

        //private static bool tryGettingBoardSize(out int o_BoardSize)
        //{
        //    bool isBoardSizeValid = true;
        //    string boardSizeString = View.getBoardSizeFromUser();

        //    if (!int.TryParse(boardSizeString, out o_BoardSize))
        //    {
        //        isBoardSizeValid = false;
        //    }
        //    else if (!Game.isBoardSizeLegal(o_BoardSize))
        //    {
        //        isBoardSizeValid = false;
        //    }
           
        //    return isBoardSizeValid;
        //}

        private static int getBoardSizeFromUser()
        {
            return getNumericInputFromUser(View.getBoardSizeFromUser, Game.isBoardSizeLegal, "Please enter a legal Board Size");
        }

        private static ePlayerTypes getPlayerTypeFromUser()
        {
            ePlayerTypes selectedPlayerType;
            string selectedPlayerTypeString = View.getPlayerType();

            while (!isPlayerTypeInputValid(selectedPlayerTypeString))
            {
                View.RaiseInputInvalidError("Please only enter 1/2");
                selectedPlayerTypeString = View.getPlayerType();
            }

            if(selectedPlayerTypeString == "1")
            {
                selectedPlayerType = ePlayerTypes.USER;
            }
            else
            {
                selectedPlayerType = ePlayerTypes.CPU;
            }

            return selectedPlayerType;
        }

        private static bool isPlayerTypeInputValid(string i_UserInput)
        {
            return i_UserInput == "1" || i_UserInput == "2";
        }

        private static (int, int) getCoordinateFromUser()
        {
            bool isSelectedCoordinateValid = false;
            int selectedRow = 0, selectedColumn = 0;

            while (!isSelectedCoordinateValid)
            {
                selectedRow = getNumericInputFromUser(View.getRowFromUser, m_Game.isIndexLegal, "Please Enter A legal Row");
                selectedColumn = getNumericInputFromUser(View.getColumnFromUser, m_Game.isIndexLegal, "Please Enter A legal Column");

                isSelectedCoordinateValid = m_Game.isCoordinateLegal((selectedRow, selectedColumn));

                if (!isSelectedCoordinateValid)
                {
                    View.RaiseInputInvalidError("Can't place mark there!");
                }
            }
            return (selectedRow, selectedColumn);
        }

        private static int getNumericInputFromUser(Func<string> i_UserInterfaceInput, Func<int, bool> i_Validate, string i_InvalidInputErrorMessage)
        {
            int userInput = 0;
            bool isUserInputValid = false;

            while (!isUserInputValid)
            {
                string userInputString = i_UserInterfaceInput();

                if (int.TryParse(userInputString, out userInput) && i_Validate(userInput))
                {
                    isUserInputValid = true;
                }
                else
                {
                    View.RaiseInputInvalidError(i_InvalidInputErrorMessage);
                }
            }

            return userInput;
        }
    }
}
