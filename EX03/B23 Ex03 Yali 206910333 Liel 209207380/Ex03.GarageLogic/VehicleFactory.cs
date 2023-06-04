using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private static readonly Dictionary<eVehicleType, int> sr_NumOfWheelsDict = new Dictionary<eVehicleType, int>()
        {
            { eVehicleType.ElectricCar, 4},
            { eVehicleType.PetrolCar, 4},
            { eVehicleType.ElectricMotorcycle, 2},
            { eVehicleType.PetrolMotorcycle, 2},
            { eVehicleType.Truck, 12}
        };

        private static readonly Dictionary<eVehicleType, float> sr_MaxWheelAirPressureDict = new Dictionary<eVehicleType, float>()
        {
            { eVehicleType.ElectricCar, 31},
            { eVehicleType.PetrolCar, 31},
            { eVehicleType.ElectricMotorcycle, 33},
            { eVehicleType.PetrolMotorcycle, 33},
            { eVehicleType.Truck, 26}
        };

        private static readonly Dictionary<eVehicleType, PetrolEngine.eFuelType> sr_FuelTypeDict = new Dictionary<eVehicleType, PetrolEngine.eFuelType>()
        {
            { eVehicleType.PetrolCar, PetrolEngine.eFuelType.Octan95},
            { eVehicleType.PetrolMotorcycle, PetrolEngine.eFuelType.Octan98},
            { eVehicleType.Truck, PetrolEngine.eFuelType.Soler}
        };

        private static readonly Dictionary<eVehicleType, float> sr_MaxEngineCapacity = new Dictionary<eVehicleType, float>()
        {
            { eVehicleType.ElectricCar, 5.2f},
            { eVehicleType.PetrolCar, 46f},
            { eVehicleType.ElectricMotorcycle, 2.6f},
            { eVehicleType.PetrolMotorcycle, 6.4f},
            { eVehicleType.Truck, 135f}
        };

        public static Vehicle CreateNewVehicle(string i_LicensePlate, eVehicleType i_VehicleType)
        {
            //int vehicleTypeInt;
            //if (!isValidEnumInput(typeof(eVehicleType), i_VehicleType, out vehicleTypeInt))
            //{
            //    if (!int.TryParse(i_VehicleType, out _))
            //    {
            //        throw new FormatException();
            //    }
            //    else
            //    {
            //        throw new ArgumentException();
            //    }
            //}
            //eVehicleType i_VehicleType = (eVehicleType)vehicleTypeInt;
            Vehicle vehicle;
            Engine engine = createEngine(i_VehicleType);
            Vehicle.Tire[] tires = createTires(i_VehicleType);

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicle = new Car(i_LicensePlate, engine as ElectricEngine, tires);
                    break;

                case eVehicleType.PetrolCar:
                    vehicle = new Car(i_LicensePlate, engine as PetrolEngine, tires);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    vehicle = new Motorcycle(i_LicensePlate, engine as ElectricEngine, tires);
                    break;

                case eVehicleType.PetrolMotorcycle:
                    vehicle = new Motorcycle(i_LicensePlate, engine as PetrolEngine, tires);
                    break;

                case eVehicleType.Truck:
                    vehicle = new Truck(i_LicensePlate, engine as PetrolEngine, tires);
                    break;

                default:
                    vehicle = null;
                    break;
            }

            return vehicle;
        }

        public static string[] GetVehicleTypes()
        {
            return Enum.GetNames(typeof(eVehicleType));
        }

        public enum eVehicleType 
        { 
            ElectricCar = 1,            
            PetrolCar = 2,
            ElectricMotorcycle = 3,
            PetrolMotorcycle = 4,
            Truck = 5
        }

        private static Engine createEngine(eVehicleType i_VehicleType)
        {
            Engine engine = null;

            if (i_VehicleType == eVehicleType.PetrolCar || i_VehicleType == eVehicleType.PetrolMotorcycle || i_VehicleType == eVehicleType.Truck)
            {
                engine = new PetrolEngine(sr_FuelTypeDict[i_VehicleType], sr_MaxEngineCapacity[i_VehicleType]);
            }
            else if(i_VehicleType == eVehicleType.ElectricCar || i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                engine = new ElectricEngine(sr_MaxEngineCapacity[i_VehicleType]);
            }

            return engine;
        }

        private static Vehicle.Tire[] createTires(eVehicleType i_VehicleType)
        {
            Vehicle.Tire[] wheels = new Vehicle.Tire[sr_NumOfWheelsDict[i_VehicleType]];
            
            for(int i=0; i<wheels.Length; i++)
            {
                wheels[i] = new Vehicle.Tire(sr_MaxWheelAirPressureDict[i_VehicleType]);
            }

            return wheels;
        }

        private static bool isValidEnumInput(Type i_EnumType, string i_UserInput, out int o_userInputInt)
        {

            return int.TryParse(i_UserInput, out o_userInputInt) && Enum.IsDefined(i_EnumType, o_userInputInt);
        }
    }
}
