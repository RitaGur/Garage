using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<int, GarageClient> m_GarageClients;
        private VehicleCreator m_VehicleCreator;

        public Garage()
        {
            m_GarageClients = new Dictionary<int, GarageClient>();
            m_VehicleCreator = new VehicleCreator();
        }

        public Dictionary<int, GarageClient> GarageClients
        {
            get
            {
                return m_GarageClients;
            }
        }

        public VehicleCreator VehicleCreator
        {
            get
            {
                return m_VehicleCreator;
            }
        }

        public void AddClient(string i_OwnerName, string i_OwnerPhoneNumber, string i_VehicleType, VehicleInformation i_VehicleInformation)
        {
            int newVehicleHashCode = i_VehicleInformation.GetHashCode();
            if (m_GarageClients.ContainsKey(newVehicleHashCode))
            {
                m_GarageClients[newVehicleHashCode].ClientReport.VehicleState = ClientReport.eVehicleState.InRepair;
                throw new ArgumentException("Client allready exist. Client state change to 'In Repair'");
            }
            else
            {
                GarageClient newGarageClient = new GarageClient(i_OwnerName, i_OwnerPhoneNumber, VehicleCreator.CreateVehicle(i_VehicleType, i_VehicleInformation));
                m_GarageClients.Add(newVehicleHashCode, newGarageClient);
            }
        }

        public string ShowLicensePlateNumberByState(ClientReport.eVehicleState i_VehicleState)
        {
            StringBuilder licensePlateNumberByState = new StringBuilder();
            licensePlateNumberByState.AppendLine("Vehicles license plate number: ");
            foreach (KeyValuePair<int, GarageClient> client in m_GarageClients)
            {
                if (client.Value.ClientReport.VehicleState == i_VehicleState)
                {
                    licensePlateNumberByState.AppendLine(client.Value.ClientVehicle.LicensePlateNumber);
                }
            }

            return licensePlateNumberByState.ToString();
        }

        public string ShowAllLicensePlateNumbers()
        {
            StringBuilder licensePlateNumberByState = new StringBuilder();
            licensePlateNumberByState.AppendLine("Vehicles license plate number: ");
            foreach (KeyValuePair<int, GarageClient> client in m_GarageClients)
            {
                licensePlateNumberByState.AppendLine(client.Value.ClientVehicle.LicensePlateNumber);
            }

            return licensePlateNumberByState.ToString();
        }

        public void ChangeVehicleState(string i_LicensePlateNumber, ClientReport.eVehicleState i_NewStateReport)
        {
            int currVehicleHashCode = i_LicensePlateNumber.GetHashCode();
            if (!m_GarageClients.ContainsKey(currVehicleHashCode))
            {
                throw new ArgumentException("License plate number not exist");
            }
            else
            {
                m_GarageClients[currVehicleHashCode].ClientReport.VehicleState = i_NewStateReport;
            }
        }

        public void InflateAirToMax(string i_LicensePlateNumber)
        {
            int currVehicleHashCode = i_LicensePlateNumber.GetHashCode();
            if (!m_GarageClients.ContainsKey(currVehicleHashCode))
            {
                throw new ArgumentException("License plate number not exist");
            }
            else
            {
                m_GarageClients[currVehicleHashCode].ClientVehicle.AllWheelsMaxInflateAir();
            }
        }

        public void ReFuelVehicle(string i_LicensePlateNumber, FuelEngine.eFuelType i_FuelType, float i_FuelToAdd)
        {
            int currVehicleHashCode = i_LicensePlateNumber.GetHashCode();
            if (!m_GarageClients.ContainsKey(currVehicleHashCode))
            {
                throw new ArgumentException("License plate number not exist");
            }

            if (!(m_GarageClients[currVehicleHashCode].ClientVehicle is IFuelable))
            {
                throw new ArgumentException("The current vehicle has not have fuel engine");
            }
            else
            {
                (m_GarageClients[currVehicleHashCode].ClientVehicle as IFuelable).ReFuel(i_FuelToAdd, i_FuelType);
            }
        }

        public void ReChargeVehicle(string i_LicensePlateNumber, float i_MinutesToCharge)
        {
            int currVehicleHashCode = i_LicensePlateNumber.GetHashCode();
            if (!m_GarageClients.ContainsKey(currVehicleHashCode))
            {
                throw new ArgumentException("License plate number not exist");
            }

            if (!(m_GarageClients[currVehicleHashCode].ClientVehicle is IElectric))
            {
                throw new ArgumentException("The current vehicle has not have electric engine");
            }

            (m_GarageClients[currVehicleHashCode].ClientVehicle as IElectric).ReCharge(i_MinutesToCharge / 60);
        }

        public string ShowClientInformation(string i_LicensePlateNumber)
        {
            int currVehicleHashCode = i_LicensePlateNumber.GetHashCode();
            if (!m_GarageClients.ContainsKey(currVehicleHashCode))
            {
                throw new ArgumentException("License plate number not exist");
            }
            else
            {
                return m_GarageClients[currVehicleHashCode].ToString();
            }
        }

        public bool IsClientInGarage(string i_LicensePlateNumber)
        {
            return m_GarageClients.ContainsKey(i_LicensePlateNumber.GetHashCode());
        }

        public override string ToString()
        {
            StringBuilder garageString = new StringBuilder();
            int numberOfClient = 1;
            foreach (GarageClient garageClient in m_GarageClients.Values)
            {
                garageString.AppendLine(string.Format("--------Client number {0}--------", numberOfClient));
                garageString.AppendLine(garageClient.ToString());
                numberOfClient++;
            }

            return garageString.ToString();
        }

        public class GarageClient
        {
            private Vehicle m_ClientVehicle;
            private ClientReport m_ClientReport;

            public GarageClient(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_ClientVehicle)
            {
                m_ClientVehicle = i_ClientVehicle;
                m_ClientReport = new ClientReport(i_OwnerName, i_OwnerPhoneNumber);
            }

            public Vehicle ClientVehicle
            {
                get
                {
                    return m_ClientVehicle;
                }
            }

            public ClientReport ClientReport
            {
                get
                {
                    return m_ClientReport;
                }
            }

            public override string ToString()
            {
                StringBuilder garageClientString = new StringBuilder();
                garageClientString.AppendLine("Client information and state: ").AppendLine(m_ClientReport.ToString());
                garageClientString.AppendLine("Vehicle information: ").Append(m_ClientVehicle.ToString());

                return garageClientString.ToString();
            }
        }

        public class ClientReport
        {
            private readonly string r_OwnerName;
            private readonly string r_OwnerPhoneNumber;
            private eVehicleState m_VehicleState;

            public ClientReport(string i_OwnerName, string i_OwnerPhoneNumber)
            {
                r_OwnerName = i_OwnerName;
                r_OwnerPhoneNumber = i_OwnerPhoneNumber;
                m_VehicleState = eVehicleState.InRepair;
            }

            public enum eVehicleState
            {
                InRepair, Fixed, PaidUp
            }

            public string OwnerName
            {
                get
                {
                    return r_OwnerName;
                }
            }

            public string OwnerPhoneNumber
            {
                get
                {
                    return r_OwnerPhoneNumber;
                }
            }

            public eVehicleState VehicleState
            {
                get
                {
                    return m_VehicleState;
                }

                set
                {
                    m_VehicleState = value;
                }
            }

            public static void IsValidOwnerPhoneNumber(string i_PhoneNumberInput)
            {
                long phoneNumberInt;

                if (!long.TryParse(i_PhoneNumberInput, out phoneNumberInt))
                {
                    throw new FormatException("Invalid Input - should be numbers only");
                }

                if (phoneNumberInt < 0)
                {
                    throw new ArgumentException("Invalid phone number - should be digits only");
                }

                if (i_PhoneNumberInput.Length != 10)
                {
                    throw new ArgumentException("Invalid phone number length - should be 10 digits");
                }
            }

            public override string ToString()
            {
                StringBuilder vehicleReportString = new StringBuilder();
                vehicleReportString.Append("Owner's Name: ").AppendLine(r_OwnerName);
                vehicleReportString.Append("Owner's Phone Number: ").AppendLine(r_OwnerPhoneNumber);
                vehicleReportString.Append("Vehicle's state: ").AppendLine(m_VehicleState.ToString());

                return vehicleReportString.ToString();
            }
        }
    }
}
