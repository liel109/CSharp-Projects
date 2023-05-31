using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {

        public ElectricEngine(float i_MaxBatteryCapacity) : base(i_MaxBatteryCapacity)
        {
        }

        public ElectricEngine(float i_MaxBatteryCapacity, float i_RemainingBatteryHours) : base(i_MaxBatteryCapacity, i_RemainingBatteryHours)
        {
        }

        public float MaxBatteryCapacity
        {
            get {
                return m_MaxCapacity;
            }
        }

        public float RemainingBatteryHours
        {
            get 
            {
                return m_EnergyAmount; 
            }
            set
            {
                if (isValidAmountToCharge(value))
                {
                    m_EnergyAmount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxCapacity);
                }
            }
        }

        private bool isValidAmountToCharge(float i_RemainingHours)
        {
            return i_RemainingHours >= 0 && i_RemainingHours <= m_MaxCapacity;
        }

        public override void SetProperties(Dictionary<string, string> i_properties)
        {
            string userInputRemainingHoursString = i_properties["Remaining Battery Hours"];
            float userInputRemainingHoursFloat;

            if (!float.TryParse(userInputRemainingHoursString, out userInputRemainingHoursFloat))
            {
                throw new FormatException();
            }
            else if (!isValidAmountToCharge(userInputRemainingHoursFloat))
            {
                throw new ValueOutOfRangeException(0,m_MaxCapacity);
            }

            m_EnergyAmount = userInputRemainingHoursFloat;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(@"Max Battery Capacity: {0}
Remaining Battery Hours: {1}", m_MaxCapacity, m_EnergyAmount));

            return stringBuilder.ToString();
        }
    }
}
