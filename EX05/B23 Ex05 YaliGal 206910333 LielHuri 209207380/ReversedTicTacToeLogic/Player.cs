namespace Ex02
{
    public struct Player
    {
        private ePlayerMark m_Mark;
        private ePlayerType m_Type;
        private int m_Score;

        public Player(ePlayerType i_PlayerType, ePlayerMark i_PlayerMark)
        {
            m_Type = i_PlayerType;
            m_Mark = i_PlayerMark;
            m_Score = 0;
        }

        public ePlayerType Type
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

        public ePlayerMark Mark
        {
            get
            {
                return m_Mark;
            }
        }

        public void UpdateScore()
        {
            m_Score++;
        }
    }
}
