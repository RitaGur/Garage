using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlateNumber;
        private float? m_EnergyPercentage = null;
        private List<Wheel> m_Wheels = null;

        public Vehicle(string i_ModelName, string i_LicensePlateNumber)
        {
            r_ModelName = i_ModelName;
            r_LicensePlateNumber = i_LicensePlateNumber;
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return r_LicensePlateNumber;
            }
        }

        public float? EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }

            set
            {
                m_EnergyPercentage = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

        public static void IsLicensePlateNumberValid(string i_LicensePlateNumber)
        {
            int output;

            if (i_LicensePlateNumber.Length != 7 && i_LicensePlateNumber.Length != 8)
            {
                throw new ValueOutOfRangeException("Invalid plate number", 8, 7, "digits");
            }

            if (!int.TryParse(i_LicensePlateNumber, out output))
            {
                throw new FormatException("Invalid license plate - should be only numbers");
            }
        }

        public void AllWheelsMaxInflateAir()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.AirInflation(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();
            vehicleString.Append("License Number: ").AppendLine(r_LicensePlateNumber);
            vehicleString.Append("Model Name: ").AppendLine(r_ModelName);
            vehicleString.Append(m_Wheels.First().ToString());

            return vehicleString.ToString();
        }

        public override int GetHashCode()
        {
            return r_LicensePlateNumber.GetHashCode();
        }

        protected void CreateWheels(string i_WheelManufacturerName, int i_MaxAirPressure, int i_NumberOfWheels)
        {
            List<Wheel> listOfWheels = new List<Wheel>();
            Random airPressure = new Random();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                listOfWheels.Add(new Wheel(i_WheelManufacturerName, airPressure.Next(i_MaxAirPressure + 1), i_MaxAirPressure));
            }

            m_Wheels = listOfWheels;
        }

        public class Wheel
        {
            private readonly string r_ManufacturerName;
            private readonly float r_MaxAirPressure;
            private float m_CurrentAirPressure;

            public Wheel(string i_ManuFacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
            {
                r_ManufacturerName = i_ManuFacturerName;
                m_CurrentAirPressure = i_CurrentAirPressure;
                r_MaxAirPressure = i_MaxAirPressure;
            }

            public string ManufacturerName
            {
                get
                {
                    return r_ManufacturerName;
                }
            }

            public float CurrentAirPressure
            {
                get
                {
                    return m_CurrentAirPressure;
                }

                set
                {
                    m_CurrentAirPressure = value;
                }
            }

            public float MaxAirPressure
            {
                get
                {
                    return r_MaxAirPressure;
                }
            }

            public void AirInflation(float i_AirToAdd)
            {
                if (r_MaxAirPressure - m_CurrentAirPressure < i_AirToAdd) 
                {
                    throw new ValueOutOfRangeException("Invalid amaount of air to add", r_MaxAirPressure - m_CurrentAirPressure, 0, string.Empty);
                }
                else
                {
                    m_CurrentAirPressure += i_AirToAdd;
                }
            }

            public override string ToString()
            {
                StringBuilder wheelsString = new StringBuilder();
                wheelsString.Append("Wheels Air-Pressure: ").AppendLine(m_CurrentAirPressure.ToString());
                wheelsString.Append("Wheels Manufacturer: ").AppendLine(r_ManufacturerName);

                return wheelsString.ToString();
            }
        }
    }
}
