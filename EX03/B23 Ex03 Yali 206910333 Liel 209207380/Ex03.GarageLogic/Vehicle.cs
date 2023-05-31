using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected static readonly Dictionary<string, string[]> sr_VehiclePropertiesDictionary = new Dictionary<string, string[]>()
        {
            {"Model",null},
            {"Tires Manufacturer",null},
            {"Tires Air Pressure",null}
        };

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
            get { 
                return m_Model;
            }
            set {
                m_Model = value;
            }
        }

        public string LicensePlate
        {
            get {
                return m_LicensePlate;
            }
        }

        internal float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }
            set
            {
                m_RemainingEnergyPercentage = value;
            }
        }

        public Engine Engine
        {
            get {
                return m_Engine;
            }
        }

        public override int GetHashCode()
        {
            return m_LicensePlate.GetHashCode();
        }

        private void setTiresInfo(string i_Manufacturer, float i_AirPressure)
        {
            for (int i = 0; i < m_Tires.Length; i++)
            {
                setTireManufacturer(i, i_Manufacturer);
                inflateTire(i, i_AirPressure);
            }
        }

        private void setTireManufacturer(int i_WheelIndex, string i_Manufacturer)
        {
            m_Tires[i_WheelIndex].Manufacturer = i_Manufacturer;
        }

        private void inflateTire(int i_WheelIndex, float i_NewAirPressureAmount)
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

        public virtual void SetProperties(Dictionary<string, string> i_properties)
        {
            string userInputModelTypeString = i_properties["Model"];
            string userInputTiresManufacturerString = i_properties["Tires Manufacturer"];
            string userInputTiresAirPressureString = i_properties["Tires Air Pressure"];
            float userInputTiresAirPressureFloat;

            if (!float.TryParse(userInputTiresAirPressureString, out userInputTiresAirPressureFloat))
            {
                throw new FormatException();
            }
            else if (userInputTiresAirPressureFloat < 0)
            {
                throw new ArgumentException();
            }
            m_Model = userInputModelTypeString;
            setTiresInfo(userInputTiresManufacturerString, userInputTiresAirPressureFloat);
        }

        public abstract Dictionary<string, string[]> GetProperties();

        protected float calculateEnergyPrecentage(Dictionary<string, string> i_properties)
        {
            float energyPrecentage = 0;
            if (m_Engine is PetrolEngine petrolEngine)
            {
                energyPrecentage = float.Parse(i_properties["Fuel Amount"]) / petrolEngine.FuelCapacity;
            }
            else if (m_Engine is ElectricEngine electricEngine)
            {
                energyPrecentage = float.Parse(i_properties["Remaining Battery Hours"]) / electricEngine.MaxBatteryCapacity;
            }

            return energyPrecentage;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(@"License Plate Number: {0}
Model: {1}
Remaining Energy Precentage: {2}",m_LicensePlate, m_Model, m_RemainingEnergyPercentage));
            stringBuilder.Append(m_Tires[0].ToString());

            return stringBuilder.ToString();
        }

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

            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(string.Format(@"Tire Manufacturer: {0}
Tire Air Pressure: {1}
Tire Max Air Pressure: {2}", m_Manufacturer, m_AirPressure, m_MaxAirPressure));

                return stringBuilder.ToString();
            }
        }
    }
}
