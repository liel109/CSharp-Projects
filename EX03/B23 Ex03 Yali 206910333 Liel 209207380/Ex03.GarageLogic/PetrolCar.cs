namespace Ex03.GarageLogic
{
    public class PetrolCar : PetrolVehicle
    {
        protected eDoorsNumber m_DoorsNumber;
        protected eColor m_Color;

        public PetrolCar(string i_LicensePlate, PetrolEngine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels)
        {
        }

        public eDoorsNumber DoorsNumber
        {
            get { return m_DoorsNumber; }
        }

        public eColor Color
        {
            get { return m_Color; }
        }
    }
}
