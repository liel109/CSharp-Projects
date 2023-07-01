using Ex02;

namespace ReversedTicTacToe
{
    public class GameSettings
    {
        public string[] PlayersNames { get; }

        private ePlayerType[] PlayerTypes { get; }

        private int BoardSize { get; }

        public GameSettings(string[] i_PlayersNames, ePlayerType[] i_PlayerTypes, int i_BoardSize)
        {
            PlayersNames = i_PlayersNames;
            PlayerTypes = i_PlayerTypes;
            BoardSize = i_BoardSize;
        }
    }
}
