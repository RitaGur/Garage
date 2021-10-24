using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public interface IElectric
    {
        float RemainingBatteryTime
        {
            get;
        }

        float MaxBatteryTime
        {
            get;
        }

        void ReCharge(float i_ChargeTimeToAdd);
    }
}
