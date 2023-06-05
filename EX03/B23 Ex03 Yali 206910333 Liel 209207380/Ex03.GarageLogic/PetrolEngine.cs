using System;
using static Ex03.GarageLogic.Motorcycle;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class PetrolEngine : Engine
    {

        private readonly eFuelType r_FuelType;

        public PetrolEngine(eFuelType i_FuelType, float i_FuelCapacity) : base(i_FuelCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public float FuelCapacity
        {
            get { return r_MaxCapacity; }
        }

        public float FuelAmount
        {
            get { return m_EnergyAmount; }
            set
            {
                if (isValidFuelAmount(value))
                {
                    m_EnergyAmount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxCapacity);
                }
            }
        }

        private bool isValidFuelAmount(float i_FuelAmount)
        {
            return i_FuelAmount >= 0 && i_FuelAmount <= r_MaxCapacity;
        }

        public override void SetProperties(Dictionary<string, string> i_properties)
        {
            string userInputFuelAmountString = i_properties["Fuel Amount"];
            float userInputFuelAmountFloat;
          
            if (!float.TryParse(userInputFuelAmountString, out userInputFuelAmountFloat))
            {
                throw new FormatException();
            }
            else if (!isValidFuelAmount(userInputFuelAmountFloat))
            {
                throw new ValueOutOfRangeException(0, r_MaxCapacity);
            }

            m_EnergyAmount = userInputFuelAmountFloat;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(@"Max Fuel Capacity: {0}
Current Fuel Amount: {1}", r_MaxCapacity, m_EnergyAmount));

            return stringBuilder.ToString();
        }

        public enum eFuelType
        {
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3,
            Soler = 4
        }
    }
}
