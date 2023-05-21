using System;

namespace Ex02
{
    public class Game
    {
        private const int k_MaxBoardSize = 9;
        private const int k_MinBoardSize = 3;

        private Board m_GameBoard;
        private Player[] m_Players;

        private ePlayerMarks m_LastUpdatedPlayerMark;
        private (int, int) m_LastUpdatedCoordinate;

        public Player[] Players
        {
            get 
            {
                return m_Players;
            }
        }

        public Game(int i_BoardSize)
        {
            m_GameBoard = new Board(i_BoardSize);
            m_LastUpdatedPlayerMark = ePlayerMarks.NONE;
        }

        public bool DoNextTurn((int, int) i_Coordinate, out bool i_IsGameFinished)
        {
            i_IsGameFinished = true;
            return true;
        }

        public Board getBoardState()
        {
            return m_GameBoard;
        }

        public void ResetBoard()
        {
            m_GameBoard.ResetMatrix();
        }

        public bool UpdateBoard((int, int) i_Coordinate, ePlayerMarks i_PlayerMark)
        {
            bool moveSucceded = true;

            try
            {
                m_GameBoard.setPlayerAt(i_Coordinate, i_PlayerMark);
                m_LastUpdatedCoordinate = i_Coordinate;
                m_LastUpdatedPlayerMark = i_PlayerMark;
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

        private bool IsGameFinished()
        {
            bool isGameOver = false;

            if (m_LastUpdatedPlayerMark != ePlayerMarks.NONE)
            {
                int rowIndex = m_LastUpdatedCoordinate.Item1;
                int columnIndex = m_LastUpdatedCoordinate.Item2;

                if (isOnPrimaryDiagonal(m_LastUpdatedCoordinate))
                {
                    isGameOver = isPrimaryDiagonalFull(m_LastUpdatedPlayerMark);
                }

                if (isOnSecondaryDiagonal(m_LastUpdatedCoordinate))
                {
                    isGameOver = isGameOver | isSecondaryDiagonalFull(m_LastUpdatedPlayerMark);
                }

                isGameOver = isGameOver | isRowFull(rowIndex, m_LastUpdatedPlayerMark) | isColumnFull(columnIndex, m_LastUpdatedPlayerMark);
            }
            return isGameOver;

        }

        private bool isPrimaryDiagonalFull(ePlayerMarks i_player)
        {
            bool isGameOver = true;

            for (int index = 0; index < m_GameBoard.GetSize(); index++)
            {
                if (!m_GameBoard.GetPlayerAt((index, index)).Equals(i_player))
                {
                    isGameOver = false;
                    break;
                }
            }

            return isGameOver;
        }

        private bool isRowFull(int i_Row, ePlayerMarks i_player)
        {
            bool isGameOver = true;

            for (int column = 0; column < m_GameBoard.GetSize(); column++)
            {

                if (!m_GameBoard.GetPlayerAt((i_Row, column)).Equals(i_player))
                {
                    isGameOver = false;
                    break;
                }

            }

            return isGameOver;
        }

        private bool isColumnFull(int i_Column, ePlayerMarks i_player)
        {
            bool isGameOver = true;

            for (int row = 0; row < m_GameBoard.GetSize(); row++)
            {
                if (!m_GameBoard.GetPlayerAt((row, i_Column)).Equals(i_player))
                {
                    isGameOver = false;
                    break;
                }
            }

            return isGameOver;
        }

        private bool isSecondaryDiagonalFull(ePlayerMarks i_player)
        {
            bool isGameOver = true;
            int columnIndex;

            for (int rowIndex = 0; rowIndex < m_GameBoard.GetSize(); rowIndex++)
            {
                columnIndex = m_GameBoard.GetSize() - rowIndex - 1;
                if (!m_GameBoard.GetPlayerAt((rowIndex, columnIndex)).Equals(i_player))
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

        private static bool isBoardSizeLegal(int i_BoardSize)
        {
            return (i_BoardSize >= k_MinBoardSize) && (i_BoardSize <= k_MaxBoardSize);
        }

        private bool isIndexLegal(int i_Index)
        {
            return i_Index <= m_GameBoard.GetSize() && i_Index >= 1;
        }

        private bool isCoordinateLegal((int,int) i_Coordinate)
        {
            return m_GameBoard.isCellEmpty(i_Coordinate);
        }
    }
}
