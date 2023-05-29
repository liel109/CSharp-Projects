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
            get { return m_EnergyAmount; }
        }

        internal void Fuel(float i_AmountToAdd, eFuelType i_FuelTypeToAdd)
        {
            if(isValidFuelAmount(i_AmountToAdd) && isValidFuelType(i_FuelTypeToAdd))
            {
                m_EnergyAmount += i_AmountToAdd;
            }

            else
            {
                float maxAmountToAdd = m_MaxCapacity - m_EnergyAmount;

                throw new ValueOutOfRangeException(0, maxAmountToAdd);
            }
        }

        private bool isValidFuelAmount(float i_AmountToAdd)
        {
            float expectedAmount = i_AmountToAdd + m_EnergyAmount;

            return expectedAmount >= 0 && expectedAmount <= m_MaxCapacity;
        }

        private bool isValidFuelType(eFuelType i_FuelTypeToAdd)
        {
            return i_FuelTypeToAdd == r_FuelType;
        }
    }
}
