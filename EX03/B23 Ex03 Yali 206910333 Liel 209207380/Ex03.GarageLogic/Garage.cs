﻿using System;
using System.Collections.Generic;
using System.Linq;
using static Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, EntryForm> m_Jobs;

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
        
        public List<string> GetJobs(int i_FilterByStatus)
        {
            List<string> filteredList;
            eVehicleStatus vehicleStatus = (eVehicleStatus)i_FilterByStatus;

            filteredList = new List<string>();
            foreach (string licenseNumber in m_Jobs.Keys)
            {
                if (m_Jobs[licenseNumber].VehicleStatus == vehicleStatus)
                {
                    filteredList.Add(licenseNumber);
                }
            }

            return filteredList;
        }

        public List<string> GetJobs()
        {
            return m_Jobs.Keys.ToList<string>();
        }

        public void InflateWheelsToMaximum(string i_LicensePlate)
        {
            m_Jobs[i_LicensePlate].Vehicle.InflateTiresToMax();
        }

        public void Fuel(string i_LicensePlate, int i_FuelType, string i_AmountToAdd)
        {
            Vehicle vehicle = m_Jobs[i_LicensePlate].Vehicle;
            Engine vehicleEngine = vehicle.Engine;

            if (vehicleEngine is PetrolEngine petrolEngine)
            {
                PetrolEngine.eFuelType fuelType = (PetrolEngine.eFuelType)i_FuelType;

                if (fuelType == petrolEngine.FuelType)
                {
                    try
                    {
                        float fuelAmountFloat;

                        Validator.ValidatePositiveFloat(i_AmountToAdd, out fuelAmountFloat);
                        petrolEngine.FuelAmount += fuelAmountFloat;
                        vehicle.RemainingEnergyPercentage = petrolEngine.FuelAmount / petrolEngine.FuelCapacity;
                    }
                    catch (ValueOutOfRangeException e)
                    {
                        float maxPossibleAmountToAdd = petrolEngine.FuelCapacity - petrolEngine.FuelAmount;

                        throw new ValueOutOfRangeException(0, maxPossibleAmountToAdd);
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid Fuel Type");
                }
            }
            else
            {
                throw new ArgumentException("Can't Fuel Electric Vehicle");
            }
        }

        public void Charge(string i_LicensePlate, string i_NumberOfMinutesToAdd)
        {
            Vehicle vehicleToFuel = m_Jobs[i_LicensePlate].Vehicle;
            Engine vehicleEngine = vehicleToFuel.Engine;

            if (vehicleEngine is ElectricEngine electricEngine)
            {
                try
                {
                    float numberOfMinutesToAddFloat;

                    Validator.ValidatePositiveFloat(i_NumberOfMinutesToAdd, out numberOfMinutesToAddFloat);
                    float numberOfHoursToAdd = numberOfMinutesToAddFloat / 60;
                    electricEngine.RemainingBatteryHours += numberOfHoursToAdd;
                    vehicleToFuel.RemainingEnergyPercentage = electricEngine.RemainingBatteryHours / electricEngine.MaxBatteryCapacity;
                }
                catch (ValueOutOfRangeException e)
                {
                    float maxPossibleBatteryHoursToAdd = electricEngine.MaxBatteryCapacity - electricEngine.RemainingBatteryHours;
                    float maxPossibleBatteryMinutesToAdd = maxPossibleBatteryHoursToAdd * 60;

                    throw new ValueOutOfRangeException(0, maxPossibleBatteryMinutesToAdd);
                }
            }
            else
            {
                throw new ArgumentException("Can't Charge Petrol Car");
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

        public void ChangeStatus(string i_LicensePlate, int i_NewStatus)
        {
            eVehicleStatus newStatus = (eVehicleStatus)i_NewStatus;

            m_Jobs[i_LicensePlate].VehicleStatus = newStatus;
        }

        public string[] GetStatusOptions()
        {
            return Enum.GetNames(typeof(eVehicleStatus));
        }

        public string[] GetFuelTypes()
        {
            return Enum.GetNames(typeof(PetrolEngine.eFuelType));
        }

        public enum eVehicleStatus
        {
            InProgress = 1,
            Repaired = 2,
            Payed = 3
        }
    }
}
