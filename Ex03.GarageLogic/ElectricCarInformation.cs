using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCarInformation : CarInformation
    {
        private const float k_MaxBatteryTime = 3.2f;
        private float m_RemainingBatteryTime;

        public float RemainingBatteryTime
        {
            get
            {
                return m_RemainingBatteryTime;
            }
        }

        public static List<string> ElectricCarInformationString()
        {
            List<string> listString = new List<string>(CarInformationString());
            listString.Add("Remaining battery: (0 - 3.2 (Hours))");

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
