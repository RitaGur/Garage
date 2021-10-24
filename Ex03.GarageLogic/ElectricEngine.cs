using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_RemainingBattery, float i_MaxBatteryTime)
        : base(i_RemainingBattery, i_MaxBatteryTime)
        {
        }

        public void ReCharge(float i_ChargeTimeToAdd)
        {
            if (MaxEnergyCapacity - RemainingEnergy < i_ChargeTimeToAdd || i_ChargeTimeToAdd < 0)
            {
                throw new ValueOutOfRangeException("Invalid amount of Energy to add", (MaxEnergyCapacity - RemainingEnergy) * 60, 0, "minutes");
            }

            ReEnergy(i_ChargeTimeToAdd);
        }

        public override string ToString()
        {
            StringBuilder electricEngineString = new StringBuilder();
            electricEngineString.Append("Battery percentage: ").Append((EnergyPercentage * 100).ToString()).AppendLine("%");

            return electricEngineString.ToString();
        }
    }
}
