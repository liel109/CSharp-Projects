using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.VehicleFactory;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private static readonly Dictionary<string, string[]> sr_TruckPropertiesDictionary = new Dictionary<string, string[]>()
        {
            { "Is Carrying Hazardous Material", new string[]{ "Yes", "No" } },
            { "Cargo Volume", null }
        };


        private const float k_MaxTireAirPressure = 31f;
        private const int k_NumberOfTires = 2;

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
                fullDictionary = DictionaryUtilities.createFullDictionary(sr_VehiclePropertiesDictionary, sr_TruckPropertiesDictionary, true);
            }
            else
            {
                fullDictionary = DictionaryUtilities.createFullDictionary(sr_VehiclePropertiesDictionary, sr_TruckPropertiesDictionary, false);
            }

            return fullDictionary;
        }

        public override void SetProperties(Dictionary<string, string> i_properties)
        {
            string userInputMatrialTypeString = i_properties["Is Carrying Hazardous Material"];
            string userInputCargoVolumeString = i_properties["Cargo Volume"];
            bool userInputMatrialTypeBool;
            float userInputCargoVolumeFloat;

            m_Engine.SetProperties(i_properties);
            base.SetProperties(i_properties);
            m_RemainingEnergyPercentage = calculateEnergyPrecentage(i_properties);

            if (!bool.TryParse(userInputMatrialTypeString, out userInputMatrialTypeBool))
            {
                throw new FormatException();
            }
            else if(!float.TryParse(userInputCargoVolumeString, out userInputCargoVolumeFloat))
            {
                throw new FormatException();
            }
            else if(userInputCargoVolumeFloat < 0)
            {
                throw new ArgumentException();
            }

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
