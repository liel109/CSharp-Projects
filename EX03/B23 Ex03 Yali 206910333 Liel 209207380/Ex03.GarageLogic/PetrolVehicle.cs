using System;

namespace Ex03.GarageLogic
{
    public abstract class PetrolVehicle : Vehicle
    {
        protected PetrolEngine m_Engine;

        //public PetrolVehicle(string i_Model, string i_LicensePlate, Wheel[] i_Wheels, Engine i_Engine)
        //{
        //    m_FuelType = i_FuelType;
        //    m_FuelAmount = i_FuelAmount;
        //    m_MaxFuelCapacity = i_MaxFuelCapacity;
        //}

        public void Fuel(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            if(i_FuelType != m_FuelType)
            {
                throw new ArgumentException("Fuel Type Missmatch");
            }
            else if(m_FuelAmount < 0 || (m_FuelAmount + i_FuelAmountToAdd) > m_MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxFuelCapacity - m_FuelAmount);
            }
            else
            {
                m_FuelAmount += i_FuelAmountToAdd;
                m_RemainingEnergyPercentage = (m_FuelAmount / m_MaxFuelCapacity) * 100;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public float FuelAmount
        {
            get
            {
                return m_FuelAmount;
            }
        }

        public float MaxFuelCapacity
        {
            get
            {
                return m_MaxFuelCapacity;
            }
        }
    }
}
