using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicensePlate;
        protected float m_RemainingEnergyPercentage;
        protected Engine m_Engine;
        protected Tire[] m_Tires;

        public Vehicle(string i_LicensePlate, Engine i_Engine, Tire[] i_Tires)
        {
            m_LicensePlate = i_LicensePlate;
            m_Engine = i_Engine;
            m_Tires = i_Tires;
        }

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

        public Engine Engine
        {
            get { return m_Engine; }
        }

        public override int GetHashCode()
        {
            return m_LicensePlate.GetHashCode();
        }

        public void SetWheelManufacturer(int i_WheelIndex, string i_Manufacturer)
        {
            m_Tires[i_WheelIndex].Manufacturer = i_Manufacturer;
        }

        public void InflateWheel(int i_WheelIndex, float i_NewAirPressureAmount)
        {
            m_Tires[i_WheelIndex].Inflate(i_NewAirPressureAmount);
        }

        public void InflateWheelsToMax()
        {
            foreach (Tire wheel in m_Tires)
            {
                wheel.InflateToMax();
            }
        }

        public abstract Dictionary<string, string[]> GetProperties();

        public abstract void SetProperties(Dictionary<string, string> i_Properties);

        public class Tire
        {
            private string m_Manufacturer;
            private float m_AirPressure;
            private readonly float m_MaxAirPressure;

            public Tire(float maxAirPressure)
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
