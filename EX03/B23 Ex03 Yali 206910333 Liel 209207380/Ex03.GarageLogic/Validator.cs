using System;

namespace Ex03.GarageLogic
{
    public class Validator
    {
        public static TEnum ValidateEnum<TEnum>(string i_UserInput) where TEnum : Enum
        {
            int userInputInt;

            if (!int.TryParse(i_UserInput, out userInputInt) || !Enum.IsDefined(typeof(TEnum), userInputInt))
            {
                throw new ArgumentException("Invalid Enum!");
            }

            return (TEnum)Enum.Parse(typeof(TEnum), i_UserInput);
        }

        public static void ValidatePositiveFloat(string i_UserInputString, out float o_UserInputFloat)
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

        public static void ValidatePositiveInt(string i_UserInputString, out int o_UserInputFloat)
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
