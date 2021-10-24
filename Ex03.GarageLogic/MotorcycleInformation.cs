using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class MotorcycleInformation : VehicleInformation
    {
        private const int k_MinLicenseTypeOption = 1;
        private const int k_MaxLicenseTypeOption = 4;
        private Motorcycle.eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle.eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        public static List<string> MotorcycleInformationString()
        {
            List<string> listString = new List<string>(VehicleInformationString());
            listString.Add("License Type: 1)A , 2)B1 , 3)AA , 4)BB");
            listString.Add("Engine capacity: ");

            return listString;
        }

        public override void InputCheck(int i_NumOfCheck, object i_UserInput)
        {
            switch (i_NumOfCheck)
            {
                case 1:
                    base.InputCheck(i_NumOfCheck, i_UserInput);
                    break;
                case 2:
                    base.InputCheck(i_NumOfCheck, i_UserInput);
                    break;
                case 3:
                    base.InputCheck(i_NumOfCheck, i_UserInput);
                    break;
                case 4:
                    int userLicenseTypeChoice = Convert.ToInt32(i_UserInput);
                    if (userLicenseTypeChoice < k_MinLicenseTypeOption || userLicenseTypeChoice > k_MaxLicenseTypeOption)
                    {
                        throw new ValueOutOfRangeException("Invalid input", k_MaxLicenseTypeOption, k_MinLicenseTypeOption, string.Empty);
                    }

                    Motorcycle.eLicenseType userLicenseType;
                    checkLicenseTypeChoice(userLicenseTypeChoice, out userLicenseType);
                    m_LicenseType = userLicenseType;
                    break;
                case 5:
                    int engineCapacityInput = Convert.ToInt32(i_UserInput);
                    Motorcycle.IsValidEngineCapacity(engineCapacityInput);
                    m_EngineCapacity = engineCapacityInput;
                    break;
            }
        }

        private void checkLicenseTypeChoice(int i_UserLicenseTypeChoice, out Motorcycle.eLicenseType o_UserLicenseType)
        {
            switch (i_UserLicenseTypeChoice)
            {
                case 1:
                    o_UserLicenseType = Motorcycle.eLicenseType.A;
                    break;
                case 2:
                    o_UserLicenseType = Motorcycle.eLicenseType.B1;
                    break;
                case 3:
                    o_UserLicenseType = Motorcycle.eLicenseType.AA;
                    break;
                case 4:
                    o_UserLicenseType = Motorcycle.eLicenseType.BB;
                    break;
                default:
                    o_UserLicenseType = Motorcycle.eLicenseType.A;
                    break;
            }
        }
    }
}
