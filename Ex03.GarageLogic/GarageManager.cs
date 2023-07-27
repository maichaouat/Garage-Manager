 using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, CustomerDetails> m_AllDataInTheGarage = new Dictionary<string, CustomerDetails> { };

        public bool AddNewVehicle(string i_LicenseNumber, out List<string> o_ReturnedMessages)
        {
            bool v_FuncResult = true;
            
            o_ReturnedMessages = new List<string>();
            if (m_AllDataInTheGarage.ContainsKey(i_LicenseNumber))
            {
                m_AllDataInTheGarage[i_LicenseNumber].CustomerCarStatus = eCarStatus.InProgress;
                o_ReturnedMessages.Add("\nThe Vehicle is already in the garage\nVehicle status changed to inprogress");
                v_FuncResult = false;
            }
            else
            {
                allCustomerRequirements(ref o_ReturnedMessages);
            }

            return v_FuncResult;
        }
        private void allCustomerRequirements(ref List<string> io_CustomerRequirements) 
        {
            io_CustomerRequirements.Add("Vehicle type (Car, Motorcycle or Truck)");
            io_CustomerRequirements.Add("Model name");
            io_CustomerRequirements.Add("Owner name");
            io_CustomerRequirements.Add("Owner phone number (Type just numbers)");
        }
        internal void InsertNewCustomerData(CustomerDetails i_NewCustomerData)
        {
            i_NewCustomerData.CustomerCarStatus = eCarStatus.InProgress;
            m_AllDataInTheGarage.Add(i_NewCustomerData.CustomerVehicle.LicenseNumber, i_NewCustomerData);
        }
        public List<string> GetLicenceNumbersInGarage(string i_CarStatus = null)
        {
            eCarStatus v_IsValidCarStatus;
            List<string> v_LicenseNumbers = new List<string>();
            bool v_IsNotValid = false;

            if(i_CarStatus != null && Enum.TryParse(i_CarStatus, out v_IsValidCarStatus) == v_IsNotValid)
            {
                throw new FormatException("Invalid status");
            }

            if(m_AllDataInTheGarage.Count == 0)
            {
                v_LicenseNumbers.Add("There is no vehicels in the garage");
            }
            else
            {
                foreach (var v_Vehicle in m_AllDataInTheGarage)
                {
                    if (i_CarStatus == null || v_Vehicle.Value.CustomerCarStatus == (eCarStatus)Enum.Parse(typeof(eCarStatus), i_CarStatus))
                    {
                        v_LicenseNumbers.Add(v_Vehicle.Key);
                    }
                }
            }

            return v_LicenseNumbers;
        }
        public void ChangeVehicleStatus(string i_LicenseNumber, string i_NewStatus)
        {
            eCarStatus v_CarStatus;
            bool v_NotValid = false;

            if (Enum.TryParse(i_NewStatus, out v_CarStatus) == v_NotValid)
            {
                throw new FormatException("Invalid status");
            }

            if (m_AllDataInTheGarage.ContainsKey(i_LicenseNumber) == v_NotValid)
            {
                throw new FormatException("Invalid license number");
            }

            m_AllDataInTheGarage[i_LicenseNumber].CustomerCarStatus = v_CarStatus;
        }
        public void ReFuel(string i_LicenseNumber, string i_AmountToFill, string i_PowerType = "Electric")
        {
            float v_AmountToFill;
            ePowerType v_PowerType;
            bool v_IsNotValid = false;

            if (Enum.TryParse(i_PowerType, out v_PowerType) == v_IsNotValid)
            {
                throw new FormatException("Invalid power type");
            }

            if (m_AllDataInTheGarage.ContainsKey(i_LicenseNumber) == v_IsNotValid)
            {
                throw new FormatException("Invalid license number");
            }

            if (float.TryParse(i_AmountToFill, out v_AmountToFill) == v_IsNotValid)
            {
                throw new FormatException("Invalid amount to fill");
            }

            if (i_PowerType == "Electric")
            {
                //transfer minutes to hours
                v_AmountToFill = float.Parse(i_AmountToFill) / 60;
            }

            m_AllDataInTheGarage[i_LicenseNumber].CustomerVehicle.ChargeUp(v_AmountToFill, v_PowerType);
        }
        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            bool v_IsNotValid = false;

            if (m_AllDataInTheGarage.ContainsKey(i_LicenseNumber) == v_IsNotValid)
            {
                throw new FormatException("Invalid license number");
            }

            m_AllDataInTheGarage[i_LicenseNumber].CustomerVehicle.InflatWheelsToMax();
        }
        public string CustomerData(string i_LicenseNumber)
        {
            string v_AllCustomerData;
            bool v_IsNotValid = false;
            CustomerDetails v_CurrCustomerToShow;

            if (m_AllDataInTheGarage.ContainsKey(i_LicenseNumber) == v_IsNotValid)
            {
                throw new FormatException("Invalid license number");
            }

            v_CurrCustomerToShow = m_AllDataInTheGarage[i_LicenseNumber];
            v_AllCustomerData = string.Format("\nOwner:\n------\nName: {0}\nPhone number: {1}\nStatus in garage: {2}\n", v_CurrCustomerToShow.CustomerName, v_CurrCustomerToShow.CustomerPhoneNumber, v_CurrCustomerToShow.CustomerCarStatus);
            v_AllCustomerData += v_CurrCustomerToShow.CustomerVehicle.ToString();
            return v_AllCustomerData;
        }
    }
}
