namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxBatteryCapacity, float i_RemainingBatteryHours)
        {
            //m_Type = eFuelType.Electricity;
        }

        public float MaxBatteryCapacity { get { return 0f; } }

        public float RemainingBatteryHours { 
            get { }
            internal set { }
        }

        public void Charge(float i_AmountToAdd)
        {
            //FillEnergy(m_Type, i_AmountToAdd);
        }

        //protected override void FillEnergy(eFuelType i_Type, float i_AmountToAdd)
        //{

        //}
    }
}
