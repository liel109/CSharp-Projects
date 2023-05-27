using System;

namespace Ex03.GarageLogic
{
    public abstract class PetrolVehicle : Vehicle
    {
        private eFuelType m_FuelType;
        private float m_FuelAmount;
        private float m_MaxFuelCapacity;

        public void Fuel(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            if(i_FuelType != m_FuelType)
            {
                throw new ArgumentException();
            }
            else if(m_FuelAmount < 0 || (m_FuelAmount + i_FuelAmountToAdd) > m_MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxFuelCapacity);
            }
            else
            {
                m_FuelAmount += i_FuelAmountToAdd;
            }
        }
    }
}
