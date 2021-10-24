using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class VehicleInformation
    {
        private string m_ModelName = null;
        private string m_LicensePlateNumber = null;
        private string m_WheelManufacturerName = null;

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return m_LicensePlateNumber;
            }
        }

        public string WheelManufacturerName
        {
            get
            {
                return m_WheelManufacturerName;
            }
        }

        public static List<string> VehicleInformationString()
        {
            List<string> listString = new List<string>();
            listString.Add("Model name: ");
            listString.Add("License plate number: (7 - 8 digits) ");
            listString.Add("Wheels manufacturer name: ");

            return listString;
        }

        public virtual void InputCheck(int i_NumOfCheck, object i_UserInput)
        {
            switch (i_NumOfCheck)
            {
                case 1:
                    m_ModelName = i_UserInput as string;
                    break;
                case 2:
                    Vehicle.IsLicensePlateNumberValid(i_UserInput as string);
                    m_LicensePlateNumber = i_UserInput as string;
                    break;
                case 3:
                    m_WheelManufacturerName = i_UserInput as string;
                    break;
            }
        }

        public override int GetHashCode()
        {
            return m_LicensePlateNumber.GetHashCode();
        }
    }
}
