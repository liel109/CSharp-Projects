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
            get { return m_EnergyAmount; }
        }

        internal void Charge(float i_MinutesToAdd)
        {
            float hoursToAdd = i_MinutesToAdd / 60;

            if (isValidAmountToCharge(hoursToAdd))
            {
                m_EnergyAmount += hoursToAdd;
            }
            else
            {
                float maxMinutesToAdd = (m_MaxCapacity - m_EnergyAmount) * 60;

                throw new ValueOutOfRangeException(0, maxMinutesToAdd);
            }

            //FillEnergy(m_Type, i_AmountToAdd);
        }

        private bool isValidAmountToCharge(float i_HoursToAdd)
        {
            float expectedAmount = m_EnergyAmount + i_HoursToAdd;

            return expectedAmount >= 0 && expectedAmount <= m_MaxCapacity;
        }

        //protected override void FillEnergy(eFuelType i_Type, float i_AmountToAdd)
        //{

        //}
    }
}
