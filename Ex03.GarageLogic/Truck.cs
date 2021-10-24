using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle, IFuelable
    {
        private const int k_NumberOfWheels = 16;
        private const int k_MaxAirPressure = 26;
        private const float k_MaxFuelCapacity = 120;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Soler;
        private readonly bool r_IsHazmat;
        private readonly float r_MaxWeight;
        private FuelEngine m_FuelEngine;

        public Truck(TruckInformation i_TruckInformation)
        : base(i_TruckInformation.ModelName, i_TruckInformation.LicensePlateNumber)
        {
            CreateWheels(i_TruckInformation.WheelManufacturerName, k_MaxAirPressure, k_NumberOfWheels);
            m_FuelEngine = new FuelEngine(k_FuelType, i_TruckInformation.RemainingFuel, k_MaxFuelCapacity);
            EnergyPercentage = m_FuelEngine.EnergyPercentage;
            r_IsHazmat = i_TruckInformation.IsHazmat;
            r_MaxWeight = i_TruckInformation.MaxWeight;
        }

        public bool IsHazmat
        {
            get
            {
                return r_IsHazmat;
            }
        }

        public float MaxWeight
        {
            get
            {
                return r_MaxWeight;
            }
        }

        float IFuelable.RemainingFuel
        {
            get
            {
                return m_FuelEngine.RemainingEnergy;
            }
        }

        float IFuelable.MaxFuelCapacity
        {
            get
            {
                return m_FuelEngine.MaxEnergyCapacity;
            }
        }

        FuelEngine.eFuelType IFuelable.FuelType
        {
            get
            {
                return m_FuelEngine.FuelType;
            }
        }

        public static void IsValidMaxWeight(int i_MaxWeightInput)
        {
            if (i_MaxWeightInput <= 0)
            {
                throw new ArgumentException("Imvalid max weight - should be positive number");
            }
        }

        void IFuelable.ReFuel(float i_FuelToAdd, FuelEngine.eFuelType i_FuelType)
        {
            m_FuelEngine.ReFuel(i_FuelToAdd, i_FuelType);
            EnergyPercentage = m_FuelEngine.EnergyPercentage;
        }

        public override string ToString()
        {
            StringBuilder truckString = new StringBuilder();
            truckString.AppendLine("Type: Truck");
            truckString.Append(base.ToString());
            truckString.Append(m_FuelEngine.ToString());
            truckString.AppendLine(string.Format("Is Hazmat truck: {0}", r_IsHazmat ? "Yes" : "No"));
            truckString.Append("Max transition weight: ").AppendLine(r_MaxWeight.ToString());

            return truckString.ToString();
        }
    }
}
