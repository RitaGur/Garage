using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car, IElectric
    {
        private const float k_MaxBatteryTime = 3.2f;

        private ElectricEngine m_ElectricEngine;

        public ElectricCar(ElectricCarInformation i_ElectricCarInformation)
         : base(i_ElectricCarInformation.ModelName, i_ElectricCarInformation.LicensePlateNumber,
              i_ElectricCarInformation.WheelManufacturerName, i_ElectricCarInformation.CarColor,
              i_ElectricCarInformation.NumberOfDoors)
        {
            m_ElectricEngine = new ElectricEngine(i_ElectricCarInformation.RemainingBatteryTime, k_MaxBatteryTime);
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
            StringBuilder electricCarString = new StringBuilder();
            electricCarString.AppendLine("Type: Electric Car");
            electricCarString.Append(base.ToString());
            electricCarString.Append(m_ElectricEngine.ToString());

            return electricCarString.ToString();
        }
    }
}
