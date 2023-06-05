namespace Ex03.GarageLogic
{
    public class EntryForm
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private readonly Vehicle r_Vehicle;
        private Garage.eVehicleStatus m_VehicleStatus;

        public EntryForm(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            r_OwnerName= i_OwnerName;
            r_OwnerPhoneNumber= i_OwnerPhoneNumber;
            r_Vehicle = i_Vehicle;
            m_VehicleStatus = Garage.eVehicleStatus.InProgress;
        }

        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return r_OwnerPhoneNumber; }
        }

        public Garage.eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }
    }
}
