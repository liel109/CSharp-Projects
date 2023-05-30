using System;

namespace EX03.ConsoleUi
{
    public class GarageManagementApp
    {

        private static void runApp() 
        {
            mainMenu();
        }

        private static void mainMenu()
        {
            ConsoleRenderer.PrintMainMenu();
            eMainMenuAction userAction = getUserMainMenuInput();
            switch (userAction)
            {
                case eMainMenuAction.AddAJob:
                    //addMenuAction();
                    break;

                case eMainMenuAction.EditAJob:
                    //modifyJob();
                    break;

                case eMainMenuAction.ShowAllJobs:
                    /// TODO: implement
                    break;
            }
        }

        private static void addMenuAction()
        {

        }

        private static void modifyMenuAction()
        {

        }

        private static void showAllVehiclesMenuAction()
        {

        }

        private static eMainMenuAction getUserMainMenuInput()
        {
            bool isValidInput = false;
            string userInput = null;
            int userInputInt;

            while (!isValidInput)
            {
                userInput = Console.ReadLine();

                isValidInput = Validator.IsMainMenuInputValid(userInput);
                if (!isValidInput)
                {
                    Console.WriteLine("Please Choose A Valid Option!");
                }
            }

            userInputInt = int.Parse(userInput);

            return (eMainMenuAction)userInputInt;
        }
    }
}
