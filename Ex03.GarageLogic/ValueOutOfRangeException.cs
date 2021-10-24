using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_WordToAdd;

        public ValueOutOfRangeException(string i_ExceptionMessage, float i_MaxValueInput, float i_MinValueInput, string i_WordToAdd)
        : base(i_ExceptionMessage)
        {
            m_MaxValue = i_MaxValueInput;
            m_MinValue = i_MinValueInput;
            m_WordToAdd = i_WordToAdd;
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public string WordToAdd
        {
            get
            {
                return m_WordToAdd;
            }
        }
    }
}
