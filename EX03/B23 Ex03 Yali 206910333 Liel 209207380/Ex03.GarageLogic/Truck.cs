using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const bool v_PetrolEngine = true;
        private static readonly Dictionary<string, string[]> sr_TruckPropertiesDictionary = new Dictionary<string, string[]>()
        {
            { "Is Carrying Hazardous Material", new string[2]{ "True" , "False" } },
            { "Cargo Volume", null }
        };

        private bool m_IsCarryingHazardousMaterial;
        private float m_CargoVolume;

        public Truck(string i_LicensePlate, PetrolEngine i_Engine, Tire[] i_Tires) : base(i_LicensePlate, i_Engine, i_Tires)
        {
        }

        public bool IsCarryingHazadousMaterial
        {
            get { return m_IsCarryingHazardousMaterial; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string, string[]> fullDictionary;

            if (m_Engine is PetrolEngine)
            {
                fullDictionary = DictionaryUtilities.createFullDictionary(sr_VehiclePropertiesDictionary, sr_TruckPropertiesDictionary, v_PetrolEngine);
            }
            else
            {
                fullDictionary = DictionaryUtilities.createFullDictionary(sr_VehiclePropertiesDictionary, sr_TruckPropertiesDictionary, !v_PetrolEngine);
            }

            return fullDictionary;
        }

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string userInputMatrialTypeString = i_Properties["Is Carrying Hazardous Material"];
            string userInputCargoVolumeString = i_Properties["Cargo Volume"];
            bool userInputMatrialTypeBool;
            float userInputCargoVolumeFloat;

            Validator.ValidateHazardousMaterialInput(userInputMatrialTypeString, out userInputMatrialTypeBool);
            Validator.ValidatePositiveFloat(userInputCargoVolumeString, out userInputCargoVolumeFloat);
            m_Engine.SetProperties(i_Properties);
            base.SetProperties(i_Properties);
            m_RemainingEnergyPercentage = calculateEnergyPrecentage(i_Properties);
            m_IsCarryingHazardousMaterial= userInputMatrialTypeBool;
            m_CargoVolume= userInputCargoVolumeFloat;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (m_Engine is PetrolEngine)
            {
                stringBuilder.AppendLine(string.Format("Vehicle Type: Petrol Truck"));
            }
            else
            {
                stringBuilder.AppendLine(string.Format("Vehicle Type: Electric Truck"));
            }
            stringBuilder.Append(base.ToString());
            stringBuilder.Append(m_Engine.ToString());
            stringBuilder.AppendLine(string.Format(@"Is Carrying Hazardous Material: {0}
Cargo Volume: {1}", m_IsCarryingHazardousMaterial, m_CargoVolume));

            return stringBuilder.ToString();
        }
    }
}
