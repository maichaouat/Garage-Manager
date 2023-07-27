using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenceNumber;
        private float m_PercentageOfEnrgyLeft;
        private Wheel[] m_Wheels;
        private float m_MaxTierPressure;
        private Engine m_Engine;

        internal string LicenseNumber
        {
            get
            {
                return m_LicenceNumber;
            }
        }
        protected Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
            }
        }
        protected Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }
        protected float MaxTierPressure
        {
            get
            {
                return m_MaxTierPressure;
            }
            set
            {
                m_MaxTierPressure = value;
            }
        }
        protected float PercentageOfEnrgyLeft
        {
            get 
            { 
                return m_PercentageOfEnrgyLeft; 
            }
            set 
            { 
                m_PercentageOfEnrgyLeft = value; 
            }
        }
        protected Vehicle(string i_ModelName, string i_LicenseNumber ,Wheel[] i_Wheels, Engine i_Engine)
        {
            m_ModelName = i_ModelName;
            m_LicenceNumber = i_LicenseNumber;
            m_Wheels = i_Wheels;
            m_Engine = i_Engine;
        }
        internal void InflatWheels(float i_AirPressureToAdd)
        {
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                m_Wheels[i].InflatWheel(i_AirPressureToAdd);
            }
        }
        internal void InflatWheelsToMax()
        {
            for(int i = 0; i < m_Wheels.Length; i++)
            {
                m_Wheels[i].InflateWheelToMax();
            }
        }
        internal void ChargeUp(float i_AmountToCharge, ePowerType i_PowerType)
        {
            Engine.ChargeUp(i_AmountToCharge, i_PowerType);
            m_PercentageOfEnrgyLeft = Engine.PrecentageEnergyLeft();
        }
        public virtual List<string> AdditionalVehicleRequirements()
        {
            List<string> v_Requirements = new List<string>();

            v_Requirements.Add("Current tiers air pressure (Maximun Air Pressure is "+m_MaxTierPressure+")" );
            v_Requirements.Add("Tiers manufactor name");
            return v_Requirements;
        }
        public abstract void BuildTheAdditionalVehicleRequirements(List<string> i_Requirements);
        public override string ToString()
        {
            string v_Info = string.Format("Model: {0}\nLicense number: {1}\nPercentage of enrgy left: {2}%\n", m_ModelName, m_LicenceNumber, m_PercentageOfEnrgyLeft);

            v_Info = v_Info + m_Wheels[1].ToString() + m_Engine.ToString();
            return v_Info;
        }
        public override bool Equals(object obj)
        {
            bool v_IsEpual;
            Vehicle v_VehicleToCompareTo = obj as Vehicle;

            if(v_VehicleToCompareTo == null)
            {
                v_IsEpual = false;
            }
            else
            {
                v_IsEpual = v_VehicleToCompareTo.LicenseNumber == m_LicenceNumber;
            }

            return v_IsEpual;
        }
        public override int GetHashCode()
        {
            return int.Parse(this.LicenseNumber);
        }
        public static bool operator ==(Vehicle v_Vehicle1, Vehicle v_Vehicle2)
        {
            return v_Vehicle1.Equals(v_Vehicle2);
        }
        public static bool operator !=(Vehicle v_Vehicle1, Vehicle v_Vehicle2)
        {
            return !(v_Vehicle1 == v_Vehicle2);
        }
    }
}
