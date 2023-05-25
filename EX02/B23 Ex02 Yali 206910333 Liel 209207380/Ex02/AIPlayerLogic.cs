using System;
using System.Collections.Generic;

namespace Ex02
{
    public class AIPlayerLogic
    {
        private const int k_GameWonScore = 1;
        private const int k_GameLostScore = -1;
        private const int k_GameTieScore = 0;
        private const int k_MaxRecursionDepth = 10;
        private const bool k_MaximizePlayer = true;
        private const bool k_MinimizePlayer = false;

        private static Random s_random = new Random();

        internal static (int, int) GetBestMove(Game i_Game)
        {
            Board gameBoard = i_Game.GetBoardState();
            int bestMoveScore = int.MinValue;
            int currentMoveScore;
            (int, int) bestMove = (-1, -1);

            if (i_Game.GetNumOfEmptySpaces() <= k_MaxRecursionDepth)
            {
                for (int row = 0; row < i_Game.GetBoardSize(); row++)
                {
                    for (int column = 0; column < i_Game.GetBoardSize(); column++)
                    {
                        if (i_Game.IsCoordinateEmpty((row, column)))
                        {
                            i_Game.UpdateBoard((row, column), ePlayerMarks.Player2);
                            currentMoveScore = miniMax(i_Game, 0, k_MinimizePlayer);
                            i_Game.UndoMove((row, column));

                            if (currentMoveScore > bestMoveScore)
                            {
                                bestMoveScore = currentMoveScore;
                                bestMove = (row, column);
                            }
                        }

                    }
                }
            }

            if (bestMoveScore == int.MaxValue || bestMoveScore == int.MinValue)
            {
                bestMove = getRandomCoordinate(gameBoard.GetAvailableMoves());
            }

            return bestMove;
        }

        private static int miniMax(Game i_Game, int i_RecursionDepth, bool i_IsMaximizingPlayer)
        {
            int returnValue;
            int currentMoveScore;
            int bestScore;

            if (i_RecursionDepth > k_MaxRecursionDepth)
            {
                returnValue = recursionMaxDepth(i_IsMaximizingPlayer);
            }
            else if (i_Game.IsPlayerWon(ePlayerMarks.Player1))
            {
                returnValue = k_GameWonScore;
            }
            else if (i_Game.IsPlayerWon(ePlayerMarks.Player2))
            {
                returnValue = k_GameLostScore;
            }
            else if (i_Game.CheckIfBoardIsFull())
            {
                returnValue = k_GameTieScore;
            }
            else if (i_IsMaximizingPlayer)
            {
                bestScore = int.MinValue;

                for (int row = 0; row < i_Game.GetBoardSize(); row++)
                {
                    for (int column = 0; column < i_Game.GetBoardSize(); column++)
                    {
                        if (i_Game.IsCoordinateEmpty((row, column)))
                        {
                            i_Game.UpdateBoard((row, column), ePlayerMarks.Player2);
                            currentMoveScore = miniMax(i_Game, i_RecursionDepth + 1, k_MinimizePlayer);
                            i_Game.UndoMove((row, column));

                            bestScore = Math.Max(bestScore, currentMoveScore);
                        }
                    }
                }

                returnValue = bestScore;
            }
            else
            {
                bestScore = int.MaxValue;

                for (int row = 0; row < i_Game.GetBoardSize(); row++)
                {
                    for (int column = 0; column < i_Game.GetBoardSize(); column++)
                    {
                        if (i_Game.IsCoordinateEmpty((row, column)))
                        {
                            i_Game.UpdateBoard((row, column), ePlayerMarks.Player1);
                            currentMoveScore = miniMax(i_Game, i_RecursionDepth + 1, k_MaximizePlayer);
                            i_Game.UndoMove((row, column));

                            bestScore = Math.Min(bestScore, currentMoveScore);
                        }
                    }
                }

                returnValue = bestScore;
            }

            return returnValue;
        }

        private static int recursionMaxDepth(bool i_IsMaximizingPlayer)
        {
            int minOrMaxInt;

            if (i_IsMaximizingPlayer)
            {
                minOrMaxInt = int.MaxValue;
            }
            else
            {
                minOrMaxInt = int.MinValue;
            }

            return minOrMaxInt;
        }

        private static (int, int) getRandomCoordinate(List<(int, int)> i_AvailableMoves)
        {
            int randomIndex = s_random.Next(i_AvailableMoves.Count);

            return i_AvailableMoves[randomIndex];
        }
    }
}
