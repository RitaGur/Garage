using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public interface IFuelable
    {
        FuelEngine.eFuelType FuelType
        {
            get;
        }

        float RemainingFuel
        {
            get;
        }

        float MaxFuelCapacity
        {
            get;
        }

        void ReFuel(float i_FuelToAdd, FuelEngine.eFuelType i_FuelType);
    }
}
