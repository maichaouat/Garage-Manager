using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal enum eLicenseType { A1, A2, AA, B1 }

    internal class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private uint m_EngineCapcity;
        private const float k_MaxBatteryTime = (float)2.6;
        private const uint k_MaxAirPressure = 31;
        private const float k_FualTankCapacity = (float)6.4;
        private const uint k_WheelsNumber = 2;

        internal Motorcycle(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber, new Wheel[k_WheelsNumber], null)
        {
            base.MaxTierPressure = k_MaxAirPressure;
        }
        public override string ToString()
        {
            string v_Info = string.Format("\nMotorcycle\n---\nLicense type: {0}\nEngine capacity: {1} cc\n", m_LicenseType, m_EngineCapcity) + base.ToString();
            return v_Info;
        }
        public override List<string> AdditionalVehicleRequirements()
        {
            List<string> v_Requirements = new List<string>();

            v_Requirements = base.AdditionalVehicleRequirements();
            v_Requirements.Add("Is the vehicle is electric (Yes or No)");
            v_Requirements.Add("for electric vehicle: remaining battery time (minutes)\n" +
                             "  for none electric vehicle: current fuel amount (liters)");
            v_Requirements.Add("Licence type (A1, A2, AA, B1)");
            v_Requirements.Add("Engine capacity in cc");

            return v_Requirements;
        }
        public override void BuildTheAdditionalVehicleRequirements(List<string> i_Requirements)
        {
            bool v_Valid = true;

            /// Lexicon index set of requirements:
            /// 0 - Current tiers air pressure
            /// 1 - Tiers manufactor name
            /// 2 - Is the vehicle is electric
            /// 3 - for electric vehicle: remaining battery time| for none electric vehicle: current fuel amount
            /// 4 - License type (A1, A2, AA, B1)
            /// 5 - Engine capacity in cc

            if(i_Requirements[2].ToLower() == "yes")
            {
                base.Engine = new ElectricEngine(float.Parse(i_Requirements[3]) / 60, k_MaxBatteryTime);
                base.PercentageOfEnrgyLeft = base.Engine.PrecentageEnergyLeft();
            }
            else if (i_Requirements[2].ToLower() == "no")
            {
                base.Engine = new CombustionEngine(float.Parse(i_Requirements[3]), k_FualTankCapacity, ePowerType.Octan98);
                base.PercentageOfEnrgyLeft = base.Engine.PrecentageEnergyLeft();
            }
            else
            {
                throw new ArgumentException("Invalid Input, Please enter next time Yes or No");
            }

            for (int i = 0; i < base.Wheels.Length; i++)
            {
                base.Wheels[i] = new Wheel(i_Requirements[1], float.Parse(i_Requirements[0]), k_MaxAirPressure);
            }

            if (Enum.TryParse(i_Requirements[4], out m_LicenseType) != v_Valid)
            {
                throw new ArgumentException("Invalid license type");
            }

            if (uint.TryParse(i_Requirements[5], out m_EngineCapcity) != v_Valid)
            {
                throw new ArgumentException("Invalid engine capacity");
            }
        }
    }
}