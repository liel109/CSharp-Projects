﻿using System;

namespace Ex02
{
    public class Game
    {
        private const int k_MaxBoardSize = 9;
        private const int k_MinBoardSize = 3;
        private const int k_NumberOfPlayers = 2;

        private Board m_GameBoard;
        private Player[] m_Players;
        private int m_NumberOfMovesCounter;
        private int m_NumberOfEmptySpace;
        private (int, int) m_LastUpdatedCoordinate;

        public event Action<ePlayerMark> GameFinished;

        public event Action<(int, int)> BoardChanged;

        public static bool IsBoardSizeLegal(int i_BoardSize)
        {
            return (i_BoardSize >= k_MinBoardSize) && (i_BoardSize <= k_MaxBoardSize);
        }

        public Game(int i_BoardSize, ePlayerType i_SecondPlayerType) : this(new Board(i_BoardSize), i_SecondPlayerType, 0, i_BoardSize * i_BoardSize)
        {
        }

        private Game(Board i_GameBoard, ePlayerType i_SecondPlayerType, int i_NumberOfMovesCounter, int i_NumberOfEmptySpace)
        {
            m_GameBoard = i_GameBoard;
            m_NumberOfMovesCounter = i_NumberOfMovesCounter;
            m_NumberOfEmptySpace = i_NumberOfEmptySpace;
            m_Players = new Player[k_NumberOfPlayers];
            m_Players[0] = new Player(ePlayerType.User, ePlayerMark.Player1);
            m_Players[1] = new Player(i_SecondPlayerType, ePlayerMark.Player2);
        }

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

        public int MovesCounter
        {
            get { return m_NumberOfMovesCounter; }
        }

        public Game Clone()
        {
            ePlayerType secondPlayerType = Players[1].Type;
            Board boardClone = m_GameBoard.Clone();
            Game gameClone = new Game(boardClone, secondPlayerType, m_NumberOfMovesCounter, m_NumberOfEmptySpace);

            return gameClone;
        }

        public void DoNextGameMove((int, int) i_Coordinate)
        {
            bool isGameFinished;
            Player currentPlayer = getCurrentPlayer();

            UpdateBoard(i_Coordinate, currentPlayer.Mark);
            isGameFinished = IsGameFinished();
            currentPlayer = getCurrentPlayer();
            if (!isGameFinished && currentPlayer.Type == ePlayerType.CPU)
            {
                (int, int) computerCoordinate = AIPlayerLogic.GetBestMove(Clone());
                UpdateBoard(computerCoordinate, currentPlayer.Mark);
                IsGameFinished();
            }
        }

        public Board GetBoardState()
        {
            return m_GameBoard;
        }

        public void ResetGame()
        {
            m_GameBoard.ResetMatrix();
            m_NumberOfEmptySpace = m_GameBoard.GetSize() * m_GameBoard.GetSize();
            m_NumberOfMovesCounter = 0;
        }

        public int GetBoardSize()
        {
            return m_GameBoard.GetSize();
        }

        public bool isIndexLegal(int i_Index)
        {
            return i_Index <= m_GameBoard.GetSize() && i_Index >= 1;
        }

        public ePlayerMark GetWinner()
        {
            ePlayerMark winnerMark;

            if (m_NumberOfMovesCounter == 0)
            {
                winnerMark = ePlayerMark.None;
            }
            else if (IsPlayerWon(getPreviousPlayer().Mark))
            {
                getCurrentPlayer().UpdateScore();
                winnerMark = getCurrentPlayer().Mark;
            }
            else
            {
                winnerMark = ePlayerMark.None;
            }

            return winnerMark;
        }

        internal int GetNumOfEmptySpaces()
        {
            return m_NumberOfEmptySpace;
        }

        internal bool UpdateBoard((int, int) i_Coordinate, ePlayerMark i_PlayerMark)
        {
            bool isCordinateLegal = m_GameBoard.SetPlayerAt(i_Coordinate, i_PlayerMark);

            if (isCordinateLegal)
            {
                m_LastUpdatedCoordinate = i_Coordinate;
                m_NumberOfEmptySpace--;
                m_NumberOfMovesCounter++;
                OnBoardChanged(i_Coordinate);
            }

            return isCordinateLegal;
        }

        internal void UndoMove((int, int) i_Coordinate)
        {
            m_GameBoard.RemovePlayerAt(i_Coordinate);
            m_NumberOfEmptySpace++;
            m_NumberOfMovesCounter--;
        }

        internal bool CheckIfBoardIsFull()
        {
            return m_NumberOfEmptySpace == 0;
        }

        internal bool IsCoordinateEmpty((int, int) i_Coordinate)
        {
            return m_GameBoard.IsCellEmpty(i_Coordinate);
        }

        internal bool IsPlayerWon(ePlayerMark i_PlayerMark)
        {
            bool isPlayerWon = false;
            ePlayerMark previousPlayerMark = i_PlayerMark;

            if (previousPlayerMark != ePlayerMark.None)
            {
                int rowIndex = m_LastUpdatedCoordinate.Item1;
                int columnIndex = m_LastUpdatedCoordinate.Item2;

                if (isOnPrimaryDiagonal(m_LastUpdatedCoordinate))
                {
                    isPlayerWon = isPrimaryDiagonalFull(previousPlayerMark);
                }

                if (isOnSecondaryDiagonal(m_LastUpdatedCoordinate))
                {
                    isPlayerWon |= isSecondaryDiagonalFull(previousPlayerMark);
                }

                isPlayerWon = isPlayerWon | isRowFull(rowIndex, previousPlayerMark) | isColumnFull(columnIndex, previousPlayerMark);
            }

            return isPlayerWon;
        }

        internal bool IsGameFinished()
        {
            bool isFinished;

            if (CheckIfBoardIsFull() | IsPlayerWon(getPreviousPlayer().Mark))
            {
                isFinished = true;
                OnGameFinished();
            }
            else
            {
                isFinished = false;
            }

            return isFinished;
        }

        private bool isPrimaryDiagonalFull(ePlayerMark i_player)
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

        private bool isRowFull(int i_Row, ePlayerMark i_player)
        {
            bool isGameOver = true;

            for (int column = 0; column < m_GameBoard.GetSize(); column++)
            {
                if (m_GameBoard.GetPlayerAt((i_Row, column)) != i_player)
                {
                    isGameOver = false;
                    break;
                }
            }

            return isGameOver;
        }

        private bool isColumnFull(int i_Column, ePlayerMark i_player)
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

        private bool isSecondaryDiagonalFull(ePlayerMark i_player)
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

        public ref Player getCurrentPlayer()
        {
            return ref m_Players[m_NumberOfMovesCounter % 2];
        }

        private Player getPreviousPlayer()
        {
            return m_Players[(m_NumberOfMovesCounter - 1) % 2];
        }

        private (int, int) convertCoordinate((int, int) i_Coordinate)
        {
            int rowIndex = i_Coordinate.Item1 - 1;
            int columnIndex = i_Coordinate.Item2 - 1;

            return (rowIndex, columnIndex);
        }

        protected virtual void OnGameFinished()
        {
            GameFinished?.Invoke(GetWinner());
        }

        protected virtual void OnBoardChanged((int, int) i_UpdatedCoordinate)
        {
            BoardChanged?.Invoke(i_UpdatedCoordinate);
        }
    }
}
