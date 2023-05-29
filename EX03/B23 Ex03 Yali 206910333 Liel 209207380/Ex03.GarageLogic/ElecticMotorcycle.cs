namespace Ex03.GarageLogic
{
    public class ElecticMotorcycle : ElectricVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public ElecticMotorcycle(string i_LicensePlate, ElectricEngine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels)
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
    }
}
