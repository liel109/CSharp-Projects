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
            for(int i = 0; i < i_OptionsList.Length; i++) 
            {
                string parsedName = parseEnumName(i_OptionsList[i]);

                Console.WriteLine(string.Format("{0,3} - {1}", i + 1, parsedName));
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

        public static void PrintContinueMessage(string i_MessageForUser = "")
        {
            Console.WriteLine(string.Format(@"{0}
Press Enter To Return To Main Menu...", i_MessageForUser));
            Console.ReadLine();
        }

        public static void PrintJobFullInfo(EntryForm i_Form)
        {
            Console.WriteLine(string.Format(@"Information:
Owner Name: {0}

Owner Phone: {1}

Vehicle Info:
{2}", i_Form.OwnerName, i_Form.OwnerPhoneNumber, i_Form.Vehicle));
        }

        private static string parseEnumName(string i_EnumValueName)
        {
            StringBuilder enumNameBuilder = new StringBuilder();

            for (int i = 0; i < i_EnumValueName.Length; i++)
            {
                if(char.IsUpper(i_EnumValueName[i]) && i > 0)
                {
                    enumNameBuilder.Append(" ");
                }
                enumNameBuilder.Append(i_EnumValueName[i]);
            }

            return enumNameBuilder.ToString();
        }
    }
}
