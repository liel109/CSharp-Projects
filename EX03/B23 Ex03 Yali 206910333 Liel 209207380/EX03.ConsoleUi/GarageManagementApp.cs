using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace EX03.ConsoleUi
{
    public class GarageManagementApp
    {
        private static Garage s_Garage = new Garage();

        static void Main(string[] args)
        {
            mainMenu();
            Console.ReadLine();
        }

        private static void runApp() 
        {
            mainMenu();
        }

        private static void mainMenu()
        {
            bool pressedExit = false;

            while (!pressedExit)
            {
                Console.Clear();
                eMainMenuAction userAction = getUserEnumInput<eMainMenuAction>("Action");
                switch (userAction)
                {
                    case eMainMenuAction.AddAJob:
                        addMenuAction();
                        break;

                    case eMainMenuAction.ShowAllJobs:
                        showAllVehiclesMenuAction();
                        break;

                    case eMainMenuAction.ChangeAJobStatus:
                        modifyStatusMenuAction();
                        break;

                    case eMainMenuAction.InflateTiresToMax:
                        inflateTiresToMaxMenuAction();
                        break;

                    case eMainMenuAction.FuelVehicle:
                        fuelVehicleMenuAction();
                        break;

                    case eMainMenuAction.ChargeVehicle:
                        chargeVehicleMenuAction();
                        break;

                    case eMainMenuAction.ShowVehicleInfo:
                        getFullInfoMenuAction();
                        break;

                    case eMainMenuAction.Exit:
                        pressedExit = true;
                        break;
                }
            }
        }

        private static void addMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();

            if (s_Garage.Contains(selectedLicensePlate))
            {
                s_Garage.ChangeStatus(selectedLicensePlate, Garage.eVehicleStatus.InProgress);
            }
            else
            {
                VehicleFactory.eVehicleType selectedType = getUserEnumInput<VehicleFactory.eVehicleType>("Vehicle Type");
                Vehicle newVehicle = VehicleFactory.CreateNewVehicle(selectedLicensePlate, selectedType);

                addNewJob(newVehicle);
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void showAllVehiclesMenuAction()
        {
            bool isValidInput = false;
            string userFilterInput;

            ConsoleRenderer.PrintSelectionMenu("Status To Filter By (Empty For All Jobs):", Enum.GetNames(typeof(Garage.eVehicleStatus)));
            while (!isValidInput)
            {
                userFilterInput = Console.ReadLine();

                try
                {
                    if (userFilterInput == "")
                    {
                        ConsoleRenderer.PrintAllJobs(s_Garage.GetJobs());
                    }
                    else
                    {
                        ConsoleRenderer.PrintAllJobs(s_Garage.GetJobs(userFilterInput));
                    }
                    isValidInput = true;
                }
                catch (Exception e)
                {
                    Console.Clear();
                    ConsoleRenderer.PrintSelectionMenu("Status To Filter By (Empty For All Jobs):", Enum.GetNames(typeof(Garage.eVehicleStatus)));
                    Console.WriteLine("Please Enter A Valid Input");
                }
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void modifyStatusMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();

            if (s_Garage.Contains(selectedLicensePlate))
            {
                Garage.eVehicleStatus selectedStatus = getUserEnumInput<Garage.eVehicleStatus>("Status");
                s_Garage.ChangeStatus(selectedLicensePlate, selectedStatus);
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void inflateTiresToMaxMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();
            
            try
            {
                s_Garage.InflateWheelsToMaximum(selectedLicensePlate);
            }
            catch(Exception e)
            {
               ConsoleRenderer.PrintContinueMessage("License Plate Doesn't Exist!");
            }

        }

        private static void fuelVehicleMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();
            eFuelType selectedFuelType = getUserEnumInput<eFuelType>("Fuel Type");
            float selectedAmountToAdd = getUserFloatInput("How Much Fuel Would You Like To Add: ");
            
            try
            {
                s_Garage.Fuel(selectedLicensePlate, selectedFuelType, selectedAmountToAdd);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
            catch(ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(string.Format("Can Only Add Between {0} - {1}", valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue));
            }
            catch (KeyNotFoundException keyNotFoundException)
            {
                Console.WriteLine("License Plate Doesn't Exist!");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void chargeVehicleMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();
            float selectedAmountToAdd = getUserFloatInput("How Much Battery Hours Would You Like To Charge: ");
            
            try
            {
                s_Garage.Charge(selectedLicensePlate, selectedAmountToAdd);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(string.Format("Can Only Add Between {0} - {1}", valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue));
            }
            catch (KeyNotFoundException keyNotFoundException)
            {
                Console.WriteLine("License Plate Doesn't Exist!");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        public static void getFullInfoMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();
            
            try
            {
                ConsoleRenderer.PrintJobFullInfo(s_Garage.GetJob(selectedLicensePlate));
            }
            catch (Exception e)
            {
                Console.WriteLine("License Plate Doesn't Exist!");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void setNewVehicleProperties(Vehicle i_NewVehicle)
        {
            Dictionary<string, string[]> propertiesAndOptions = i_NewVehicle.GetProperties();
            bool isValidPropertiesSet = false;

            while (!isValidPropertiesSet)
            {
                Dictionary<string, string> propertiesAndInputs = getUserInputsSet(propertiesAndOptions);

                try
                {
                    i_NewVehicle.SetProperties(propertiesAndInputs);
                    isValidPropertiesSet = true;
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.StackTrace);
                    //Console.WriteLine("One Or More Of The Inputs Is Invalid!");
                }
            }
        }

        private static void addNewJob(Vehicle i_NewVehicle)
        {
            setNewVehicleProperties(i_NewVehicle);
            string selectedOwnerName = getUserInput("Please Enter Owner's Name: ");
            string selectedOwnerPhoneNumber = getUserInput("Please Enter Owner's Phone Number: ");
            s_Garage.AddJob(selectedOwnerName, selectedOwnerPhoneNumber, i_NewVehicle);
            Console.WriteLine(@"Vehicle Added!
Press ENTER to return to main menu...");
            Console.ReadLine();
        }

        private static string getUserLicensePlateInput()
        {
            return getUserInput("Please Enter License Plate: ");
        }

        private static TEnum getUserEnumInput<TEnum>(string i_AttributeName) where TEnum : Enum
        {
            bool isValidTypeInput = false;
            string userInput = null;

            ConsoleRenderer.PrintSelectionMenu(i_AttributeName, Enum.GetNames(typeof(TEnum)));
            while (!isValidTypeInput)
            {
                userInput = Console.ReadLine();
                isValidTypeInput = Validator.IsValidEnumInput(typeof(TEnum), userInput);

                if (!isValidTypeInput)
                {
                    Console.Clear();
                    ConsoleRenderer.PrintSelectionMenu(i_AttributeName, Enum.GetNames(typeof(TEnum)));
                    Console.WriteLine("Please Enter A Valid Type!");
                }
            }

            return (TEnum)Enum.Parse(typeof(TEnum), userInput);
        }
        
        private static string getUserInput(string i_MessageForUser)
        {
            Console.Write(i_MessageForUser);

            return Console.ReadLine();
        }

        private static float getUserFloatInput(string i_MessageForUser)
        {
            bool isValidTypeInput = false;
            string userInput;
            float userInputFloat = 0f;

            Console.Write(i_MessageForUser);
            while (!isValidTypeInput)
            {
                userInput = Console.ReadLine();
                isValidTypeInput = float.TryParse(userInput, out userInputFloat);

                if (!isValidTypeInput)
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter A Valid Type!");
                    Console.WriteLine(i_MessageForUser);
                }
            }

            return userInputFloat;
        }

        private static Dictionary<string, string> getUserInputsSet(Dictionary<string, string[]> i_PropertiesAndOptionsDictionary)
        {
            Dictionary<string, string> propertiesAndInputs = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string[]> property in i_PropertiesAndOptionsDictionary)
            {
                Console.Clear();
                if (property.Value != null)
                {
                    ConsoleRenderer.PrintSelectionMenu(property.Key, property.Value);
                    propertiesAndInputs[property.Key] = Console.ReadLine();
                }
                else
                {
                    propertiesAndInputs[property.Key] = getUserInput(string.Format("Please Enter {0}: ", property.Key));
                }
            }

            return propertiesAndInputs;
        }
    }
}
