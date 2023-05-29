namespace Ex03.GarageLogic
{
    public class PetrolMotorcycle : PetrolVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public PetrolMotorcycle(string i_LicensePlate, PetrolEngine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels) 
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
