using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        protected eDoorsNumber m_DoorsNumber;
        protected eColor m_Color;

        public Car(string i_LicensePlate, Engine i_Engine, Tire[] i_Tires) : base(i_LicensePlate, i_Engine, i_Tires)
        { 
        }

        public eDoorsNumber DoorsNumber
        {
            get { return m_DoorsNumber; }
            set { m_DoorsNumber = value; }
        }

        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            return null;
        }

        public enum eColor
        {
            Red = 1,
            Yellow = 2,
            White = 3,
            Black = 4
        }

        public enum eDoorsNumber
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
    }
}
