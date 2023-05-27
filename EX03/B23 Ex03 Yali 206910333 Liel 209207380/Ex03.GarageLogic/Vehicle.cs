

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicensePlate;
        protected float m_RemainingEnergyPercentage;
        protected Wheel[] m_Wheels;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void InflateWheelsToMax()
        {

        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
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
