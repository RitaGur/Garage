using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle, IElectric
    {
        private const float k_MaxBatteryTime = 1.8f;
        private ElectricEngine m_ElectricEngine;

        public ElectricMotorcycle(ElectricMotorcycleInformation i_ElectricMotorcycleInformation)
        : base(i_ElectricMotorcycleInformation.ModelName, i_ElectricMotorcycleInformation.LicensePlateNumber,
              i_ElectricMotorcycleInformation.WheelManufacturerName, i_ElectricMotorcycleInformation.LicenseType,
              i_ElectricMotorcycleInformation.EngineCapacity)
        {
            m_ElectricEngine = new ElectricEngine(i_ElectricMotorcycleInformation.RemainingBatteryTime, k_MaxBatteryTime);
            EnergyPercentage = m_ElectricEngine.EnergyPercentage;
        }

        float IElectric.RemainingBatteryTime
        {
            get
            {
                return m_ElectricEngine.RemainingEnergy;
            }
        }

        float IElectric.MaxBatteryTime
        {
            get
            {
                return m_ElectricEngine.MaxEnergyCapacity;
            }
        }

        void IElectric.ReCharge(float i_ChargeTimeToAdd)
        {
            m_ElectricEngine.ReCharge(i_ChargeTimeToAdd);
            EnergyPercentage = m_ElectricEngine.EnergyPercentage;
        }

        public override string ToString()
        {
            StringBuilder electricMotorcycleString = new StringBuilder();
            electricMotorcycleString.AppendLine("Type: Electric Motorcycle");
            electricMotorcycleString.Append(base.ToString());
            electricMotorcycleString.Append(m_ElectricEngine.ToString());

            return electricMotorcycleString.ToString();
        }
    }
}
