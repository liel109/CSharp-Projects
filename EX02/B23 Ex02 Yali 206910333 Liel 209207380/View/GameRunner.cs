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
            selectedBoardSize = ConsoleRenderer.AskUserForNumericInput("Please Enter Board Size: ", "Please Enter Legal Board Size");
            selectedPlayerType = ConsoleRenderer.getPlayerType("Please Enter Opponent (1-P2 2-CPU): ", "Please Enter 1 For P2 Or 2 For Cpu");

            s_Game = new Game(selectedBoardSize, selectedPlayerType);
            ConsoleRenderer.printBoard(s_Game.GetBoardState());
        }

        private static void runMiniGame()
        {
            bool isGameFinished = false;

            while (!isGameFinished)
            {
                (int, int) i_UserCoordinateInput = ConsoleRenderer.getCoordinateFromUser();
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
    }
}
