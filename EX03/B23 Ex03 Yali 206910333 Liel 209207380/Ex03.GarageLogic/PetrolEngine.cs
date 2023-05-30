using System;

namespace Ex03.GarageLogic
{
    public class PetrolEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public PetrolEngine(eFuelType i_FuelType, float i_FuelCapacity) : this(i_FuelType, i_FuelCapacity, 0)
        {

        }

        public PetrolEngine(eFuelType i_FuelType, float i_FuelCapacity, float i_FuelAmount) : base(i_FuelCapacity, i_FuelAmount)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public float FuelCapacity
        {
            get { return m_MaxCapacity; }
        }

        public float FuelAmount
        {
            get
            {
                return m_EnergyAmount;
            }
            set
            {
                if (isValidFuelAmount(value))
                {
                    m_EnergyAmount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxCapacity);
                }
            }
        }

        private bool isValidFuelAmount(float i_FuelAmount)
        {
            return i_FuelAmount >= m_MaxCapacity;
        }
    }
}
