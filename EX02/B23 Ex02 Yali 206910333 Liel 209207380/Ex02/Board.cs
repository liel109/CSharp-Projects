using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Board
    {
        private PlayerMarks[,] m_BoardMatrix;

        public Board(int i_BoardSize)
        {
            m_BoardMatrix = new PlayerMarks[i_BoardSize, i_BoardSize];
            
            for(int i = 0; i < m_BoardMatrix.GetLength(0); i++) 
            {
                for (int j = 0; j < m_BoardMatrix.GetLength(1); j++)
                {
                    m_BoardMatrix[i, j] = PlayerMarks.NONE;
                }
            }
        }

        internal PlayerMarks[,] getBoardClone()
        {
            return null;
        }

        internal PlayerMarks getPlayerAt((int, int) i_Coordinate)
        {
            return m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2];
        }

        internal void setPlayerAt((int,int) i_Coordinate, PlayerMarks i_Player)
        {
            if (isCellEmpty(i_Coordinate))
            {
                m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2] = i_Player;
            }
            else
            {
                throw new AccessViolationException();
            }
        }

        private bool isCellEmpty((int,int) i_Coordinate)
        {
            return m_BoardMatrix[i_Coordinate.Item1, i_Coordinate.Item2] == PlayerMarks.NONE;
        }

        /**
         * Check indentation inside for loops
         * Check for Matrix length attributes
         * Check another method implementations
         */
        internal void ResetMatrix()
        {
            for(int i=0; i<m_BoardMatrix.Length; i++)
            {
                for(int j=0; j<m_BoardMatrix.Length; j++)
                {
                    m_BoardMatrix[i, j] = PlayerMarks.NONE;
                }
            }
        }
    }
}
