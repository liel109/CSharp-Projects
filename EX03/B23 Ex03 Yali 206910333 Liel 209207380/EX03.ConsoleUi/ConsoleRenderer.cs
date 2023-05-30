using System;
using Ex03.GarageLogic;

namespace EX03.ConsoleUi
{
    public class ConsoleRenderer
    {
        public static void PrintMainMenu()
        {
            Console.WriteLine(@"What Would You Like To Do?
1 - Add A New Job
2 - Choose An Existing Job
3 - Show All Jobs");
        }

        public static void PrintVehicleListMenu()
        {
            Console.WriteLine(@"Which Vehicle Do You Want To Add?
1 - Electric Car
2 - Petrol Car
3 - Electric Motorcycle
4 - Petrol Motorcycle
5 - Truck");
        }

        public static void printCarColorsList()
        {
            Console.WriteLine(@"What Color Is The Car?
1 - Red
2 - Yellow
3 - White
4 - Black");
        }

    }
}
