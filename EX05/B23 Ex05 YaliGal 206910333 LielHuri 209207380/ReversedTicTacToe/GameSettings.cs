using System;
using Ex02;

namespace ReversedTicTacToe
{
    public class GameSettings
    {
        public string[] PlayersNames { get; }

        public ePlayerType[] PlayerTypes { get; }

        public int BoardSize { get; }

        public GameSettings(string[] i_PlayersNames, ePlayerType[] i_PlayerTypes, int i_BoardSize)
        {
            PlayersNames = i_PlayersNames;
            PlayerTypes = i_PlayerTypes;
            BoardSize = i_BoardSize;
        }

        public void printSettings()
        {
            Console.WriteLine(PlayersNames[0]);
            Console.WriteLine(PlayersNames[1]);
            Console.WriteLine(PlayerTypes[0]);
            Console.WriteLine(PlayerTypes[1]);
            Console.WriteLine(BoardSize);
        }
    }
}
