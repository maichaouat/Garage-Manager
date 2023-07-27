using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsTransportingDangerousMaterials;
        private float m_TrailerVolum;
        private const uint k_MaxAirPressure = 26;
        private const float k_FualTankCapacity = 135;
        private const uint k_WheelsNumber = 14;

        internal Truck(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber, new Wheel[k_WheelsNumber], null) 
        {
            base.MaxTierPressure = k_MaxAirPressure;
        }
        public override string ToString()
        {
            string v_Info = string.Format("\nTruck\n---\nIs transporting dangerous materials: {0}\nTrailer Volum: {1} cc\n", m_IsTransportingDangerousMaterials.ToString(), m_TrailerVolum) + base.ToString();
            return v_Info;
        }
        public override List<string> AdditionalVehicleRequirements()
        {
            List<string> v_Requirements = new List<string>();

            v_Requirements = base.AdditionalVehicleRequirements();
            v_Requirements.Add("current fuel amount (liters)");
            v_Requirements.Add("Is transporting dangerous materials (Yes or No)");
            v_Requirements.Add("Trailer volum");

            return v_Requirements;
        }
        public override void BuildTheAdditionalVehicleRequirements(List<string> i_Requirements)
        {
            /// Lexicon index set of requirements:
            /// 0 - Current tiers air pressure
            /// 1 - Tiers manufactor name
            /// 2 - current fuel amount (liters)
            /// 3 - Is transporting dangerous materials (Yes or No)
            /// 4 - Trailer volum

            base.Engine = new CombustionEngine(float.Parse(i_Requirements[2]), k_FualTankCapacity, ePowerType.Soler);
            base.PercentageOfEnrgyLeft = base.Engine.PrecentageEnergyLeft();

            for (int i = 0; i < base.Wheels.Length; i++)
            {
                base.Wheels[i] = new Wheel(i_Requirements[1], float.Parse(i_Requirements[0]), k_MaxAirPressure);
            }

            if (i_Requirements[3].ToLower() == "yes" || i_Requirements[3].ToLower() == "no" )
            {
                m_IsTransportingDangerousMaterials = i_Requirements[3] == "Yes";
            }
            else
            {
                throw new ArgumentException("Invalid Input, Please enter next time Yes or No");
            }

            if (!float.TryParse(i_Requirements[4] , out m_TrailerVolum) || m_TrailerVolum < 0 )
            {
                throw new ArgumentException("Invalid Trailer volum");
            }

        }
    }
}
