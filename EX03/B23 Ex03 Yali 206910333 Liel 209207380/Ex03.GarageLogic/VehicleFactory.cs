﻿using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

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

        public static Vehicle CreateNewVehicle(string i_LicensePlate, eVehicleType i_VehicleType)
        {
            Vehicle vehicle;
            Engine engine = createEngine(i_VehicleType);
            Vehicle.Wheel[] wheels = createWheels(i_VehicleType);

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar(i_LicensePlate, engine as ElectricEngine, wheels);
                    break;

                case eVehicleType.PetrolCar:
                    vehicle = new PetrolCar(i_LicensePlate, engine as PetrolEngine, wheels);
                    break;

                case eVehicleType.ElectricMotorcyle:
                    vehicle = new ElecticMotorcycle(i_LicensePlate, engine as ElectricEngine, wheels);
                    break;

                case eVehicleType.PetrolMotorcycle:
                    vehicle = new PetrolMotorcycle(i_LicensePlate, engine as PetrolEngine, wheels);
                    break;

                case eVehicleType.Truck:
                    vehicle = new Truck(i_LicensePlate, engine as PetrolEngine, wheels);
                    break;

                default:
                    vehicle = null;
                    break;
            }

            return vehicle;
        }

        public enum eVehicleType 
        { 
            ElectricCar = 1,
            PetrolCar,
            ElectricMotorcyle,
            PetrolMotorcycle,
            Truck
        }

        private static Engine createEngine(eVehicleType i_VehicleType)
        {
            Engine engine = null;

            if (i_VehicleType == eVehicleType.PetrolCar || i_VehicleType == eVehicleType.PetrolMotorcycle || i_VehicleType == eVehicleType.Truck)
            {
                engine = new PetrolEngine(sr_FuelTypeDict[i_VehicleType], sr_MaxEngineCapacity[i_VehicleType]);
            }
            else if(i_VehicleType == eVehicleType.ElectricCar || i_VehicleType == eVehicleType.ElectricMotorcyle)
            {
                engine = new ElectricEngine(sr_MaxEngineCapacity[i_VehicleType]);
            }

            return engine;
        }

        private static Vehicle.Wheel[] createWheels(eVehicleType i_VehicleType)
        {
            Vehicle.Wheel[] wheels = new Vehicle.Wheel[sr_NumOfWheelsDict[i_VehicleType]];
            
            for(int i=0; i<wheels.Length; i++)
            {
                wheels[i] = new Vehicle.Wheel(sr_MaxWheelAirPressureDict[i_VehicleType]);
            }

            return wheels;
        } 


    }
}