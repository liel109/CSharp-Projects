using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const bool v_PetrolEngine = true;
        private static readonly Dictionary<string, string[]> sr_CarPropertiesDictionary = new Dictionary<string, string[]>()
        {
            { "Color", Enum.GetNames(typeof(eColor)) },
            { "Doors Number", new string[1] { "2-5" } }
        };

        private eDoorsNumber m_DoorsNumber;
        private eColor m_Color;

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
            return DictionaryUtilities.createFullDictionary(r_VehiclePropertiesDictionary, sr_CarPropertiesDictionary, m_Engine.GetProperties());
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string userInputColorString = i_Properties["Color"];
            string userInputDoorsString = i_Properties["Doors Number"];
            eColor color = Validator.ValidateEnum<eColor>(userInputColorString);
            eDoorsNumber numberOfDoors = Validator.ValidateEnum<eDoorsNumber>(userInputDoorsString);

            m_Engine.SetProperties(i_Properties);
            base.SetProperties(i_Properties);
            m_RemainingEnergyPercentage = calculateEnergyPrecentage(i_Properties);
            m_Color = color;
            m_DoorsNumber = numberOfDoors;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (m_Engine is PetrolEngine)
            {
                stringBuilder.AppendLine(string.Format("Vehicle Type: Petrol Car"));
            }
            else
            {
                stringBuilder.AppendLine(string.Format("Vehicle Type: Electric Car"));
            }

            stringBuilder.Append(base.ToString());
            stringBuilder.Append(m_Engine.ToString());
            stringBuilder.AppendLine(string.Format(@"Vehicle Color: {0}
Vehicle number of doors: {1}", m_Color.ToString(), m_DoorsNumber.ToString()));

            return stringBuilder.ToString();
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
