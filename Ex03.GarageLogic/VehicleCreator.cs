using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        private List<VehicleCreatorListNode> m_VehicleType;

        public VehicleCreator()
        {
            m_VehicleType = new List<VehicleCreatorListNode>();
            m_VehicleType.Add(new VehicleCreatorListNode("Regular Car", RegularCarInformation.RegularCarInformationString(), new RegularCarInformation()));
            m_VehicleType.Add(new VehicleCreatorListNode("Electric Car", ElectricCarInformation.ElectricCarInformationString(), new ElectricCarInformation()));
            m_VehicleType.Add(new VehicleCreatorListNode("Regular Motorcycle", RegularMotorcycleInformation.RegularMotorcycleInformationString(), new RegularMotorcycleInformation()));
            m_VehicleType.Add(new VehicleCreatorListNode("Electric Motorcycle", ElectricMotorcycleInformation.ElectricMotorcycleInformationString(), new ElectricMotorcycleInformation()));
            m_VehicleType.Add(new VehicleCreatorListNode("Truck", TruckInformation.TruckInformationString(), new TruckInformation()));
        }

        public List<VehicleCreatorListNode> VehicleTypes
        {
            get
            {
                return m_VehicleType;
            }
        }

        public static Vehicle CreateVehicle(string i_VehicleType, VehicleInformation i_VehicleInformation)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case "Truck":
                    newVehicle = new Truck(i_VehicleInformation as TruckInformation);
                    break;
                case "Regular Car":
                    newVehicle = new RegularCar(i_VehicleInformation as RegularCarInformation);
                    break;
                case "Electric Car":
                    newVehicle = new ElectricCar(i_VehicleInformation as ElectricCarInformation);
                    break;
                case "Regular Motorcycle":
                    newVehicle = new RegularMotorcycle(i_VehicleInformation as RegularMotorcycleInformation);
                    break;
                case "Electric Motorcycle":
                    newVehicle = new ElectricMotorcycle(i_VehicleInformation as ElectricMotorcycleInformation);
                    break;
            }

            return newVehicle;
        }

        public class VehicleCreatorListNode
        {
            private string m_VehicleType;
            private List<string> m_ListOfVehicleInformation;
            private VehicleInformation m_VehicleInformation;

            public VehicleCreatorListNode(string i_VehicleTypeString, List<string> i_ListOfVehicleInformation, VehicleInformation i_VehicleInformation)
            {
                m_VehicleType = i_VehicleTypeString;
                m_ListOfVehicleInformation = i_ListOfVehicleInformation;
                m_VehicleInformation = i_VehicleInformation;
            }

            public string VehicleName
            {
                get
                {
                    return m_VehicleType;
                }
            }

            public List<string> ListOfVehicleInformation
            {
                get
                {
                    return m_ListOfVehicleInformation;
                }
            }

            public VehicleInformation VehicleInformation
            {
                get
                {
                    return m_VehicleInformation;
                }
            }
        }
    }
}
