
using System;
using System.Collections.Generic;
using System.Linq;

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
            EntryForm vehicleForm = new EntryForm(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle);
            string licensePlate = i_Vehicle.LicensePlate;
            m_Jobs[licensePlate] = vehicleForm;
        }

        public List<string> GetJobs(eVehicleStatus i_FilterByStatus)
        {
            return null;
        }

        public List<string> GetJobs()
        {
            return m_Jobs.Keys.ToList<string>();
        }

        public void InflateWheelsToMaximum(string i_LicensePlate)
        {
            m_Jobs[i_LicensePlate].Vehicle.InflateWheelsToMax();
        }

        public void Fuel(string i_LicensePlate, eFuelType i_FuelType, float i_AmountToAdd)
        {
            PetrolVehicle vehicle = m_Jobs[i_LicensePlate].Vehicle as PetrolVehicle;

            if(vehicle != null)
            {
                vehicle.Fuel(i_AmountToAdd, i_FuelType);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Charge(string i_LicensePlate, float i_NumberOfMinutesToAdd)
        {
            ElectricVehicle vehicle = m_Jobs[i_LicensePlate].Vehicle as ElectricVehicle;

            if (vehicle != null)
            {
                vehicle.Charge(i_NumberOfMinutesToAdd);
            }
            else
            {
                throw new ArgumentException();
            }

        }

        public EntryForm GetJob(string i_LicensePlate)
        {
            return m_Jobs[i_LicensePlate];
        }

        public bool Contains(string i_LiscensePlate)
        {
            return m_Jobs.ContainsKey(i_LiscensePlate);
        }

        public void RemoveJob(string i_LiscensePlate) 
        {
            m_Jobs.Remove(i_LiscensePlate);
        }
    }
}
