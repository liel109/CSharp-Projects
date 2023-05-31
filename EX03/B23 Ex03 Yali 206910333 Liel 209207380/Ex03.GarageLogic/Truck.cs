using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const float k_MaxTireAirPressure = 31f;
        private const int k_NumberOfTires = 2;

        private bool r_IsCarryingHazardousMaterial;
        private float r_CargoVolume;

        public Truck(string i_LicensePlate, PetrolEngine i_Engine, Tire[] i_Tires) : base(i_LicensePlate, i_Engine, i_Tires)
        {
        }

        public bool IsCarryingHazadousMaterial
        {
            get { return r_IsCarryingHazardousMaterial; }
        }

        public float CargoVolume
        {
            get { return r_CargoVolume; }
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            throw new System.NotImplementedException();
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            return null;
        }
    }
}
