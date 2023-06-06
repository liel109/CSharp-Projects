using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly float r_MaxCapacity;
        protected float m_EnergyAmount;

        public Engine(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
            m_EnergyAmount = 0;
        }

        public abstract void SetProperties(Dictionary<string, string> i_properties);
    }
}
