using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const float k_MaxTireAirPressure = 31f;
        private const int k_NumberOfTires = 2;

        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_LicensePlate, Engine i_Engine, Tire[] i_Tires) : base(i_LicensePlate, i_Engine, i_Tires)
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            return null;
        }

        public enum eLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }
    }
}
