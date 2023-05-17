using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    class Player
    {
        private PlayerMarks m_PlayerMark;
        private int m_PlayerScore;
        private string m_Name;

        public string Name
        {
            get 
            {
                return m_Name; 
            }
        }

        public int Score
        {
            get
            {
                return m_PlayerScore;
            }
        }

        public PlayerMarks Mark
        {
            get
            {
                return m_PlayerMark;
            }
        }

        public Player(string i_PlayerName)
        {

        }

        internal void DoNextMove()
        {

        }
    }
}
