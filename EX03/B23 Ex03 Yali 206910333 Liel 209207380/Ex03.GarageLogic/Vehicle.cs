namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicensePlate;
        protected float m_RemainingEnergyPercentage;
        protected Wheel[] m_Wheels;

        public string Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }

        public string LicensePlate
        {
            get { return m_LicensePlate; }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }
        }

        public override int GetHashCode()
        {
            return m_LicensePlate.GetHashCode();
        }

        public void SetWheelManufacturer(int i_WheelIndex, string i_Manufacturer)
        {
            m_Wheels[i_WheelIndex].Manufacturer = i_Manufacturer;
        }

        public void InflateWheel(int i_WheelIndex, float i_NewAirPressureAmount)
        {
            m_Wheels[i_WheelIndex].Inflate(i_NewAirPressureAmount);
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public class Wheel
        {
            private string m_Manufacturer;
            private float m_AirPressure;
            private readonly float m_MaxAirPressure;

            public Wheel(float maxAirPressure)
            {
                m_MaxAirPressure = maxAirPressure;
            }

            public string Manufacturer
            {
                get { return m_Manufacturer; }
                set { m_Manufacturer = value; }
            }

            public float MaxAirPressure
            {
                get { return m_MaxAirPressure; }
            }

            public void Inflate(float i_NewAirPressureAmount)
            {
                if(isValidAirPressureAmount(i_NewAirPressureAmount))
                {
                    m_AirPressure = i_NewAirPressureAmount;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxAirPressure);
                }
            }

            public void InflateToMax()
            {
                Inflate(m_MaxAirPressure);
            } 

            private bool isValidAirPressureAmount(float i_AirPressureAmount)
            {
                return i_AirPressureAmount >= 0 && i_AirPressureAmount <= m_MaxAirPressure;
            }
        }
    }
}
