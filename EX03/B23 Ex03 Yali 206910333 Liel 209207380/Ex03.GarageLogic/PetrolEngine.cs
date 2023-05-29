namespace Ex03.GarageLogic
{
    public class PetrolEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public PetrolEngine(eFuelType i_FuelType, float i_FuelCapacity, float i_FuelAmount)
        {
        }

        public eFuelType FuelType { get { return 0; } }

        public float FuelCapacity { get { return 0; } }

        public float FuelAmount
        {
            get { return 0; }
            internal set { }
        }
    }
}
