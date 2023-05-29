

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
            return m_LicensePlate.GetHashCode();
        }

        public void InflateWheelsToMax()
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }
        }

        public float RemainingEnergy
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }
        }

        protected void SetWheels(int i_NumOfWheels, string i_WheelManufacturer, float[] i_AirPressures, float i_MaxWheelAirPressure)
        {
            m_Wheels = new Wheel[i_NumOfWheels];

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels[i] = new Wheel(i_WheelManufacturer, i_AirPressures[i], i_MaxWheelAirPressure);
            }
        }

        public class Wheel
        {
            private readonly string m_Manufacturer;
            private float m_AirPressure;
            private readonly float m_MaxAirPressure;

            public Wheel(string manufacturer, float airPressure, float maxAirPressure)
            {
                m_Manufacturer = manufacturer;
                m_AirPressure = airPressure;
                m_MaxAirPressure = maxAirPressure;
            }

            public void Inflate(float i_AirPressureToAdd)
            {
                if(i_AirPressureToAdd < 0 || (m_AirPressure + i_AirPressureToAdd > m_MaxAirPressure))
                {
                    throw new ValueOutOfRangeException(0, m_MaxAirPressure);
                }
                else
                {
                    m_AirPressure += i_AirPressureToAdd;
                }
            }

            public void InflateToMax()
            {
                Inflate(m_AirPressure - m_AirPressure);
            } 
        }
    }
}
