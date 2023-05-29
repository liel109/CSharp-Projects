namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    { 
        private eDoorsNumber m_DoorsNumber;
        private eColor m_Color;

        public ElectricCar(string i_LicensePlate, ElectricEngine i_Engine, Wheel[] i_Wheels) : base(i_LicensePlate, i_Engine, i_Wheels)
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
