using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace EX03.ConsoleUi
{
    public class ConsoleRenderer
    {
        public static void PrintSelectionMenu(string i_Attribute, string[] i_OptionsList)
        {
            Console.WriteLine(string.Format("Select {0}:", i_Attribute));
            for (int i = 0; i < i_OptionsList.Length; i++)
            {
                string parsedName = parseEnumName(i_OptionsList[i]);

                Console.WriteLine(string.Format("{0,3} - {1}", i + 1, parsedName));
            }
        }

        public static void PrintAllJobs(List<string> i_LicensePlatesList)
        {
            Console.Clear();
            if (i_LicensePlatesList.Count == 0)
            {
                Console.WriteLine("No Vehicles");
            }
            else
            {
                Console.WriteLine("Jobs List:");
                foreach (string licensePlate in i_LicensePlatesList)
                {
                    Console.WriteLine(string.Format("   {0}", licensePlate));
                }
            }
        }

        public static void PrintContinueMessage(string i_MessageForUser = "")
        {
            Console.WriteLine(string.Format(@"{0}
Press Enter To Return To Main Menu...", i_MessageForUser));
            Console.ReadLine();
        }

        public static void PrintJobFullInfo(EntryForm i_Form)
        {
            Console.Clear();
            Console.WriteLine(string.Format(@"Job Information:
=====================================
Owner's Name: {0}
Owner's Phone Number: {1}
Vehicle Info:
{2}", i_Form.OwnerName, i_Form.OwnerPhoneNumber, parseVehicleInforamtion(i_Form.Vehicle.ToString())));
        }

        private static string parseEnumName(string i_EnumValueName)
        {
            StringBuilder enumNameBuilder = new StringBuilder();

            enumNameBuilder.Append(i_EnumValueName[0]);
            for (int i = 1; i < i_EnumValueName.Length; i++)
            {
                char prevChar = i_EnumValueName[i - 1];
                char currentChar = i_EnumValueName[i];

                if (char.IsUpper(currentChar) && !char.IsUpper(prevChar) && !char.IsWhiteSpace(prevChar))
                {
                    enumNameBuilder.Append(" ");
                }

                enumNameBuilder.Append(i_EnumValueName[i]);
            }

            return enumNameBuilder.ToString();
        }

        private static string parseVehicleInforamtion(string i_VehicleInformation)
        {
            StringBuilder stringBuilder = new StringBuilder(i_VehicleInformation);

            stringBuilder.Replace("\n", "\n   ");
            stringBuilder.Insert(0, "   ");
            return stringBuilder.ToString();
        }
    }
}
