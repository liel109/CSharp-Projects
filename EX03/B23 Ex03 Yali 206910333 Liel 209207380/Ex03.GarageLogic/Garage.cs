using System;
using System.Collections.Generic;
using System.Linq;
using static Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public readonly Dictionary<string, EntryForm> m_Jobs;

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

        //public List<string> GetJobs(string i_FilterByStatus)
        //{
        //    int status;
        //    bool isFormatValid = int.TryParse(i_FilterByStatus, out status);
        //    List<string> jobs = null;

        //    if (!isFormatValid)
        //    {
        //        throw new FormatException("Incorrect Format");
        //    }
        //    else if (!Enum.IsDefined(typeof(eVehicleStatus), status))
        //    {
        //        throw new ArgumentException("Incorrect Argument");
        //    }
        //    else
        //    {
        //        jobs = GetJobs((eVehicleStatus)status);
        //    }

        //    return jobs;
        //}

        private List<string> GetJobs(string i_FilterByStatus)
        {
            Validator.ValidateEnum(typeof(eVehicleStatus), i_FilterByStatus);
            eVehicleStatus vehicleStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_FilterByStatus);
            List<string> filteredList = new List<string>();

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
            m_Jobs[i_LicensePlate].Vehicle.InflateWheelsToMax();
        }


        public void Fuel(string i_LicensePlate, string i_FuelType, string i_AmountToAdd)
        {
            float fuelAmount;

            Validator.ValidatePossitiveFloat(i_AmountToAdd, out fuelAmount);
            Validator.ValidateEnum(typeof(PetrolEngine.eFuelType), i_FuelType);
            PetrolEngine.eFuelType fuelType = (PetrolEngine.eFuelType)Enum.Parse(typeof(PetrolEngine.eFuelType), i_FuelType);
            Engine vehicleEngine = m_Jobs[i_LicensePlate].Vehicle.Engine;
            Vehicle vehicle = m_Jobs[i_LicensePlate].Vehicle;
            if (vehicleEngine is PetrolEngine petrolEngine)
            {
                if (fuelType == petrolEngine.FuelType)
                {
                    try
                    {
                        petrolEngine.FuelAmount += fuelAmount;
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

        public void Fuel(string i_LicensePlate, PetrolEngine.eFuelType i_FuelType, float i_AmountToAdd)
        {
            Engine vehicleEngine = m_Jobs[i_LicensePlate].Vehicle.Engine;
            Vehicle vehicle = m_Jobs[i_LicensePlate].Vehicle; 

            if (vehicleEngine is PetrolEngine petrolEngine)
            {
                if (i_FuelType == petrolEngine.FuelType)
                {
                    try
                    {
                        petrolEngine.FuelAmount += i_AmountToAdd;
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

        public void Charge(string i_LicensePlate, float i_NumberOfMinutesToAdd)
        {
            Engine vehicleEngine = m_Jobs[i_LicensePlate].Vehicle.Engine;
            Vehicle vehicle = m_Jobs[i_LicensePlate].Vehicle;

            if (vehicleEngine is ElectricEngine electricEngine)
            {
                try
                {
                    float numberOfHoursToAdd = i_NumberOfMinutesToAdd / 60;

                    electricEngine.RemainingBatteryHours += numberOfHoursToAdd;
                    vehicle.RemainingEnergyPercentage = electricEngine.RemainingBatteryHours / electricEngine.MaxBatteryCapacity;
                }
                catch(ValueOutOfRangeException e)
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

        public void Charge(string i_LicensePlate, string i_NumberOfMinutesToAdd)
        {
            float numberOfMinutesToAdd;
            Validator.ValidatePossitiveFloat(i_NumberOfMinutesToAdd, out numberOfMinutesToAdd);
            Engine vehicleEngine = m_Jobs[i_LicensePlate].Vehicle.Engine;
            Vehicle vehicle = m_Jobs[i_LicensePlate].Vehicle;

            if (vehicleEngine is ElectricEngine electricEngine)
            {
                try
                {
                    float numberOfHoursToAdd = numberOfMinutesToAdd / 60;

                    electricEngine.RemainingBatteryHours += numberOfHoursToAdd;
                    vehicle.RemainingEnergyPercentage = electricEngine.RemainingBatteryHours / electricEngine.MaxBatteryCapacity;
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

        public void ChangeStatus(string i_LicensePlate, string i_NewStatus)
        {
            Validator.ValidateEnum(typeof(eVehicleStatus), i_NewStatus);
            eVehicleStatus newStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_NewStatus);
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
