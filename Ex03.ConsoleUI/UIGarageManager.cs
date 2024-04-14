using System;
using System.Collections.Generic;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
   
    internal class UIGarageManager
    {
        private const uint k_OptionsPossibleInMenu = 6;
        private const char k_AddNewVehicle = '1';
        private const char k_GetLicenceNumbersInGarage = '2';
        private const char k_ChangeVehicleStatus = '3';
        private const char k_ReFuel = '4';
        private const char k_InflateWheelsToMax = '5';
        private const char k_VehicleData = '6';
        private const char k_Quit = 'q';
        private GarageManager m_Garage = new GarageManager();

        internal void MenuManagement()
        {
            char v_Option;
            string v_NewLine = Environment.NewLine;

            openMessage();
            printMenu();
            v_Option = getVaildOption();
            while (v_Option != k_Quit)
            {
                try
                {
                    switch (v_Option)
                    {
                       
                        case k_AddNewVehicle:
                            Console.WriteLine("┌────────────────────────────┐");
                            Console.WriteLine("│  Add New Vehicle Selected  │");
                            Console.WriteLine("└────────────────────────────┘" + v_NewLine);
                         
                            addNewCustomer();
                            break;

                        case k_GetLicenceNumbersInGarage:
                            Console.WriteLine("┌────────────────────────────────────────┐");
                            Console.WriteLine("│ Get Licence Numbers In Garage Selected │");
                            Console.WriteLine("└────────────────────────────────────────┘" + v_NewLine);
                            getLicenceNumbersInGarage();
                            break;

                        case k_ChangeVehicleStatus:
                            Console.WriteLine("┌─────────────────────────────────┐");
                            Console.WriteLine("│  Change Vehicle Status Selected │");
                            Console.WriteLine("└─────────────────────────────────┘" + v_NewLine);
                            changeVehicleStatus();
                            break;

                        case k_ReFuel:
                            Console.WriteLine("┌─────────────────────┐");
                            Console.WriteLine("│   ReFuel Selected   │");
                            Console.WriteLine("└─────────────────────┘" + v_NewLine);
                            reFuel();
                            break;

                        case k_InflateWheelsToMax:
                            Console.WriteLine("┌────────────────────────────────┐");
                            Console.WriteLine("│ Inflate Wheels To Max Selected │");
                            Console.WriteLine("└────────────────────────────────┘" + v_NewLine);
                            inflateWheelsToMax();
                            break;

                        case k_VehicleData:
                            Console.WriteLine("┌─────────────────────────┐");
                            Console.WriteLine("│  Vehicle Data Selected  │");
                            Console.WriteLine("└─────────────────────────┘" + v_NewLine);
                            vehicleData();
                            break;


                        default:
                            Console.WriteLine("Invalid option." + v_NewLine);
                            break;
                    }
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine("\n\nError: " + i_Exception.Message);
                    Console.WriteLine("Your last action canceled." + v_NewLine + "The system will return you to the Garage Menu");
                }

                printMenu();
                v_Option = getVaildOption();
            }
        }
        private char getVaildOption()
        {
            int v_UserChoice;
            string v_Option;
            char? v_Result = null;
            bool v_Continue = true;

            while (v_Continue)
            {
                v_Option = Console.ReadLine();
       
                if(v_Option == "q" || (int.TryParse(v_Option, out v_UserChoice) && v_UserChoice >= 1 && v_UserChoice <= k_OptionsPossibleInMenu))
                {
                    v_Continue = false;
                    v_Result = char.Parse(v_Option);
                }
                else
                {
                    Console.WriteLine("The argument is not valid, Try again");
                    Console.Write("-> ");
                }
            }

            Console.WriteLine();
            return (char)v_Result;
        }
        private void openMessage()
        {
            Console.WriteLine("Welcome to the Garage!\n");
        }
        private void printMenu()
        {
            Console.WriteLine();
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Garage Menu                                                                ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  Please select an option from the menu below:                               ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Add a new vehicle to the garage                                         ║");
            Console.WriteLine("║  2. Get a list of license numbers in the garage based on car status         ║");
            Console.WriteLine("║  3. Change the status of a vehicle in the garage                            ║");;
            Console.WriteLine("║  4. Refuel a vehicle in the garage                                          ║");
            Console.WriteLine("║  5. Inflate the wheels of a vehicle in the garage to their maximum capacity ║");
            Console.WriteLine("║  6. Retrieve data about a vehicle in the garage                             ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  Please enter the number corresponding to the                               ║");
            Console.WriteLine("║  desired option or 'q' to quit:                                             ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════╝");
            Console.Write("-> ");

        }
        private void getLicenceNumbersInGarage()
        {
            string v_Answer;
            List<string> v_LicenceNumbersList;

            Console.WriteLine("Would you like to filter by car status? (Yes or No)");
            Console.Write("-> ");
            v_Answer = Console.ReadLine();
            while (v_Answer != "Yes" &&  v_Answer != "No")
            {
                Console.WriteLine("Invalid input format, please try again");
                Console.Write("-> ");
                v_Answer = Console.ReadLine();
            }

            if (v_Answer == "Yes")
            {
                Console.WriteLine("Insert car status (InProgress, Complited, PaidUp)");
                Console.Write("-> ");
                v_Answer = Console.ReadLine();
                v_LicenceNumbersList =  m_Garage.GetLicenceNumbersInGarage(v_Answer);
            }
            else
            {
                v_LicenceNumbersList =  m_Garage.GetLicenceNumbersInGarage();
            }

            Console.WriteLine("\nLicense numbers in garage:");
            printListToConsole(v_LicenceNumbersList);
            Console.WriteLine();
        }
        private void printListToConsole(List<string> i_List)
        {

            if(i_List.Count == 0)
            {
                Console.WriteLine("- None -");
            }
            foreach(var i in i_List)
            {
                Console.WriteLine("- " + i);
            }
        }
        private void changeVehicleStatus()
        {
            string v_Input;
            string[] v_InputParts;

            Console.WriteLine("Please write licence number and the new status (InProgress, Complited, PaidUp) separated by spaces");
            Console.Write("-> ");
            v_Input = Console.ReadLine();
            v_InputParts = v_Input.Split(' ');
            while (v_InputParts.Length != 2)
            {
                Console.WriteLine("Invalid input format");
                Console.WriteLine("\"Please write licence number and the new status (InProgress, Complited, PaidUp) separated by spaces");
                Console.Write("-> ");
                v_Input = Console.ReadLine();
                v_InputParts = v_Input.Split(' ');
            }

            m_Garage.ChangeVehicleStatus(v_InputParts[0], v_InputParts[1]);
        }
        private void reFuel()
        {
            string v_Input;
            string[] v_InputParts;
            Console.WriteLine("Please enter licence number, amount to fill and power type (for combustion engine only), all separated by spaces");
            Console.Write("-> ");
            v_Input = Console.ReadLine();
            v_InputParts = v_Input.Split(' ');
            while (v_InputParts.Length != 3 && v_InputParts.Length != 2)
            {
                Console.WriteLine("Invalid input format, please try again");
                Console.Write("-> ");
                v_Input = Console.ReadLine();
                v_InputParts = v_Input.Split(' ');
            }

            if (v_InputParts.Length == 3)
            {
                m_Garage.ReFuel(v_InputParts[0], v_InputParts[1], v_InputParts[2]);
            }
            else
            {
                m_Garage.ReFuel(v_InputParts[0], v_InputParts[1]);
            }
        }
        private void inflateWheelsToMax()
        {
            string v_Input;

            Console.WriteLine("Enter liecnce number");
            Console.Write("-> ");
            v_Input = Console.ReadLine();
            m_Garage.InflateWheelsToMax(v_Input);
        }
        private void vehicleData()
        {
            string v_Input;

            Console.WriteLine("Enter liecnce number");
            Console.Write("-> ");
            v_Input = Console.ReadLine();
            Console.WriteLine(m_Garage.CustomerData(v_Input));
        }
        private void addNewCustomer()
        {
            List<string> v_RequiredFields, v_AdditionalRequiredFields;
            string v_LicenceNumber;
            bool v_AddNewVehicle;

            Console.WriteLine(" Please enter:");
            Console.WriteLine("- liecnce number");
            v_LicenceNumber = getNotEmptyInput();
            v_AddNewVehicle = m_Garage.AddNewVehicle(v_LicenceNumber, out v_RequiredFields);
            if (v_AddNewVehicle)
            {
                for (int i = 0; i < v_RequiredFields.Count; i++)
                {
                    Console.WriteLine("- " + v_RequiredFields[i]);
                    v_RequiredFields[i] = getNotEmptyInput();
                }

                v_AdditionalRequiredFields = Factory.CreateNewVehicleFirstStep(v_RequiredFields, v_LicenceNumber);
                for (int i = 0; i < v_AdditionalRequiredFields.Count; i++)
                {
                    Console.WriteLine("- " + v_AdditionalRequiredFields[i]);
                    v_AdditionalRequiredFields[i] = getNotEmptyInput();
                }

                Factory.CreateNewVehicleSecondStep(v_AdditionalRequiredFields, m_Garage);
            }
            else
            {
                for (int i = 0; i < v_RequiredFields.Count; i++)
                {
                    Console.WriteLine(v_RequiredFields[i]);
                }
            }
        }
        private string getNotEmptyInput()
        {
            string v_Input;

            Console.Write("-> ");
            v_Input = Console.ReadLine();
            
            while(v_Input.Length == 0) 
            {
                Console.WriteLine("Empty input unsupported, please try again");
                Console.Write("-> ");
                v_Input = Console.ReadLine();
            }

            return v_Input;
        }
    }
}
