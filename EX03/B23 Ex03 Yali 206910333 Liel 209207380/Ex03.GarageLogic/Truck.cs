namespace Ex03.GarageLogic
{
    public class Truck : PetrolVehicle
    {
        private readonly bool r_IsCarryingHazardousMaterial;
        private readonly float r_CargoVolume;

        public Truck(string i_LicensePlate, PetrolEngine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels)
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
    }
}
