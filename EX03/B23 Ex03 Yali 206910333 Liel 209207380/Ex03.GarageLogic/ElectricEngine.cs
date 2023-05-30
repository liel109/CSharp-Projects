namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxBatteryCapacity) : base(i_MaxBatteryCapacity)
        {
        }

        public ElectricEngine(float i_MaxBatteryCapacity, float i_RemainingBatteryHours) : base(i_MaxBatteryCapacity, i_RemainingBatteryHours)
        {
        }

        public float MaxBatteryCapacity
        {
            get { return m_MaxCapacity; }
        }

        public float RemainingBatteryHours
        {
            get 
            {
                return m_EnergyAmount; 
            }
            set
            {
                if (isValidAmountToCharge(value))
                {
                    m_EnergyAmount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxCapacity);
                }
            }
        }

        private bool isValidAmountToCharge(float i_RemainingHours)
        {
            return i_RemainingHours >= 0 && i_RemainingHours <= m_MaxCapacity;
        }

        //protected override void FillEnergy(eFuelType i_Type, float i_AmountToAdd)
        //{

        //}
    }
}
