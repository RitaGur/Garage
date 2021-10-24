using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_MaxEnergyCapacity;
        private float m_RemainingEnergy;
        private float m_EnergyPercentage;

        public Engine(float i_RemainingEnergy, float i_MaxEnergyCapacity)
        {
            m_RemainingEnergy = i_RemainingEnergy;
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            m_EnergyPercentage = m_RemainingEnergy / r_MaxEnergyCapacity;
        }

        public float RemainingEnergy
        {
            get
            {
                return m_RemainingEnergy;
            }
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return r_MaxEnergyCapacity;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
        }

        public static void IsValidRemaingingEnergy(float i_RemainingEnergy, float i_MaxEnergyCapacity)
        {
            if (i_RemainingEnergy < 0 || i_RemainingEnergy > i_MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException("Invalid amount of Remaining energy", i_MaxEnergyCapacity, 0, string.Empty);
            }
        }

        protected void ReEnergy(float i_EnergyToAdd)
        {
            if (r_MaxEnergyCapacity - m_RemainingEnergy < i_EnergyToAdd || i_EnergyToAdd < 0)
            {
                throw new ValueOutOfRangeException("Invalid amount of Energy to add", r_MaxEnergyCapacity - m_RemainingEnergy, 0, string.Empty);
            }
            else
            {
                m_RemainingEnergy += i_EnergyToAdd;
                m_EnergyPercentage = m_RemainingEnergy / r_MaxEnergyCapacity;
            }
        }
    }
}
