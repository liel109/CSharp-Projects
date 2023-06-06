﻿using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const bool v_PetrolEngine = true;
        private static readonly Dictionary<string, string[]> sr_MotorcyclePropertiesDictionary = new Dictionary<string, string[]>()
        {
            {"License Type", Enum.GetNames(typeof(eLicenseType))},
            {"Engine Volume", null}
        };

        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_LicensePlate, Engine i_Engine, Tire[] i_Tires) : base(i_LicensePlate, i_Engine, i_Tires)
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
        }

        public override Dictionary<string, string[]> GetProperties()
        {
            Dictionary<string, string[]> fullDictionary;

            if (m_Engine is PetrolEngine)
            {
                fullDictionary = DictionaryUtilities.createFullDictionary(sr_VehiclePropertiesDictionary, sr_MotorcyclePropertiesDictionary, v_PetrolEngine);
            }
            else
            {
                fullDictionary = DictionaryUtilities.createFullDictionary(sr_VehiclePropertiesDictionary, sr_MotorcyclePropertiesDictionary, !v_PetrolEngine);
            }

            return fullDictionary;
        }

        //public override void SetProperties(Dictionary<string, string> i_Properties)
        //{
        //    string userInputLicenseTypeString = i_Properties["License Type"];
        //    string userInputEngineVolumeString = i_Properties["Engine Volume"];
        //    int userInputLicenseTypeInt;
        //    int userInputEngineVolumeInt;

        //    base.SetProperties(i_Properties);
        //    m_Engine.SetProperties(i_Properties);
        //    m_RemainingEnergyPercentage = calculateEnergyPrecentage(i_Properties);

        //    if (!isValidEnumInput(typeof(eLicenseType), userInputLicenseTypeString, out userInputLicenseTypeInt))
        //    {
        //        if (!int.TryParse(userInputLicenseTypeString, out _))
        //        {
        //            throw new FormatException();
        //        }
        //        else
        //        {
        //            throw new ArgumentException();
        //        }
        //    }
        //    else if (!int.TryParse(userInputEngineVolumeString, out userInputEngineVolumeInt))
        //    {
        //        throw new FormatException("Engine Volume Problem");
        //    }
        //    else if (userInputEngineVolumeInt < 0)
        //    {
        //        throw new ArgumentException("Engine Volume Is Smaller Than 0");
        //    }

        //    m_LicenseType = (eLicenseType)userInputLicenseTypeInt;
        //    m_EngineVolume = userInputEngineVolumeInt;
        //}

        public override void SetProperties(Dictionary<string, string> i_Properties)
        {
            string userInputLicenseTypeString = i_Properties["License Type"];
            string userInputEngineVolumeString = i_Properties["Engine Volume"];
            int userInputEngineVolumeInt;
            eLicenseType licenseType;

            Validator.ValidatePositiveInt(userInputEngineVolumeString, out userInputEngineVolumeInt);
            licenseType = Validator.ValidateEnum<eLicenseType>(userInputLicenseTypeString);
            base.SetProperties(i_Properties);
            m_Engine.SetProperties(i_Properties);
            m_RemainingEnergyPercentage = calculateEnergyPrecentage(i_Properties);
            m_LicenseType = licenseType;
            m_EngineVolume = userInputEngineVolumeInt;
        }

        public enum eLicenseType
        {
            A1 = 1,
            A2 = 2,
            AA = 3,
            B1 = 4
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (m_Engine is PetrolEngine)
            {
                stringBuilder.AppendLine(string.Format("Vehicle Type: Petrol Motorcycle"));
            }
            else
            {
                stringBuilder.AppendLine(string.Format("Vehicle Type: Electric Motorcycle"));
            }
            stringBuilder.Append(base.ToString());
            stringBuilder.Append(m_Engine.ToString());
            stringBuilder.Append(string.Format(@"License Type: {0}
Engine Volume: {1}",m_LicenseType.ToString(), m_EngineVolume));

            return stringBuilder.ToString();
        }
    }
}
