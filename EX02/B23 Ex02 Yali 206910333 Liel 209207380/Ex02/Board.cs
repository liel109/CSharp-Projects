using System;

namespace Ex02
{
    public class Board
    {
        private ePlayerMarks[,] m_BoardMatrix;

        public Board(int i_BoardSize)
        {
            m_BoardMatrix = new ePlayerMarks[i_BoardSize, i_BoardSize];
            
            for(int i = 0; i < m_BoardMatrix.GetLength(0); i++) 
            {
                for (int j = 0; j < m_BoardMatrix.GetLength(1); j++)
                {
                    m_BoardMatrix[i, j] = ePlayerMarks.NONE;
                }
            }
        }

        internal ePlayerMarks[,] getBoardClone()
        {
            return m_BoardMatrix;
        }

        public ePlayerMarks GetPlayerAt((int, int) i_Coordinate)
        {
            return m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2];
        }

        internal bool setPlayerAt((int,int) i_Coordinate, ePlayerMarks i_Player)
        {
            bool moveSucceded;
            if (isIndexOutOfBounds(i_Coordinate) || !isCellEmpty(i_Coordinate))
            {
                moveSucceded= false;
            }
            else
            {
                m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2] = i_Player;
                moveSucceded = true;
            }

            return moveSucceded;
        }

        internal bool isCellEmpty((int,int) i_Coordinate)
        {
            return m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2] == ePlayerMarks.NONE;
        }

        private bool isIndexOutOfBounds((int,int) i_Cordinate)
        {
            return (i_Cordinate.Item1 >= m_BoardMatrix.GetLength(0)) | (i_Cordinate.Item2 >= m_BoardMatrix.GetLength(0));
        }

        /**
         * Check indentation inside for loops
         * Check for Matrix length attributes
         * Check another method implementations
         */
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

        public int GetSize()
        {
            return m_BoardMatrix.GetLength(0);
        }
    }
}
