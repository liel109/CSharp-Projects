namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        //protected eFuelType m_Type;
        protected float m_EnergyAmount;
        protected float m_MaxCapacity;

        public float GetEnergyPercentage()
        {
            return 0f;
        }

        //protected abstract void FillEnergy(eFuelType i_Type, float i_AmountToAdd);

    }
}
