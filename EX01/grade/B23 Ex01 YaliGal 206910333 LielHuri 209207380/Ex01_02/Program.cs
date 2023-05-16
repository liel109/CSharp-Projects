using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            PrintAsterikDiamond();
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

        public static void PrintAsterikDiamond(int diamondHeight = 9)
        {
            StringBuilder asterikBuilder = new StringBuilder();

            asterikDiamondCreator(ref asterikBuilder, diamondHeight);
            Console.WriteLine(asterikBuilder);
        }

        // $G$ CSS-999 (-0) The method must have an access modifier
        // $G$ CSS-999 (-0) Missing blank line, after local variable.
        static StringBuilder asterikDiamondCreator(ref StringBuilder io_AsterikDiamond, int i_HeightOfDiamond, int i_RecursionHeight = 0)
        {
            if (i_HeightOfDiamond == 1)
            {
                string numberOfAsterik = new string('*', (i_RecursionHeight * 2) + 1);
                io_AsterikDiamond.AppendLine(numberOfAsterik);
            }
            else
            {
                string numberOfSpaces = new string(' ', i_HeightOfDiamond / 2);
                string numberOfAsterik = new string('*', (i_RecursionHeight * 2) + 1);
                string rowOfDiamond = string.Format("{0}{1}", numberOfSpaces, numberOfAsterik);
                io_AsterikDiamond.AppendLine(rowOfDiamond);
                asterikDiamondCreator(ref io_AsterikDiamond, i_HeightOfDiamond - 2, i_RecursionHeight + 1);
                io_AsterikDiamond.AppendLine(rowOfDiamond);
            }

            return io_AsterikDiamond;
        }

    }
}