using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        private const float k_InitializeEnergy = 0;
        private const int k_MaxVehicleStateMenuOptions = 3;
        private const int k_MaxFuelTypesMenuOptions = 4;
        private Garage m_Garage;

        public ConsoleUI()
        {
            m_Garage = new Garage();
        }

        public void Run()
        {
            startService();
        }

        private static int isValidInput(string i_UserInput, int i_MaxOption)
        {
            int userChoice;

            if (!int.TryParse(i_UserInput, out userChoice))
            {
                throw new FormatException("Invalid input - should be numbers only");
            }

            if (userChoice < 1 || userChoice > i_MaxOption)
            {
                throw new ValueOutOfRangeException("Invalid input", i_MaxOption, 1, string.Empty);
            }
            else
            {
                return userChoice;
            }
        }

        private void startService()
        {
            showMenu();
            string userInputString;
            int userInputInt = 0;

            do
            {
                try
                {
                    userInputString = Console.ReadLine();
                    userInputInt = isValidInput(userInputString, 9);
                    userInputChoices(userInputInt);
                }
                catch (FormatException i_FormatException)
                {
                    clearScreenAndShowMenu();
                    Console.WriteLine(i_FormatException.Message);
                }
                catch (ValueOutOfRangeException i_OutOfRangeException)
                {
                    clearScreenAndShowMenu();
                    Console.WriteLine(string.Format("{0}. Should be between {1} - {2}", i_OutOfRangeException.Message, i_OutOfRangeException.MinValue, i_OutOfRangeException.MaxValue));
                }
            }
            while (userInputInt != 9);
        }

        private void clearScreenAndShowMenu()
        {
            Console.Clear();
            showMenu();
            Console.WriteLine();
        }

        private void userInputChoices(int i_UserChoice)
        {
            Console.Clear();
            try
            {
                switch (i_UserChoice)
                {
                    case 1:
                        newVehicle();
                        break;
                    case 2:
                        displayLicensePlatesNumber();
                        break;
                    case 3:
                        changeVehicleState();
                        break;
                    case 4:
                        inflateAir();
                        break;
                    case 5:
                        refuelVehicle();
                        break;
                    case 6:
                        rechargeVehicle();
                        break;
                    case 7:
                        displayVehicleInformation();
                        break;
                    case 8:
                        displayAllClients();
                        break;
                    case 9:
                        exitProgram();
                        break;
                }
            }
            catch (ValueOutOfRangeException i_Exception)
            {
                succesMethodMenu(string.Format("{0}. Should be between {1} - {2} {3}", i_Exception.Message, i_Exception.MinValue, i_Exception.MaxValue, i_Exception.WordToAdd));
            }
            catch (Exception i_Exception)
            {
                succesMethodMenu(i_Exception.Message);
            }

            Console.Clear();
            showMenu();
        }

        private void newVehicle()
        {
            string ownerName, ownerPhoneNumber;
            Console.WriteLine("Please enter owner's name: ");
            ownerName = Console.ReadLine();
            Console.WriteLine("Please enter owner's phone number: (10 digits) ");
            ownerPhoneNumber = Console.ReadLine();

            Garage.ClientReport.IsValidOwnerPhoneNumber(ownerPhoneNumber);
            Console.Clear();
            showVehicleMenu();
            string vehicleChoice = Console.ReadLine();
            int userVehicleChoice = isValidInput(vehicleChoice, m_Garage.VehicleCreator.VehicleTypes.Count);
            VehicleCreator.VehicleCreatorListNode vehicleNode = m_Garage.VehicleCreator.VehicleTypes[userVehicleChoice - 1];
            int i = 1;
            Console.Clear();
            foreach (string currentInfoToShow in vehicleNode.ListOfVehicleInformation)
            {
                Console.Write("Please enter ");
                Console.WriteLine(currentInfoToShow);
                string userInput = Console.ReadLine();
                vehicleNode.VehicleInformation.InputCheck(i, userInput);
                i++;
            }

            m_Garage.AddClient(ownerName, ownerPhoneNumber, vehicleNode.VehicleName, vehicleNode.VehicleInformation);
            succesMethodMenu("The vehicle was added successfuly");
        }

        private void displayLicensePlatesNumber()
        {
            string userInput;
            Console.WriteLine("Please choose from the following states: ");
            Console.WriteLine("1) In repair");
            Console.WriteLine("2) Fixed");
            Console.WriteLine("3) Paid up");
            Console.WriteLine("4) All");

            userInput = Console.ReadLine();

            int stateUserChoice = isValidInput(userInput, k_MaxVehicleStateMenuOptions + 1);

            Console.Clear();

            switch (stateUserChoice)
            {
                case 1:
                    Console.WriteLine(m_Garage.ShowLicensePlateNumberByState(Garage.ClientReport.eVehicleState.InRepair));
                    break;
                case 2:
                    Console.WriteLine(m_Garage.ShowLicensePlateNumberByState(Garage.ClientReport.eVehicleState.Fixed));
                    break;
                case 3:
                    Console.WriteLine(m_Garage.ShowLicensePlateNumberByState(Garage.ClientReport.eVehicleState.PaidUp));
                    break;
                case 4:
                    Console.WriteLine(m_Garage.ShowAllLicensePlateNumbers());
                    break;
            }

            Console.WriteLine("Please press any key to continue");
            string pressToContinue = Console.ReadLine();
        }

        private void changeVehicleState()
        {
            string licensePlateInput = checkLicenseNumber();
            Console.Clear();
            Console.WriteLine("Please enter the new state of the vehicle: ");
            Console.WriteLine("1) In Repair");
            Console.WriteLine("2) Fixed");
            Console.WriteLine("3) Paid up");

            string newStateInput = Console.ReadLine();
            int newStateChoice = isValidInput(newStateInput, k_MaxVehicleStateMenuOptions);

            switch (newStateChoice)
            {
                case 1:
                    m_Garage.ChangeVehicleState(licensePlateInput, Garage.ClientReport.eVehicleState.InRepair);
                    break;
                case 2:
                    m_Garage.ChangeVehicleState(licensePlateInput, Garage.ClientReport.eVehicleState.Fixed);
                    break;
                case 3:
                    m_Garage.ChangeVehicleState(licensePlateInput, Garage.ClientReport.eVehicleState.PaidUp);
                    break;
            }

            succesMethodMenu("The vehicle's state was changed successfuly");
        }

        private void inflateAir()
        {
            string licensePlateInput = checkLicenseNumber();
            m_Garage.InflateAirToMax(licensePlateInput);
            succesMethodMenu("The vehicle's wheels were inflated successfuly");
        }

        private void refuelVehicle()
        {
            string licensePlateInput = checkLicenseNumber();
            Console.Clear();
            showFuelOptions();
            string fuelTypeInput = Console.ReadLine();
            int fuelChoice = isValidInput(fuelTypeInput, k_MaxFuelTypesMenuOptions);
            FuelEngine.eFuelType fuelType = FuelEngine.eFuelType.Octan95;
            checkFuelTypeInput(ref fuelType, fuelChoice);

            Console.Clear();
            Console.WriteLine("Please enter amount of fuel to add: (Liters)");
            string fuelToAddString = Console.ReadLine();
            float fuelToAdd = k_InitializeEnergy;
            checkValidationOfAddedEnergy(fuelToAddString, ref fuelToAdd);
            m_Garage.ReFuelVehicle(licensePlateInput, fuelType, fuelToAdd);
            succesMethodMenu("The vehicle was refueled successfuly");
        }

        private void rechargeVehicle()
        {
            string licensePlateInput = checkLicenseNumber();
            Console.Clear();
            Console.WriteLine("Please enter time to charge: (Minutes)");
            string timeToChargeString = Console.ReadLine();
            float timeToCharge = k_InitializeEnergy;
            checkValidationOfAddedEnergy(timeToChargeString, ref timeToCharge);
            m_Garage.ReChargeVehicle(licensePlateInput, timeToCharge);
            succesMethodMenu("The vehicle was charged successfuly");
        }

        private void displayVehicleInformation()
        {
            string licensePlateInput = checkLicenseNumber();
            Console.Clear();
            Console.WriteLine(m_Garage.ShowClientInformation(licensePlateInput));
            Console.WriteLine("Please press any key to continue");
            string pressToContinue = Console.ReadLine();
        }

        private void displayAllClients()
        {
            Console.Clear();
            Console.WriteLine(m_Garage.ToString());
            Console.WriteLine("Please press any key to continue");
            string pressToContinue = Console.ReadLine();
        }

        private void exitProgram()
        {
            Console.Clear();
            Console.WriteLine("Bye Bye :(");
            Environment.Exit(1);
        }

        private void succesMethodMenu(string i_Message)
        {
            Console.Clear();
            Console.WriteLine(i_Message);
            Console.WriteLine("Please press any key to continue");
            string pressToContinue = Console.ReadLine();
        }

        private string checkLicenseNumber()
        {
            Console.WriteLine("Please enter vehicle's license plate number:");
            string licensePlateInput = Console.ReadLine();
            Vehicle.IsLicensePlateNumberValid(licensePlateInput);

            if (!m_Garage.IsClientInGarage(licensePlateInput))
            {
                throw new ArgumentException("License plate number not exist");
            }

            return licensePlateInput;
        }

        private void showMenu()
        {
            Console.WriteLine("Welcome to the garage!");
            Console.WriteLine();
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine();
            Console.WriteLine("1) Put a new vehicle in the garage");
            Console.WriteLine("2) Display license plates number");
            Console.WriteLine("3) Change vehicle state");
            Console.WriteLine("4) Inflate air in wheels to max");
            Console.WriteLine("5) Refuel vehicle");
            Console.WriteLine("6) Recharge vehicle");
            Console.WriteLine("7) Display vehicle information");
            Console.WriteLine("8) Display all clients");
            Console.WriteLine("9) Exit");
        }

        private void showFuelOptions()
        {
            Console.WriteLine("Please enter fuel type: ");
            Console.WriteLine("1) Soler");
            Console.WriteLine("2) Octan95");
            Console.WriteLine("3) Octan96");
            Console.WriteLine("4) Octan98");
        }

        private void showVehicleMenu()
        {
            Console.WriteLine("Which vehicle do you want to put in the garage? ");
            Console.WriteLine();
            int i = 1;

            foreach (VehicleCreator.VehicleCreatorListNode vehicleInfo in m_Garage.VehicleCreator.VehicleTypes)
            {
                Console.WriteLine("{0}) {1}", i, vehicleInfo.VehicleName);
                i++;
            }
        }

        private void checkFuelTypeInput(ref FuelEngine.eFuelType i_FuelType, int i_FuelChoice)
        {
            switch (i_FuelChoice)
            {
                case 1:
                    i_FuelType = FuelEngine.eFuelType.Soler;
                    break;
                case 2:
                    i_FuelType = FuelEngine.eFuelType.Octan95;
                    break;
                case 3:
                    i_FuelType = FuelEngine.eFuelType.Octan96;
                    break;
                case 4:
                    i_FuelType = FuelEngine.eFuelType.Octan98;
                    break;
            }
        }

        private void checkValidationOfAddedEnergy(string i_EnergyToaddString, ref float i_EnergyToAdd)
        {
            if (!float.TryParse(i_EnergyToaddString, out i_EnergyToAdd))
            {
                throw new FormatException("Invalid input - should be numbers only");
            }
        }
    }
}
