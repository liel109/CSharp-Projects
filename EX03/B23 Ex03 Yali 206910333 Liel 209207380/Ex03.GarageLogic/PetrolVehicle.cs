namespace Ex03.GarageLogic
{
    public abstract class PetrolVehicle : Vehicle
    {
        protected PetrolEngine m_Engine;

        public PetrolVehicle(string i_LicensePlate, PetrolEngine i_Engine, Wheel[] i_Wheels)
        {
            m_LicensePlate = i_LicensePlate;
            m_Engine = i_Engine;
            m_Wheels = i_Wheels;
        }

        public void Fuel(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            m_Engine.Fuel(i_FuelAmountToAdd, i_FuelType);
        }

        public eFuelType FuelType
        {
            get
            {
                return m_Engine.FuelType;
            }
        }

        public float FuelAmount
        {
            get
            {
                return m_Engine.FuelAmount;
            }
        }

        public float MaxFuelCapacity
        {
            get
            {
                return m_Engine.FuelCapacity;
            }
        }
    }
}
