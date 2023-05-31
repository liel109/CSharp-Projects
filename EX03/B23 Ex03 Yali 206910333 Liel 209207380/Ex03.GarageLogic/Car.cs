using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Motorcycle;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private static readonly Dictionary<string, string[]> sr_CarPropertiesDictionary = new Dictionary<string, string[]>()
        {
            {"Color", Enum.GetNames(typeof(eColor))},
            {"Doors Number", Enum.GetNames(typeof(eDoorsNumber))}
        };

        protected eDoorsNumber m_DoorsNumber;
        protected eColor m_Color;

        public Car(string i_LicensePlate, Engine i_Engine, Tire[] i_Tires) : base(i_LicensePlate, i_Engine, i_Tires)
        {
        }

        public eDoorsNumber DoorsNumber
        {
            get { 
                return m_DoorsNumber;
            }
            set {
                m_DoorsNumber = value;
            }
        }

        public eColor Color
        {
            get {
                return m_Color;
            }
            set {
                m_Color = value;
            }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string, string[]> fullDictionary;

            if (m_Engine is PetrolEngine)
            {
                fullDictionary = DictionaryUtilities.createFullDictionary(sr_VehiclePropertiesDictionary, sr_CarPropertiesDictionary, true);
            }
            else
            {
                fullDictionary = DictionaryUtilities.createFullDictionary(sr_VehiclePropertiesDictionary, sr_CarPropertiesDictionary, false);
            }

            return fullDictionary;
        }

        public override void SetProperties(Dictionary<string, string> i_properties)
        {


            string userInputColorString = i_properties["Color"];
            string userInputDoorsString = i_properties["Doors Number"];
            int userInputColorInt;
            int userInputDoorsInt;

            m_Engine.SetProperties(i_properties);
            base.SetProperties(i_properties);
            m_RemainingEnergyPercentage = calculateEnergyPrecentage(i_properties);

            if (!isValidEnumInput(typeof(eColor), userInputColorString, out userInputColorInt))
            {
                if (!int.TryParse(userInputColorString, out _))
                {
                    throw new FormatException();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else if (!isValidEnumInput(typeof(eDoorsNumber), userInputDoorsString, out userInputDoorsInt))
            {
                if (!int.TryParse(userInputDoorsString, out _))
                {
                    throw new FormatException();
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            m_Color = (eColor)userInputColorInt;
            m_DoorsNumber = (eDoorsNumber)userInputDoorsInt;
        }

        private static bool isValidEnumInput(Type i_EnumType, string i_UserInput, out int o_userInputInt)
        {

            return int.TryParse(i_UserInput, out o_userInputInt) && Enum.IsDefined(i_EnumType, o_userInputInt);
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
Vehicle number of doors: {1}",m_Color.ToString(), m_DoorsNumber.ToString()));

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
