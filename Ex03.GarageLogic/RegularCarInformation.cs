using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class RegularCarInformation : CarInformation
    {
        private const float k_MaxFuelCapacity = 45f;
        private float m_RemainingFuel;

        public float RemainingFuel
        {
            get
            {
                return m_RemainingFuel;
            }
        }

        public static List<string> RegularCarInformationString()
        {
            List<string> listString = new List<string>(CarInformationString());
            listString.Add("Remaining fuel (0 - 45 (Liters)): ");

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
                    Engine.IsValidRemaingingEnergy(Convert.ToSingle(i_UserInput), k_MaxFuelCapacity);
                    m_RemainingFuel = Convert.ToSingle(i_UserInput);
                    break;
            }
        }
    }
}
