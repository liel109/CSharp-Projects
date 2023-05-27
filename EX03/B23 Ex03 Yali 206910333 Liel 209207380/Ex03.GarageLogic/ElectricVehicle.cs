
namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        protected float m_BatteryRemainingHours;
        protected float m_MaxCapacity;

        public void Charge(float i_MinutesOfBatteryToAdd)
        {
            if(i_MinutesOfBatteryToAdd< 0 || (m_BatteryRemainingHours + (i_MinutesOfBatteryToAdd * 60)) > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxCapacity);
            }
            else
            {
                m_BatteryRemainingHours += (i_MinutesOfBatteryToAdd * 60);
            }
        }

    }
}
