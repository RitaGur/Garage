using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class CarInformation : VehicleInformation
    {
        private const int k_MinColorOptions = 1;
        private const int k_MaxColorOptions = 4;
        private Car.eColor m_Color;
        private int m_NumberOfDoors;

        public Car.eColor CarColor
        {
            get
            {
                return m_Color;
            }
        }

        public int NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
        }

        public static List<string> CarInformationString()
        {
            List<string> listString = new List<string>(VehicleInformationString());
            listString.Add("Color: 1)Red , 2)Silver , 3)White , 4)Black");
            listString.Add("Number of doors: (2 - 5)");

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
                    int userColorChoice = Convert.ToInt32(i_UserInput);
                    if (userColorChoice < k_MinColorOptions || userColorChoice > k_MaxColorOptions)
                    {
                        throw new ValueOutOfRangeException("Invalud input", k_MaxColorOptions, k_MinColorOptions, string.Empty);
                    }

                    Car.eColor userCarColor;
                    checkColorChoice(userColorChoice, out userCarColor);
                    m_Color = userCarColor;
                    break;
                case 5:
                    int userDoorsChoice = Convert.ToInt32(i_UserInput);
                    Car.IsValidNumberOfDoors(userDoorsChoice);
                    m_NumberOfDoors = userDoorsChoice;
                    break;
            }
        }

        private void checkColorChoice(int i_UserColorChoice, out Car.eColor o_UserCarColor)
        {
            switch (i_UserColorChoice)
            {
                case 1:
                    o_UserCarColor = Car.eColor.Red;
                    break;
                case 2:
                    o_UserCarColor = Car.eColor.Silver;
                    break;
                case 3:
                    o_UserCarColor = Car.eColor.White;
                    break;
                case 4:
                    o_UserCarColor = Car.eColor.Black;
                    break;
                default:
                    o_UserCarColor = Car.eColor.Black;
                    break;
            }
        }
    }
}
