using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = 10;
            object num = n;
            change(num);
            Console.WriteLine(num);
        }

        public static void change(object i_Num)
        {
            int num = (int) i_Num;
            num++;
            i_Num = num;
        }
    }
}
