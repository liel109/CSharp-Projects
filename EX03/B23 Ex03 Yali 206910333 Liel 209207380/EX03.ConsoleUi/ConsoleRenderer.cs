using System;
using System.Collections.Generic;
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

        public static void PrintCarColorsList()
        {
            Console.WriteLine(@"What Color Is The Car?
1 - Red
2 - Yellow
3 - White
4 - Black");
        }

        public static void PrintSelectionMenu(string i_Attribute, string[] i_OptionsList)
        {
            Console.WriteLine(string.Format("Select {0}:", i_Attribute));
            for(int i = 0; i < i_OptionsList.Length; i++) 
            {
                Console.WriteLine(string.Format("{0,3} - {1}", i + 1, i_OptionsList[i]));
            }
        }

        public static void PrintAllJobs(List<string> i_LicensePlatesList)
        {
            Console.WriteLine("List Of Cars License Plate In Garage:");
            foreach(string licensePlate in i_LicensePlatesList)
            {
                Console.WriteLine(string.Format("{0,3}", licensePlate));
            }
        }
    }
}
