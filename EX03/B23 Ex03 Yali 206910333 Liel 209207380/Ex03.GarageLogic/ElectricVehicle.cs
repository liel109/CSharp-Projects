
namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        protected ElectricEngine m_Engine;

        public void Charge(float i_MinutesOfBatteryToAdd)
        {
            if (i_MinutesOfBatteryToAdd < 0 || (m_BatteryRemainingHours + (i_MinutesOfBatteryToAdd / 60)) > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxCapacity - m_BatteryRemainingHours);
            }
            else
            {
                m_BatteryRemainingHours += (i_MinutesOfBatteryToAdd / 60);
                m_RemainingEnergyPercentage = (m_BatteryRemainingHours / m_MaxCapacity) * 100;
            }
        }

        public float BatteryRemainingHours
        {
            get 
            { 
                return m_BatteryRemainingHours;
            }
        }

        public float MaxCapacity
        {
            get
            {
                return m_MaxCapacity;
            }
        }

    }
}
