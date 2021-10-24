using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycleInformation : MotorcycleInformation
    {
        private const float k_MaxBatteryTime = 1.8f;
        private float m_RemainingBatteryTime;

        public float RemainingBatteryTime
        {
            get
            {
                return m_RemainingBatteryTime;
            }
        }

        public static List<string> ElectricMotorcycleInformationString()
        {
            List<string> listString = new List<string>(MotorcycleInformationString());
            listString.Add("Remaining battery: (0 - 1.8 (Hours)) ");

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
                    base.InputCheck(i_NumOfCheck, i_UserInput);
                    break;
                case 5:
                    base.InputCheck(i_NumOfCheck, i_UserInput);
                    break;
                case 6:
                    Engine.IsValidRemaingingEnergy(Convert.ToSingle(i_UserInput), k_MaxBatteryTime);
                    m_RemainingBatteryTime = Convert.ToSingle(i_UserInput);
                    break;
            }
        }
    }
}
