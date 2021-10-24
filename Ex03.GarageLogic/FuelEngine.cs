using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_RemainingFuel, float i_MaxFuelCapacity)
        : base(i_RemainingFuel, i_MaxFuelCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public enum eFuelType
        {
            Soler, Octan95, Octan96, Octan98
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public void ReFuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(string.Format("Invalid fuel type. should be {0}", r_FuelType));
            }

            ReEnergy(i_FuelToAdd);
        }

        public override string ToString()
        {
            StringBuilder fuelEngineString = new StringBuilder();
            fuelEngineString.Append("Fuel percentage: ").Append((EnergyPercentage * 100).ToString()).AppendLine("%");
            fuelEngineString.Append("Fuel Type: ").AppendLine(r_FuelType.ToString());

            return fuelEngineString.ToString();
        }
    }
}
