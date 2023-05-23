using System;

namespace Ex02
{
    public class Game
    {
        private const int k_MaxBoardSize = 9;
        private const int k_MinBoardSize = 3;
        private const int k_NumberOfPlayers = 2;

        private Board m_GameBoard;
        private Player[] m_Players = new Player[k_NumberOfPlayers];
        private int m_NumberOfMovesCounter;
        private (int, int) m_LastUpdatedCoordinate;
        private int m_NumberOfEmptySpace;

        public static int MaxBoardSize
        {
            get
            {
                return k_MaxBoardSize;
            }
        }

        public static int MinBoardSize
        {
            get
            {
                return k_MinBoardSize;
            }
        }

        public Player[] Players
        {
            get 
            {
                return m_Players;
            }
        }

        public Game(int i_BoardSize, ePlayerTypes i_SecondPlayerType)
        {
            m_GameBoard = new Board(i_BoardSize);
            m_NumberOfMovesCounter = 0;
            m_NumberOfEmptySpace = m_GameBoard.GetSize() * m_GameBoard.GetSize();
            m_Players[0] = new Player(ePlayerTypes.USER, ePlayerMarks.Player1);
            m_Players[1] = new Player(i_SecondPlayerType, ePlayerMarks.Player2);
        }
        
        public bool DoNextGameMove((int, int) i_Coordinate, out bool o_IsGameFinished)
        {
            (int,int) convertedCoordinate = convertCoordinate(i_Coordinate);
            Player currentPlayer = getCurrentPlayer();
            bool isLegalCoordinate = updateBoard(convertedCoordinate, currentPlayer.Mark);

            if (!isLegalCoordinate)
            {
                o_IsGameFinished = false;
            }
            else
            {
                o_IsGameFinished = IsGameFinished();
                currentPlayer = getCurrentPlayer();
                if (!o_IsGameFinished && currentPlayer.Type == ePlayerTypes.CPU)
                {
                    updateBoard(AIPlayerLogic.getCoordinate(m_GameBoard), currentPlayer.Mark);
                    o_IsGameFinished = IsGameFinished();
                }
            }

            return isLegalCoordinate;
        }

        private (int,int) convertCoordinate((int,int) i_Coordinate)
        {
            int rowIndex = i_Coordinate.Item1 - 1;
            int columnIndex = i_Coordinate.Item2 - 1;

            return(rowIndex, columnIndex);
        }

        public Board GetBoardState()
        {
            return m_GameBoard;
        }

        public void ResetGame()
        {
            m_GameBoard.ResetMatrix();
        }

        public int GetBoardSize()
        {
            return m_GameBoard.GetSize();
        }

        private bool updateBoard((int, int) i_Coordinate, ePlayerMarks i_PlayerMark)
        {  
            bool isCordinateLegal = m_GameBoard.setPlayerAt(i_Coordinate, i_PlayerMark);

            if (isCordinateLegal)
            {
                m_LastUpdatedCoordinate = i_Coordinate;
                m_NumberOfEmptySpace--;
                m_NumberOfMovesCounter++;
            }

            return isCordinateLegal;
        }

        private Player getCurrentPlayer()
        {

            return m_Players[m_NumberOfMovesCounter % 2];
        }

        private ref Player getPreviousPlayer()
        {

            return ref m_Players[(m_NumberOfMovesCounter-1) % 2];
        }

        private bool isPlayerWon()
        {
            bool isPlayerWon = false;
            ePlayerMarks previousPlayerMark = getPreviousPlayer().Mark;

            if (previousPlayerMark != ePlayerMarks.NONE)
            {
                int rowIndex = m_LastUpdatedCoordinate.Item1;
                int columnIndex = m_LastUpdatedCoordinate.Item2;

                if (isOnPrimaryDiagonal(m_LastUpdatedCoordinate))
                {
                    isPlayerWon = isPrimaryDiagonalFull(previousPlayerMark);
                }

                if (isOnSecondaryDiagonal(m_LastUpdatedCoordinate))
                {
                    isPlayerWon = isPlayerWon | isSecondaryDiagonalFull(previousPlayerMark);
                }

                isPlayerWon = isPlayerWon | isRowFull(rowIndex, previousPlayerMark) | isColumnFull(columnIndex, previousPlayerMark);
            }

            return isPlayerWon;
        }

        private bool IsGameFinished()
        {

            return checkIfBoardIsFull() | isPlayerWon();
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

        private bool checkIfBoardIsFull()
        {
            return m_NumberOfEmptySpace == 0;
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

        public static bool IsBoardSizeLegal(int i_BoardSize)
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

        public ePlayerMarks GetWinner()
        {
            ePlayerMarks winnerMark;

            if(isPlayerWon())
            {
                getPreviousPlayer().UpdateScore();
                winnerMark = getPreviousPlayer().Mark;
            }
            else
            {
                winnerMark = ePlayerMarks.NONE;
            }

            return winnerMark;
        }
    }
}
