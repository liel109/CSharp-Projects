using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace EX03.ConsoleUi
{
    public class GarageManagmentAppBeta
    {
        private static Garage s_Garage = new Garage();
        
        public static void Main()
        {
            foreach(string name in Enum.GetNames(typeof(Car.eColor)))
                {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }

        private static void RunGarageApp()
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

        private static string getLicensePlateFromUser()
        {
            Console.Write("Enter License Plate Number:");
            
            return Console.ReadLine();
        }

        private static VehicleFactory.eVehicleType getVehicleTypeFromUser()
        {
            bool isValidInput = false;
            string userInput = null;
            int userInputInt;

            ConsoleRenderer.PrintVehicleListMenu();
            while (!isValidInput)
            {
                userInput = Console.ReadLine();

                isValidInput = Validator.IsVehicleTypeInputValid(userInput);
                if (!isValidInput)
                {
                    Console.Clear();
                    ConsoleRenderer.PrintVehicleListMenu();
                    Console.WriteLine("Please Choose A Valid Type!");
                }
            }

            userInputInt = int.Parse(userInput);

            return (VehicleFactory.eVehicleType)userInputInt;
        }

        private static string getOwnerNameFromUser()
        {
            bool isInputValid = false;
            string userInput = null;

            Console.Write("Please Enter Owner's Name: ");
            while (!isInputValid)
            {
                userInput = Console.ReadLine();

                isInputValid = Validator.IsValidVehicleOwnerName(userInput);
                if (!isInputValid)
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter A Valid Name");
                    Console.Write("Please Enter Owner's Name: ");
                }
            }

            return userInput;
        }

        private static string getOwnerPhoneNumber()
        {
            bool isInputValid = false;
            string userInput = null;

            Console.Write("Please Enter Owner's PhoneNumber: ");
            while (!isInputValid)
            {
                userInput = Console.ReadLine();

                isInputValid = Validator.IsValidVehicleOwnerPhoneNumber(userInput);
                if (!isInputValid)
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter A Valid Number");
                    Console.Write("Please Enter Owner's PhoneNumber: ");
                }
            }

            return userInput;
        }

        private static Car.eColor getColorTypeFromUser()
        {
            bool isValidInput = false;
            string userInput = null;
            int userInputInt;

            ConsoleRenderer.printCarColorsList();
            while (!isValidInput)
            {
                userInput = Console.ReadLine();

                isValidInput = Validator.IsColorInputValid(userInput);
                if (!isValidInput)
                {
                    Console.Clear();
                    ConsoleRenderer.printCarColorsList();
                    Console.WriteLine("Please Choose A Valid Color!");
                }
            }

            userInputInt = int.Parse(userInput);

            return (Car.eColor)userInputInt;
        }

        private static Car.eDoorsNumber getDoorsNumberFromUser()
        {
            bool isValidInput = false;
            string userInput = null;
            int userInputInt;

            Console.WriteLine("How Many Doors Does The Car Have?");
            while (!isValidInput)
            {
                userInput = Console.ReadLine();

                isValidInput = Validator.IsValidEnumInput(typeof(Car.eDoorsNumber), userInput);
                if (!isValidInput)
                {
                    Console.Clear();
                    Console.WriteLine("How Many Doors Does The Car Have?");
                    Console.WriteLine("Please Choose A Valid Number Of Doors!");
                }
            }

            userInputInt = int.Parse(userInput);

            return (Car.eDoorsNumber)userInputInt;
        }

        private static float getBatteryRemainingHoursFromUser()
        {
            bool isInputValid = false;
            string userInput = null;
            float userInputFloat;

            Console.Write("Please BatteryRemaining Hours:");
            while (!isInputValid)
            {
                userInput = Console.ReadLine();

                isInputValid = Validator.IsValidBatteryRemainingHours(userInput);
                if (!isInputValid)
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter A Valid Number");
                    Console.Write("Please Battery Remaining Hours: ");
                }
            }

            float.TryParse(userInput, out userInputFloat);

            return userInputFloat;
        }

        private static void addMenuAction()
        {
            string licensePlateInput = getLicensePlateFromUser();

            if (s_Garage.Contains(licensePlateInput))
            {
                modifyJob(); /// Implement
            }
            else
            {
                VehicleFactory.eVehicleType selectedType = getVehicleTypeFromUser();
                Vehicle newVehicle = CreateNewVehicle(licensePlateInput, selectedType);
                addNewJob(newVehicle);
            }
        }

        private static Vehicle CreateNewVehicle(string i_NewLicensePlate, VehicleFactory.eVehicleType i_NewVehicleType)
        {
            Vehicle newVehicle = VehicleFactory.CreateNewVehicle(i_NewLicensePlate, i_NewVehicleType);

            foreach (KeyValuePair<string,string[]> pair in newVehicle.GetProperties())
            {
                Console.Write(string.Format("Please Enter {0} ", pair.Key));
            }
            //switch (i_NewVehicleType)
            //{
            //    case VehicleFactory.eVehicleType.ElectricCar:
            //        getNewElectricCarInfoFromUser(newVehicle as Car);
            //        break;

            //    case VehicleFactory.eVehicleType.PetrolCar:
            //        getNewPetrolCarInfoFromUser(newVehicle as Car);
            //        break;

            //    case VehicleFactory.eVehicleType.ElectricMotorcycle:
            //        getNewElectricMotorcycleInfoFromUser(newVehicle as Motorcycle);
            //        break;

            //    case VehicleFactory.eVehicleType.PetrolMotorcycle:
            //        getNewPetrolMotorcycleInfoFromUser(newVehicle as Motorcycle);
            //        break;

            //    case VehicleFactory.eVehicleType.Truck:
            //        getNewTruckInfoFromUser(newVehicle as Truck);
            //        break;
            //}

            return newVehicle;
        }

        private static void addNewJob(Vehicle i_Vehicle)
        {
            string selectedOwnerName = getOwnerNameFromUser();
            string selectedOwnerPhoneNumber = getOwnerPhoneNumber();
            s_Garage.AddJob(selectedOwnerName, selectedOwnerPhoneNumber, i_Vehicle);
        }

        private static void modifyJob()
        {

        }

        private static void getNewElectricCarInfoFromUser(Car i_NewElectricCar)
        {
            ElectricEngine electricEngine = i_NewElectricCar.Engine as ElectricEngine;

            while (true)
            {
                try
                {
                    electricEngine.RemainingBatteryHours = getBatteryRemainingHoursFromUser();
                    break;
                }
                catch(ValueOutOfRangeException e)
                {
                    Console.WriteLine(string.Format("Max Battery Remaining Hours: {0}", e.MaxValue));
                }
            }

            getCarInfoFromUser(i_NewElectricCar);
        }

        private static void getNewPetrolCarInfoFromUser(Car i_NewPetrolCar)
        {

        }

        private static void getCarInfoFromUser(Car i_NewCar)
        {
            i_NewCar.DoorsNumber = getDoorsNumberFromUser();
            i_NewCar.Color = getColorTypeFromUser();                
        }

        private static void getNewElectricMotorcycleInfoFromUser(Motorcycle i_NewElectricMotorcycle)
        {

        }

        private static void getNewPetrolMotorcycleInfoFromUser(Motorcycle i_NewPetrolMotorcycle)
        {

        }

        private static void getNewTruckInfoFromUser(Truck i_NewTruck)
        {

        }
    }
}
