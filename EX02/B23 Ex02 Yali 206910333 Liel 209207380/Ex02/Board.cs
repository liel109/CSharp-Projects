using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ex02
{
    public class Board
    {
        private ePlayerMarks[,] m_BoardMatrix;

        public Board(int i_BoardSize)
        {
            m_BoardMatrix = new ePlayerMarks[i_BoardSize, i_BoardSize];

            for (int i = 0; i < m_BoardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_BoardMatrix.GetLength(1); j++)
                {
                    m_BoardMatrix[i, j] = ePlayerMarks.NONE;
                }
            }
        }

        public int GetSize()
        {
            return m_BoardMatrix.GetLength(0);
        }

        public ePlayerMarks GetPlayerAt((int, int) i_Coordinate)
        {
            return m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2];
        }

        public Board Clone()
        {
            Board boardClone = new Board(GetSize());

            for (int i = 0; i < m_BoardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_BoardMatrix.GetLength(1); j++)
                {
                    boardClone.SetPlayerAt((i, j), m_BoardMatrix[i, j]);
                }
            }

            return boardClone;
        }

        internal List<(int, int)> GetAvailableMoves()
        {
            List<(int, int)> availableMoves = new List<(int, int)>();

            for (int i = 0; i < m_BoardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_BoardMatrix.GetLength(1); j++)
                {
                    if (IsCellEmpty((i, j)))
                    {
                        availableMoves.Add((i, j));
                    }
                }
            }

            return availableMoves;
        }

        internal bool SetPlayerAt((int, int) i_Coordinate, ePlayerMarks i_Player)
        {
            bool moveSucceded;

            if (isIndexOutOfBounds(i_Coordinate) || !IsCellEmpty(i_Coordinate))
            {
                moveSucceded = false;
            }
            else
            {
                m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2] = i_Player;
                moveSucceded = true;
            }

            return moveSucceded;
        }

        internal void RemovePlayerAt((int, int) i_Coordinate)
        {
            m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2] = ePlayerMarks.NONE;
        }

        internal bool IsCellEmpty((int, int) i_Coordinate)
        {
            return m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2] == ePlayerMarks.NONE;
        }

        internal void ResetMatrix()
        {
            int boardSize = m_BoardMatrix.GetLength(0);

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    m_BoardMatrix[i, j] = ePlayerMarks.NONE;
                }
            }
        }

        private bool isIndexOutOfBounds((int, int) i_Cordinate)
        {
            return (i_Cordinate.Item1 >= m_BoardMatrix.GetLength(0)) | (i_Cordinate.Item2 >= m_BoardMatrix.GetLength(0));
        }
    }
}
