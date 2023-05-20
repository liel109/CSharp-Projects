using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Game
    {
        private Board m_GameBoard;

        public Game(int i_BoardSize)
        {
            m_GameBoard = new Board(i_BoardSize);
        }

        internal bool UpdateBoard((int, int) i_Coordinate, PlayerMarks i_Player)
        {
            bool moveSucceded = true;

            try
            {
                m_GameBoard.setPlayerAt(i_Coordinate, i_Player);

            }
            catch (AccessViolationException)
            {
                moveSucceded = false;
            }
            catch (IndexOutOfRangeException)
            {
                moveSucceded = false;
            }

            return moveSucceded;
        }

        internal bool IsGameFinished((int, int) i_Coordinate, PlayerMarks i_player)
        {
            int rowIndex = i_Coordinate.Item1;
            int columnIndex = i_Coordinate.Item2;
            bool checkPrimaryDiagonal = isOnPrimaryDiagonal(i_Coordinate);
            bool checkSecondaryDiagonal = isOnSecondaryDiagonal(i_Coordinate);
            bool isGameOver = false;

            if (checkPrimaryDiagonal)
            {
                isGameOver = isPrimaryDiagonalFull(i_player);
            }

            if (checkSecondaryDiagonal)
            {
                isGameOver = isGameOver | isSecondaryDiagonalFull(i_player);
            }

            isGameOver = isGameOver | isRowFull(rowIndex, i_player) | isColumnFull(columnIndex, i_player);

            return isGameOver;

        }

        private bool isPrimaryDiagonalFull(PlayerMarks i_player)
        {
            bool isGameOver = true;

            for (int index = 0; index < m_GameBoard.GetSize(); index++)
            {
                if (!m_GameBoard.getPlayerAt((index, index)).Equals(i_player))
                {
                    isGameOver = false;
                    break;
                }
            }

            return isGameOver;
        }

        private bool isRowFull(int i_Row, PlayerMarks i_player)
        {
            bool isGameOver = true;

            for (int column = 0; column < m_GameBoard.GetSize(); column++)
            {

                if (!m_GameBoard.getPlayerAt((i_Row, column)).Equals(i_player))
                {
                    isGameOver = false;
                    break;
                }

            }

            return isGameOver;
        }

        private bool isColumnFull(int i_Column, PlayerMarks i_player)
        {
            bool isGameOver = true;

            for (int row = 0; row < m_GameBoard.GetSize(); row++)
            {
                if (!m_GameBoard.getPlayerAt((row, i_Column)).Equals(i_player))
                {
                    isGameOver = false;
                    break;
                }

            }

            return isGameOver;
        }

        private bool isSecondaryDiagonalFull(PlayerMarks i_player)
        {
            bool isGameOver = true;
            int columnIndex = 0;

            for (int rowIndex = 0; rowIndex < m_GameBoard.GetSize(); rowIndex++)
            {
                columnIndex = m_GameBoard.GetSize() - rowIndex - 1;
                if (!m_GameBoard.getPlayerAt((rowIndex, columnIndex)).Equals(i_player))
                {
                    isGameOver = false;
                    break;
                }
            }

            return isGameOver;
        }

        private bool isOnPrimaryDiagonal((int, int) i_Cordinate)
        {
            int rowIndex = i_Cordinate.Item1;
            int columnIndex = i_Cordinate.Item2;

            return rowIndex == columnIndex;
        }

        private bool isOnSecondaryDiagonal((int, int) i_Cordinate)
        {
            int rowIndex = i_Cordinate.Item1;
            int columnIndex = i_Cordinate.Item2;

            return (rowIndex + columnIndex) == (m_GameBoard.GetSize() - 1);

        }



        internal PlayerMarks[,] getBoardState()
        {
            return m_GameBoard.getBoardClone();
        }

        internal void ResetBoard()
        {
            m_GameBoard.ResetMatrix();
        }

    }
}
