using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class RegularCar : Car, IFuelable
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan95;
        private const float k_MaxFuelCapacity = 45f;
        private FuelEngine m_FuelEngine;

        public RegularCar(RegularCarInformation i_RegularCarInformation)
        : base(i_RegularCarInformation.ModelName, i_RegularCarInformation.LicensePlateNumber,
                i_RegularCarInformation.WheelManufacturerName, i_RegularCarInformation.CarColor,
                i_RegularCarInformation.NumberOfDoors)
        {
            m_FuelEngine = new FuelEngine(k_FuelType, i_RegularCarInformation.RemainingFuel, k_MaxFuelCapacity);
            EnergyPercentage = m_FuelEngine.EnergyPercentage;
        }

        FuelEngine.eFuelType IFuelable.FuelType
        {
            get
            {
                return m_FuelEngine.FuelType;
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

        void IFuelable.ReFuel(float i_FuelToAdd, FuelEngine.eFuelType i_FuelType)
        {
            m_FuelEngine.ReFuel(i_FuelToAdd, i_FuelType);
            EnergyPercentage = m_FuelEngine.EnergyPercentage;
        }

        public override string ToString()
        {
            StringBuilder regularCarString = new StringBuilder();
            regularCarString.AppendLine("Type: Regular Car");
            regularCarString.Append(base.ToString());
            regularCarString.Append(m_FuelEngine.ToString());

            return regularCarString.ToString();
        }
    }
}
