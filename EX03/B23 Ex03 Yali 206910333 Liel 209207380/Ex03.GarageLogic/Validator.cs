using System;

namespace Ex03.GarageLogic
{
    public class Validator
    {

        public static void ValidateEnum(Type i_EnumType, string i_UserInput)
        {
            int userInputInt;

            if (!int.TryParse(i_UserInput, out userInputInt) && Enum.IsDefined(i_EnumType, userInputInt))
            {
                throw new ArgumentException("Invalid Enum!");
            }
        }

        public static void ValidatePossitiveFloat(string i_UserInputString, out float o_UserInputFloat)
        {
            if (!float.TryParse(i_UserInputString, out o_UserInputFloat))
            {
                throw new FormatException("Needs To Recieve A Float!");
            }
            if (o_UserInputFloat < 0)
            {
                throw new ArgumentException("The Number Needs To Be Greater Then 0!");
            }
        }

        public static void ValidatePossitiveInt(string i_UserInputString, out int o_UserInputFloat)
        {
            if (!int.TryParse(i_UserInputString, out o_UserInputFloat))
            {
                throw new FormatException("Needs To Recieve An Int!");
            }
            if (o_UserInputFloat < 0)
            {
                throw new ArgumentException("The Number Needs To Be Greater Then 0!");
            }
        }

        public static void ValidateHazardousMaterialInput(string i_UserInputString, out bool o_UserInputBool)
        {
            int userInputInt;

            if(!int.TryParse(i_UserInputString, out userInputInt) || (userInputInt < 1 || userInputInt > 2))
            {
                throw new ArgumentException("Invalid Argument (1 or 2 is needed)");
            }
            if(userInputInt == 1)
            {
                o_UserInputBool = true;
            }
            else
            {
                o_UserInputBool = false;
            }
        }
    }
}
