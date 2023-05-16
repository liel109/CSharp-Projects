using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Game
    {
        private Board m_GameBoard;

        public Game(int i_BoardSize)
        {

        }

        internal bool UpdateBoard(Tuple<int, int> i_Coordinate, Players i_Player)
        {
            return false;
        }

        internal bool isGameFinished()
        {
            return false;
        }

        internal int[,] getBoardState()
        {
            return null;
        }

        internal void ResetBoard()
        {

        }
    }
}
