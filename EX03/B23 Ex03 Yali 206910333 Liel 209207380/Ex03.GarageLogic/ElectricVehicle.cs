namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        protected ElectricEngine m_Engine;

        public ElectricVehicle(string i_LicensePlate, ElectricEngine i_Engine, Wheel[] i_Wheels)
        {
            m_LicensePlate = i_LicensePlate;
            m_Engine = i_Engine;
            m_Wheels = i_Wheels;
        }

        public void Charge(float i_MinutesOfBatteryToAdd)
        {
            m_Engine.Charge(i_MinutesOfBatteryToAdd);
        }

        public float BatteryRemainingHours
        {
            get 
            { 
                return m_Engine.RemainingBatteryHours;
            }
        }

        public float MaxCapacity
        {
            get
            {
                return m_Engine.MaxBatteryCapacity;
            }
        }
    }
}
