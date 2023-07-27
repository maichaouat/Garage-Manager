using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public static class Factory
    {
        private static CustomerDetails m_NewCostumerData;
        private const string k_Car = "Car";
        private const string k_Motorcycle = "Motorcycle";
        private const string k_Truck = "Truck";
        public static List<string> CreateNewVehicleFirstStep(List<string> i_BasicVehicleRequirements, string i_LicenseNumber)
        {
            List<string> v_AdditionalRequirements;
            string v_TypeOfVehicle;

            v_TypeOfVehicle = i_BasicVehicleRequirements[0];
            m_NewCostumerData = new CustomerDetails();
            switch (v_TypeOfVehicle)
            {
                case k_Car:
                    m_NewCostumerData.CustomerVehicle = new Car(i_BasicVehicleRequirements[1], i_LicenseNumber);
                    break;

                case k_Motorcycle:
                    m_NewCostumerData.CustomerVehicle = new Motorcycle(i_BasicVehicleRequirements[1], i_LicenseNumber);
                    break;

                case k_Truck:
                    m_NewCostumerData.CustomerVehicle = new Truck(i_BasicVehicleRequirements[1], i_LicenseNumber);
                    break;

                default:
                    throw new FormatException("Invalid vehicle type");
            }

            m_NewCostumerData.CustomerName = i_BasicVehicleRequirements[2];
            m_NewCostumerData.CustomerPhoneNumber = i_BasicVehicleRequirements[3];
            v_AdditionalRequirements = m_NewCostumerData.CustomerVehicle.AdditionalVehicleRequirements();
            return v_AdditionalRequirements;
        }
        public static void CreateNewVehicleSecondStep(List<string> v_AdditionalVehicleRequirements, GarageManager i_Garage)
        {
            m_NewCostumerData.CustomerVehicle.BuildTheAdditionalVehicleRequirements(v_AdditionalVehicleRequirements);
            i_Garage.InsertNewCustomerData(m_NewCostumerData);
        }
    }
}
