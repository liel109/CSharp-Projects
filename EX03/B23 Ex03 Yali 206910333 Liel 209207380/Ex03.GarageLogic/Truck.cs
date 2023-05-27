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

        public Truck(string i_LicensePlate, string i_Model, float[] i_WheelsAirPressure, string[] i_WheelManufacturer, float i_FuelAmount, bool i_IsCarryingHazardousMaterial, float i_CargoVolume)
        {
            m_LicensePlate = i_LicensePlate;
            m_Model = i_Model;
            intiateWheels(i_WheelsAirPressure, i_WheelManufacturer);
            m_FuelAmount= i_FuelAmount;
            mr_IsCarryingHazardousMaterial = i_IsCarryingHazardousMaterial;
            mr_CargoVolume= i_CargoVolume;
            m_MaxFuelCapacity = k_MaxFuelCapacity;
            m_FuelType = k_FuelType;
            m_RemainingEnergyPercentage = calculateEnergyPrecentage(m_FuelAmount);
        }

        private void intiateWheels(float[] i_WheelsAirPressure, string[] i_WheelManufacturer)
        {
            if (i_WheelsAirPressure.Length != k_NumberOfWheels || i_WheelManufacturer.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("Not The Correct Amount Of Wheels");
            }
            else
            {
                m_Wheels = new Wheel[k_NumberOfWheels];

                for (int i = 0; i < k_NumberOfWheels; i++)
                {
                    m_Wheels[i] = new Wheel(i_WheelManufacturer[i], i_WheelsAirPressure[i], k_WheelMaxAirPressure);
                }
            }
        }

        private float calculateEnergyPrecentage(float i_FuelAmount)
        {
            return i_FuelAmount / m_MaxFuelCapacity;
        }
    }
}
