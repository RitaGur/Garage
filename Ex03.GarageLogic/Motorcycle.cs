using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const int k_MaxAirPressure = 30;
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(string i_ModelName, string i_LicensePlateNumber, string i_WheelManufacturerName, eLicenseType i_LicenseType, int i_EngineCapacity)
        : base(i_ModelName, i_LicensePlateNumber)
        {
            CreateWheels(i_WheelManufacturerName, k_MaxAirPressure, k_NumberOfWheels);
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public enum eLicenseType
        {
            A, B1, AA, BB
        }

        public static void IsValidEngineCapacity(int i_EngineCapacity)
        {
            if (i_EngineCapacity <= 0)
            {
                throw new ArgumentException("Invalid engine capacity - should be positive number"); 
            }
        }

        public override string ToString()
        {
            StringBuilder motorcycleString = new StringBuilder();
            motorcycleString.Append(base.ToString());
            motorcycleString.Append("License Type: ").AppendLine(r_LicenseType.ToString());
            motorcycleString.Append("Engine capacity: ").AppendLine(r_EngineCapacity.ToString());

            return motorcycleString.ToString();
        }
    }
}
