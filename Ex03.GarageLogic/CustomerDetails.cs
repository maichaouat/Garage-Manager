
using System;

namespace Ex03.GarageLogic
{
    public enum eCarStatus { InProgress, Complited, PaidUp }
    internal class CustomerDetails
    {
        private Vehicle m_CustomerVehicle = null;
        private string m_CustomerName;
        private string m_CustomerPhoneNumber;
        private eCarStatus m_CustomerCarStatus;

        internal Vehicle CustomerVehicle
        {
            get
            {
                return m_CustomerVehicle;
            }
            set
            {
                m_CustomerVehicle = value;
            }
        }
        internal string CustomerName
        {
            get
            {
                return m_CustomerName;
            }
            set
            {
                m_CustomerName = value;
            }
        }
        internal string CustomerPhoneNumber
        {
            get
            {
                return m_CustomerPhoneNumber;
            }
            set
            {
                for (int i = 0; i < value.Length; i++) 
                {
                    if (value[i] < '0' || value[i] > '9')
                    {
                        throw new FormatException("Phone number can only include numbers type");
                    }
                }

                m_CustomerPhoneNumber = value;
            }
        }
        internal eCarStatus CustomerCarStatus
        {
            get
            {
                return m_CustomerCarStatus;
            }

            set
            {
                m_CustomerCarStatus = value;
            }
        }
    }
}
