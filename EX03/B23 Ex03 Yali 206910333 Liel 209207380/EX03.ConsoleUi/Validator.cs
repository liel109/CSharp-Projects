using System;

namespace EX03.ConsoleUi
{
    public class Validator
    {
        public static bool IsValidEnumInput(Type i_EnumType, string i_UserInput)
        {
            int userInputInt;

            return int.TryParse(i_UserInput, out userInputInt) && Enum.IsDefined(i_EnumType, userInputInt);
        }
    }
}
