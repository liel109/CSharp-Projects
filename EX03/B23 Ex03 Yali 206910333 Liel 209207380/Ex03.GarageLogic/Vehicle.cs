using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly Dictionary<string, string[]> r_VehiclePropertiesDictionary;
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
            r_VehiclePropertiesDictionary = new Dictionary<string, string[]>()
            {
                { "Model", null },
                { "Tires Manufacturer", null },
                { "Tires Air Pressure", new string[1] { m_Tires[0].GetPressureInterval() } }
            };
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

        internal float RemainingEnergyPercentage
        {
            get { return m_RemainingEnergyPercentage; }
            set { m_RemainingEnergyPercentage = value; }
        }

        public Engine Engine
        {
            get { return m_Engine; }
        }

        public override int GetHashCode()
        {
            return m_LicensePlate.GetHashCode();
        }

        public void InflateTiresToMax()
        {
            foreach (Tire wheel in m_Tires)
            {
                wheel.InflateToMax();
            }
        }

        public virtual void SetProperties(Dictionary<string, string> i_Properties)
        {
            string userInputModelTypeString = i_Properties["Model"];
            string userInputTiresManufacturerString = i_Properties["Tires Manufacturer"];
            string userInputTiresAirPressureString = i_Properties["Tires Air Pressure"];
            float userInputTiresAirPressureFloat;

            Validator.ValidatePositiveFloat(userInputTiresAirPressureString, out userInputTiresAirPressureFloat);
            m_Model = userInputModelTypeString;
            setTiresInfo(userInputTiresManufacturerString, userInputTiresAirPressureFloat);
        }

        public abstract Dictionary<string, string[]> GetProperties();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format(@"License Plate Number: {0}
Model: {1}
Remaining Energy Precentage: {2}", m_LicensePlate, m_Model, m_RemainingEnergyPercentage));
            stringBuilder.Append(m_Tires[0].ToString());

            return stringBuilder.ToString();
        }

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

        public class Tire
        {
            private readonly float r_MaxAirPressure;
            private string m_Manufacturer;
            private float m_AirPressure;

            public Tire(float maxAirPressure)
            {
                r_MaxAirPressure = maxAirPressure;
            }

            public string Manufacturer
            {
                get { return m_Manufacturer; }
                set { m_Manufacturer = value; }
            }

            public float MaxAirPressure
            {
                get { return r_MaxAirPressure; }
            }

            public string GetPressureInterval()
            {
                return string.Format("0 - {0}", r_MaxAirPressure);
            }

            public void Inflate(float i_NewAirPressureAmount)
            {
                if (isValidAirPressureAmount(i_NewAirPressureAmount))
                {
                    m_AirPressure = i_NewAirPressureAmount;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxAirPressure);
                }
            }

            public void InflateToMax()
            {
                Inflate(r_MaxAirPressure);
            } 

            private bool isValidAirPressureAmount(float i_AirPressureAmount)
            {
                return i_AirPressureAmount >= 0 && i_AirPressureAmount <= r_MaxAirPressure;
            }

            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine(string.Format(@"Tire Manufacturer: {0}
Tire Air Pressure: {1}
Tire Max Air Pressure: {2}", m_Manufacturer, m_AirPressure, r_MaxAirPressure));

                return stringBuilder.ToString();
            }
        }
    }
}
