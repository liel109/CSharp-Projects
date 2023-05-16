using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Board
    {
        private Players[,] m_BoardMatrix;

        public Board()
        {

        }

        internal Players getPlayerAt(Tuple<int,int> i_Coordinate)
        {
            return Players.NONE;
        }

        internal void setPlayerAt(Tuple<int,int> i_Coordinate, Player i_Player)
        {

        }

        internal void ResetMatrix()
        {

        }
    }
}
