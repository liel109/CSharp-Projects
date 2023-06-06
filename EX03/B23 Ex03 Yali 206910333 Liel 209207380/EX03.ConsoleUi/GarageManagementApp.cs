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
            s_Garage.AddJob("Liel", "123456", VehicleFactory.CreateNewVehicle("12345", "1"));
            s_Garage.AddJob("Moshe", "123456", VehicleFactory.CreateNewVehicle("1231", "2"));
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
                s_Garage.ChangeStatus(selectedLicensePlate, "1");
                Console.WriteLine("Vehicle Exists, Switched to In-Progress");
            }
            else
            {
                bool isValidInput = false;

                while (!isValidInput)
                {
                    try
                    {
                        int userInput = getUserSelectionMenuInputInt("Vehicle Type", VehicleFactory.GetVehicleTypes());

                        Vehicle newVehicle = VehicleFactory.CreateNewVehicle(selectedLicensePlate, userInput);
                        addNewJob(newVehicle);
                        isValidInput = true;
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please Enter A Valid Vehicle Type");
                    }
                }               
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void showAllVehiclesMenuAction()
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                int userInput = getUserSelectionMenuInputInt("Status To Filter By", getShowVehiclesFilterOptions());

                try
                {
                    ConsoleRenderer.PrintAllJobs(s_Garage.GetJobs(userInput));
                    isInputValid = true;
                }
                catch (ArgumentException argumentException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please Enter A Valid Status");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void modifyStatusMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();

            if (s_Garage.Contains(selectedLicensePlate))
            {
                bool isValidInput = false;

                while (!isValidInput)
                {
                    try
                    {
                        ConsoleRenderer.PrintSelectionMenu("New Vehicle Status", s_Garage.GetStatusOptions());
                        string userInput = Console.ReadLine();
                        s_Garage.ChangeStatus(selectedLicensePlate, userInput);
                        isValidInput = true;
                    }
                    catch(ArgumentException argumentException)
                    {
                        Console.Clear();
                        Console.WriteLine("Please Select A Valid Status");
                    }
                }
            }
            else
            {
                Console.WriteLine("Vehicle Does Not Exist");
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
               ConsoleRenderer.PrintContinueMessage("Vehicle Does Not Exist");
            }

        }

        private static void fuelVehicleMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();
            //PetrolEngine.eFuelType selectedFuelType = getUserEnumInput<PetrolEngine.eFuelType>("Fuel Type");
            //float selectedAmountToAdd = getUserFloatInput("How Much Fuel Would You Like To Add: ");
            int selectedFuelType = getUserSelectionMenuInputInt("Fuel Type", s_Garage.GetFuelTypes());
            string selectedAmountToAdd = getUserInput("Please Enter Amount Of Fuel To Add: ");
            
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
            catch(FormatException formatException)
            {
                Console.WriteLine("Please Enter a Valid Fuel Amount");
            }

            ConsoleRenderer.PrintContinueMessage();
        }

        private static void chargeVehicleMenuAction()
        {
            string selectedLicensePlate = getUserLicensePlateInput();
            //float selectedAmountToAdd = getUserFloatInput("How Much Battery Hours Would You Like To Charge: ");
            string selectedAmountToAdd = getUserInput("Please Enter Amount Of Battery Hours To Add:");
            
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

        private static void addNewJob(Vehicle i_NewVehicle)
        {
            try
            {
                setNewVehicleProperties(i_NewVehicle);
                string selectedOwnerName = getUserInput("Please Enter Owner's Name: ");
                string selectedOwnerPhoneNumber = getUserInput("Please Enter Owner's Phone Number: ");
                s_Garage.AddJob(selectedOwnerName, selectedOwnerPhoneNumber, i_NewVehicle);
                Console.WriteLine("Vehicle Added");
            }
            catch
            {
                Console.WriteLine("One Or More Of The Inputs is Incorrect");
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
                isUserInputEmpty = (userInput == "");
                if (isUserInputEmpty)
                {
                    Console.WriteLine(string.Format("Input Cannot Be Empty"));
                }
            }

            return userInput;
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

        private static string getUserSelectionMenuInput(string i_AttributeToSelect, string[] i_SelectOptions)
        {
            ConsoleRenderer.PrintSelectionMenu(i_AttributeToSelect, i_SelectOptions);
            return Console.ReadLine();
        }

        private static int getUserSelectionMenuInputInt(string i_AttributeToSelect, string[] i_SelectOptions)
        {
            bool isInputValid = false;
            int userInputInt = 0;

            while (!isInputValid)
            {
                ConsoleRenderer.PrintSelectionMenu(i_AttributeToSelect, i_SelectOptions);
                string userInput = Console.ReadLine();
                isInputValid = isStringNumberInRange(userInput, i_SelectOptions.Length, 0);
                if (!isInputValid)
                {
                    Console.WriteLine("Please Enter A Valid Input");
                }
            }

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
                if (property.Value != null)
                {
                    propertiesAndInputs[property.Key] = getUserSelectionMenuInputInt(property.Key, property.Value).ToString();
                }
                else if(property.Value.Length == 1)
                {
                    propertiesAndInputs[property.Key] = getUserNonEmptyInput(string.Format("Please Enter {0} ({1}): ", property.Key, property.Value[0]));
                }
                else
                {
                    propertiesAndInputs[property.Key] = getUserNonEmptyInput(string.Format("Please Enter {0}: ", property.Key));
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
