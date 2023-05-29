using System;

namespace Ex03.GarageLogic
{
    public class Truck : PetrolVehicle
    {
        private const int k_WheelMaxAirPressure = 26;
        private const int k_NumberOfWheels = 14;
        private const int k_MaxFuelCapacity = 135;
        private const eFuelType k_FuelType = eFuelType.Soler;

        private readonly bool mr_IsCarryingHazardousMaterial;
        private readonly float mr_CargoVolume;

        public Truck(string i_LicensePlate, PetrolEngine i_Engine, Wheel[] i_Wheels)
        {
        }
    }
}
