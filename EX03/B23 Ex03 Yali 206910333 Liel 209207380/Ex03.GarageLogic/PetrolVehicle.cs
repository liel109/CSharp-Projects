using System;

namespace Ex03.GarageLogic
{
    public abstract class PetrolVehicle : Vehicle
    {
        protected eFuelType m_FuelType;
        protected float m_FuelAmount;
        protected float m_MaxFuelCapacity;

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
