using System;
using Ex03.GarageLogic;

namespace EX03.ConsoleUi
{
    public class Validator
    {
        public static bool IsMainMenuInputValid(string i_UserInput)
        {
            int userInputInt;

            return int.TryParse(i_UserInput, out userInputInt) && Enum.IsDefined(typeof(eMainMenuAction), userInputInt);
        }

        public static bool isValidLicensePlate(string i_UserInput)
        {
            int userInputInt;

            return int.TryParse(i_UserInput, out userInputInt);
        }

        public static bool IsVehicleTypeInputValid(string i_UserInput)
        {
            int userInputInt;

            return int.TryParse(i_UserInput, out userInputInt) && Enum.IsDefined(typeof(VehicleFactory.eVehicleType), userInputInt);
        }

        public static bool IsValidVehicleOwnerName(string i_UserInput)
        {
            bool isAllLetters = true;

            foreach (char character in i_UserInput)
            {
                isAllLetters = isAllLetters && (char.IsLetter(character) || character == ' ');
            }

            return isAllLetters;
        }

        public static bool IsValidVehicleOwnerPhoneNumber(string i_UserInput)
        {
            int userInputInt;

            return int.TryParse(i_UserInput, out userInputInt);
        }

        public static bool IsValidBatteryRemainingHours(string i_UserInput)
        {
            float userInputFloat;

            return float.TryParse(i_UserInput, out userInputFloat);
        }

        public static bool IsColorInputValid(string i_UserInput)
        {
            int userInputInt;

            return int.TryParse(i_UserInput, out userInputInt) && Enum.IsDefined(typeof(Car.eColor), userInputInt);
        }

        public static bool IsValidEnumInput(Type i_EnumType, string i_UserInput)
        {
            int userInputInt;

            return int.TryParse(i_UserInput, out userInputInt) && Enum.IsDefined(i_EnumType, userInputInt);
        }
    }
}
