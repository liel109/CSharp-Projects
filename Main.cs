using System;

class Main{
    public static void Main(string[] args){
        object num = 10;
        change(num);
        Console.WriteLine(num);
    }

    public static void change(object i_Num){
        int num = ((int)i_Num);
        num++;
    }
}