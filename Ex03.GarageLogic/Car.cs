using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private const int k_MaxAirPressure = 32;
        private readonly eColor r_Color;
        private readonly int r_NumberOfDoors;

        public Car(string i_ModelName, string i_LicensePlateNumber, string i_WheelManufacturerName, eColor i_Color, int i_NumberOfdoors)
        : base(i_ModelName, i_LicensePlateNumber)
        {
            CreateWheels(i_WheelManufacturerName, k_MaxAirPressure, k_NumberOfWheels);
            r_Color = i_Color;
            r_NumberOfDoors = i_NumberOfdoors;
        }

        public enum eColor
        {
            Red, Silver, White, Black
        }

        public static void IsValidNumberOfDoors(int i_NumberOfDoors)
        {
            if (!(i_NumberOfDoors >= 2 && i_NumberOfDoors <= 5))
            {
                throw new ValueOutOfRangeException("Invalid number of doors", 5, 2, string.Empty);
            }
        }

        public override string ToString()
        {
            StringBuilder carString = new StringBuilder();
            carString.Append(base.ToString());
            carString.Append("Car Color: ").AppendLine(r_Color.ToString());
            carString.Append("Number of Doors: ").AppendLine(r_NumberOfDoors.ToString());

            return carString.ToString();
        }
    }
}
