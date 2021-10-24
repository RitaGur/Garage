using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class RegularMotorcycle : Motorcycle, IFuelable
    {
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
        private const float k_MaxFuelCapacity = 6;

        private FuelEngine m_FuelEngine;

        public RegularMotorcycle(RegularMotorcycleInformation i_RegularMotorcycleInformation)
            : base(i_RegularMotorcycleInformation.ModelName, i_RegularMotorcycleInformation.LicensePlateNumber,
                  i_RegularMotorcycleInformation.WheelManufacturerName, i_RegularMotorcycleInformation.LicenseType,
                  i_RegularMotorcycleInformation.EngineCapacity)
        {
            m_FuelEngine = new FuelEngine(k_FuelType, i_RegularMotorcycleInformation.RemainingFuel, k_MaxFuelCapacity);
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
            StringBuilder regularMotorcycleString = new StringBuilder();
            regularMotorcycleString.AppendLine("Type: Regular Motorcycle");
            regularMotorcycleString.Append(base.ToString());
            regularMotorcycleString.Append(m_FuelEngine.ToString());

            return regularMotorcycleString.ToString();
        }
    }
}
