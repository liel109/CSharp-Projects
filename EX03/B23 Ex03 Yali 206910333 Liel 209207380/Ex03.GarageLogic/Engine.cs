using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly float m_MaxCapacity;
        protected float m_EnergyAmount;

        public Engine(float i_MaxCapacity) : this(i_MaxCapacity, 0)
        {

        }

        public Engine(float i_MaxCapacity, float i_EnergyAmount)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_EnergyAmount = i_EnergyAmount;
        }

        
        public abstract void SetProperties(Dictionary<string, string> i_properties);

    }
}
