namespace Ex02
{
    public struct Player
    {
        private ePlayerMarks m_Mark;
        private ePlayerTypes m_Type;
        private int m_Score;

        public ePlayerTypes Type
        {
            get
            {
                return m_Type;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
        }

        public ePlayerMarks Mark
        {
            get
            {
                return m_Mark;
            }
        }

        public Player(ePlayerTypes i_PlayerType, ePlayerMarks i_playerMark)
        {
            m_Type = i_PlayerType;
            m_Mark = i_playerMark;
            m_Score = 0;
        }

        public void UpdateScore()
        {
            m_Score++;
        }
    }
}
