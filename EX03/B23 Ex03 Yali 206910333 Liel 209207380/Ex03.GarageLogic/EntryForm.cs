﻿

namespace Ex03.GarageLogic
{
    public class EntryForm
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;


        public EntryForm(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName= i_OwnerName;
            m_OwnerPhoneNumber= i_OwnerPhoneNumber;
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = eVehicleStatus.InProgress;
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }
    }
}