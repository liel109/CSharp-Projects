

using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, EntryForm> m_Jobs;

        public Garage()
        {
            m_Jobs = new Dictionary<string, EntryForm>();
        }

        public void AddJob(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {

        }

        public List<string> GetJobs(eVehicleStatus i_FilterByStatus)
        {
            return null;
        }

        public List<string> GetJobs()
        {
            return null;
        }

        public void InflateWheelsToMaximum(string i_LicensePlate)
        {

        }

        public void Fuel(string i_LicensePlate, eFuelType i_FuelType, float i_AmountToAdd)
        {

        }

        public void Charge(string i_LicensePlate, float i_NumberOfMinutesToAdd)
        {

        }

        public EntryForm GetJob(string i_LicensePlate)
        {
            return null;
        }

        public bool Contains(string i_LiscensePlate)
        {
            return false;
        }

        public void RemoveJob(string i_LiscensePlate) 
        {

        }
    }
}
