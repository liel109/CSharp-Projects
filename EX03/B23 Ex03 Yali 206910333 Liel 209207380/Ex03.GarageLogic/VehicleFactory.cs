using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private static readonly Dictionary<eVehicleType, int> sr_NumOfWheelsDict = new Dictionary<eVehicleType, int>()
        {
            { eVehicleType.ElectricCar, 4},
            { eVehicleType.PetrolCar, 4},
            { eVehicleType.ElectricMotorcyle, 2},
            { eVehicleType.PetrolMotorcycle, 2},
            { eVehicleType.Truck, 12}
        };

        private static readonly Dictionary<eVehicleType, float> sr_MaxWheelAirPressureDict = new Dictionary<eVehicleType, float>()
        {
            { eVehicleType.ElectricCar, 31},
            { eVehicleType.PetrolCar, 31},
            { eVehicleType.ElectricMotorcyle, 33},
            { eVehicleType.PetrolMotorcycle, 33},
            { eVehicleType.Truck, 26}
        };

        private static readonly Dictionary<eVehicleType, eFuelType> sr_FuelTypeDict = new Dictionary<eVehicleType, eFuelType>()
        {
            { eVehicleType.PetrolCar, eFuelType.Octan95},
            { eVehicleType.PetrolMotorcycle, eFuelType.Octan98},
            { eVehicleType.Truck, eFuelType.Soler}
        };

        private static readonly Dictionary<eVehicleType, float> sr_MaxEngineCapacity = new Dictionary<eVehicleType, float>()
        {
            { eVehicleType.ElectricCar, 5.2f},
            { eVehicleType.PetrolCar, 46f},
            { eVehicleType.ElectricMotorcyle, 2.6f},
            { eVehicleType.PetrolMotorcycle, 6.4f},
            { eVehicleType.Truck, 135f}
        };

        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType)
        {
            return null;
        }

        public enum eVehicleType 
        { 
            ElectricCar = 1,
            PetrolCar,
            ElectricMotorcyle,
            PetrolMotorcycle,
            Truck
        }

    }
}
