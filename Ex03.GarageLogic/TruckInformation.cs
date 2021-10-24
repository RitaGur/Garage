using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class TruckInformation : VehicleInformation
    {
        private const float k_MaxFuelCapacity = 120;
        private const int k_IsHazmat = 1;
        private const int k_IsNotHazmat = 2;
        private float m_RemainingFuel;
        private bool m_IsHazmat;
        private float m_MaxWeight;

        public float RemainingFuel
        {
            get
            {
                return m_RemainingFuel;
            }
        }

        public bool IsHazmat
        {
            get
            {
                return m_IsHazmat;
            }
        }

        public float MaxWeight
        {
            get
            {
                return m_MaxWeight;
            }
        }

        public static List<string> TruckInformationString()
        {
            List<string> listString = new List<string>(VehicleInformationString());
            listString.Add("Remaining fuel (0 - 120 (Liters)): ");
            listString.Add("Is hazmat truck: 1)Yes , 2)No");
            listString.Add("Max weight transition: ");

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
                    Engine.IsValidRemaingingEnergy(Convert.ToSingle(i_UserInput), k_MaxFuelCapacity);
                    m_RemainingFuel = Convert.ToSingle(i_UserInput);
                    break;
                case 5:
                    int userChoice = Convert.ToInt32(i_UserInput);
                    if (userChoice != k_IsHazmat && userChoice != k_IsNotHazmat)
                    {
                        throw new ValueOutOfRangeException("Invalid input", 2, 1, string.Empty);
                    }

                    m_IsHazmat = userChoice == k_IsHazmat ? true : false;
                    break;
                case 6:
                    Truck.IsValidMaxWeight(Convert.ToInt32(i_UserInput));
                    m_MaxWeight = Convert.ToInt32(i_UserInput);
                    break;
            }
        }
    }
}