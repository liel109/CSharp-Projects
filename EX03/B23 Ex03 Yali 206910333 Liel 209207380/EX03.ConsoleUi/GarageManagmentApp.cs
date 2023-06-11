using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace EX03.ConsoleUi
{
    public class GarageManagmentApp
    {
        private static Garage s_Garage = new Garage();

        public static void RunGarageApp()
        {
            showMainMenu();
            Console.ReadLine();
        }

        private static void showMainMenu()
        {
            bool pressedExit = false;

            while (!pressedExit)
            {
                Console.Clear();
                eMainMenuAction userAction = getUserEnumInput<eMainMenuAction>("Action");
                switch (userAction)
                {
                    case eMainMenuAction.AddJob:
                        addMenuAction();
                        break;

                    case eMainMenuAction.ShowAllJobs:
                        showAllVehiclesMenuAction();
                        break;

                    case eMainMenuAction.ChangeJobStatus:
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
                        Console.WriteLine("Goodbye!");
                        break;
                }
            }
        }

        private static void addMenuAction()
        {
            Console.Clear();
            string selectedLicensePlate = getUserLicensePlateInput();            
            if (s_Garage.Contains(selectedLicensePlate))
            {
                s_Garage.ChangeStatus(selectedLicensePlate, 1);
                Console.WriteLine(@"
Vehicle Exists, Updated Vehicle Status to In-Progress");
            }
            else
            {
                int userInput = getUserSelectionMenuInputInt("Vehicle Type", VehicleFactory.GetVehicleTypes());
                Vehicle newVehicle = VehicleFactory.CreateNewVehicle(selectedLicensePlate, userInput);

                addNewJob(newVehicle);
                Console.WriteLine(@"
Vehicle Added Successfully");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void showAllVehiclesMenuAction()
        {
            List<string> jobsList;
            int userInput = getUserSelectionMenuInputInt("Status To Filter By", getShowVehiclesFilterOptions());

            if (userInput == 1)
            {
                jobsList = s_Garage.GetJobs();
            }
            else
            {
                jobsList = s_Garage.GetJobs(userInput - 1);
            }

            ConsoleRenderer.PrintAllJobs(jobsList);
            ConsoleRenderer.PrintContinueMessage();
        }

        private static void modifyStatusMenuAction()
        {
            Console.Clear();
            string selectedLicensePlate = getUserLicensePlateInput();
            if (s_Garage.Contains(selectedLicensePlate))
            {
                int userInput = getUserSelectionMenuInputInt("New Vehicle Status", s_Garage.GetStatusOptions());

                s_Garage.ChangeStatus(selectedLicensePlate, userInput);
                Console.WriteLine(string.Format("Vehicle [{0}] Status Updated Successfully", selectedLicensePlate));
            }
            else
            {
                Console.WriteLine(("Vehicle Does Not Exist"));
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void inflateTiresToMaxMenuAction()
        {
            Console.Clear();
            string selectedLicensePlate = getUserLicensePlateInput();
            if (s_Garage.Contains(selectedLicensePlate))
            {
                s_Garage.InflateWheelsToMaximum(selectedLicensePlate);
                Console.WriteLine(string.Format(@"
Inflated Vehicle [{0}] Tires To Maximum Air Pressure Successfully", selectedLicensePlate));
            }
            else
            {
                Console.WriteLine("Vehicle Does Not Exist");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void fuelVehicleMenuAction()
        {
            Console.Clear();
            string selectedLicensePlate = getUserLicensePlateInput();
            if (s_Garage.Contains(selectedLicensePlate))
            {
                Console.Clear();
                int selectedFuelType = getUserSelectionMenuInputInt("Fuel Type", s_Garage.GetFuelTypes());
                Console.Clear();
                string selectedAmountToAdd = getUserNonEmptyInput("Please Enter Amount Of Fuel To Add: ");
                try
                {
                    s_Garage.Fuel(selectedLicensePlate, selectedFuelType, selectedAmountToAdd);
                    Console.WriteLine(string.Format(@"
Fueled Vehicle [{0}] With {1} Litres Successfully", selectedLicensePlate, selectedAmountToAdd));
                }
                catch (ArgumentException argumentException)
                {
                    Console.Clear();
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine(string.Format("Can Only Add Between {0} - {1}", valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue));
                }
                catch (FormatException formatException)
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter a Valid Fuel Amount");
                }
            }
            else
            {
                Console.WriteLine("License Plate Does Not Exist");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void chargeVehicleMenuAction()
        {
            Console.Clear();
            string selectedLicensePlate = getUserLicensePlateInput();
            if (s_Garage.Contains(selectedLicensePlate))
            {
                Console.Clear();
                string selectedAmountToAdd = getUserInput("Please Enter Amount Of Battery Minutes To Add: ");
                try
                {
                    s_Garage.Charge(selectedLicensePlate, selectedAmountToAdd);
                    Console.WriteLine(string.Format(@"
Charged Vehicle [{0}] With {1} Minutes Of Battery Successfully", selectedLicensePlate, selectedAmountToAdd));
                }
                catch (ArgumentException argumentException)
                {
                    Console.Clear();
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine(string.Format("Can Only Add Between {0} - {1}", valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue));
                }
                catch (FormatException formatExceptions)
                {
                    Console.Clear();
                    Console.WriteLine(string.Format("Please Enter Valid Amount Of Minutes To Add"));
                }
            }
            else
            {
                Console.WriteLine("Vehicle Does Not Exist");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        public static void getFullInfoMenuAction()
        {
            Console.Clear();
            string selectedLicensePlate = getUserLicensePlateInput();
            if (s_Garage.Contains(selectedLicensePlate))
            {
                ConsoleRenderer.PrintJobFullInfo(s_Garage.GetJob(selectedLicensePlate));
            }
            else
            {
                Console.WriteLine("Vehicle Does Not Exist");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void addNewJob(Vehicle i_NewVehicle)
        {
            bool isOperationSuccessful = false;

            while (!isOperationSuccessful)
            {
                try
                {
                    setNewVehicleProperties(i_NewVehicle);
                    string selectedOwnerName = getUserInput("Please Enter Owner's Name: ");
                    Console.Clear();
                    string selectedOwnerPhoneNumber = getUserInput("Please Enter Owner's Phone Number: ");
                    Console.Clear();
                    s_Garage.AddJob(selectedOwnerName, selectedOwnerPhoneNumber, i_NewVehicle);
                    isOperationSuccessful = true;
                }
                catch
                {
                    Console.WriteLine(@"One Or More Of The Inputs is Incorrect

Press Enter To Try Again...");
                    Console.ReadLine();
                }
            }
        }

        private static void setNewVehicleProperties(Vehicle i_NewVehicle)
        {
            Dictionary<string, string[]> propertiesAndOptions = i_NewVehicle.GetProperties();
            Dictionary<string, string> propertiesAndInputs = getUserInputsSet(propertiesAndOptions);

            i_NewVehicle.SetProperties(propertiesAndInputs);
        }

        private static string getUserLicensePlateInput()
        {
            return getUserNonEmptyInput("Please Enter License Plate: ");
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
        
        private static string getUserInput(string i_MessageForUser = "")
        {
            Console.Write(i_MessageForUser);

            return Console.ReadLine();
        }

        private static string getUserNonEmptyInput(string i_MessageForUser = "")
        {
            bool isUserInputEmpty = true;
            string userInput = null;

            while (isUserInputEmpty)
            {
                Console.Write(i_MessageForUser);
                userInput = Console.ReadLine();
                isUserInputEmpty = userInput == string.Empty;
                if (isUserInputEmpty)
                {
                    Console.Clear();
                    Console.WriteLine(string.Format("Key Cannot Be Empty"));
                }
            }

            return userInput;
        }

        private static int getUserSelectionMenuInputInt(string i_AttributeToSelect, string[] i_SelectOptions)
        {
            bool isInputValid = false;
            string userInput = null;

            Console.Clear();
            while (!isInputValid)
            {
                ConsoleRenderer.PrintSelectionMenu(i_AttributeToSelect, i_SelectOptions);
                userInput = Console.ReadLine();
                isInputValid = isStringNumberInRange(userInput, i_SelectOptions.Length, 1);
                if (!isInputValid)
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter A Valid Option");
                }
            }

            int userInputInt = int.Parse(userInput);

            return userInputInt;
        }

        private static bool isStringNumberInRange(string i_String, int i_MaxValue, int i_MinValue)
        {
            int numericValueOfString;
            bool isNumeric = int.TryParse(i_String, out numericValueOfString);

            return isNumeric && (numericValueOfString >= i_MinValue && numericValueOfString <= i_MaxValue);
        }

        private static Dictionary<string, string> getUserInputsSet(Dictionary<string, string[]> i_PropertiesAndOptionsDictionary)
        {
            Dictionary<string, string> propertiesAndInputs = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string[]> property in i_PropertiesAndOptionsDictionary)
            {
                Console.Clear();
                if (property.Value == null)
                {
                    propertiesAndInputs[property.Key] = getUserNonEmptyInput(string.Format("Please Enter {0}: ", property.Key));
                }
                else if (property.Value.Length == 1)
                {
                    propertiesAndInputs[property.Key] = getUserNonEmptyInput(string.Format("Please Enter {0} ({1}): ", property.Key, property.Value[0]));
                }
                else
                {
                    propertiesAndInputs[property.Key] = getUserSelectionMenuInputInt(property.Key, property.Value).ToString();
                }
            }

            return propertiesAndInputs;
        }

        private static string[] getShowVehiclesFilterOptions()
        {
            string[] statusList = s_Garage.GetStatusOptions();
            string[] filterOptions = new string[statusList.Length + 1];

            filterOptions[0] = "All Jobs";
            statusList.CopyTo(filterOptions, 1);

            return filterOptions;
        }
    }
}
