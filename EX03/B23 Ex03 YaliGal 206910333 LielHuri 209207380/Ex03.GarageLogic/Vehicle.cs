

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicensePlate;
        private float m_RemainingEnergyPercentage;
        private Wheel[] m_Wheels;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void InflateWheelsToMax()
        {

        }

        public class Wheel
        {
            private string m_Manufacturer;
            private float m_AirPressure;
            private float m_MaxAirPressure;

            public void Inflate(float i_AirPressureToAdd)
            {

            }
        }
    }
}
