using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal enum eColor { White, Black, Yellow, Red }
    internal enum eNumOfDoors { Two = 2, Three, Four, Five }
    
    internal class Car : Vehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;
        private const float k_MaxBatteryTime = (float)5.2;
        private const uint k_MaxAirPressure = 33;
        private const float k_FualTankCapacity = 46;
        private const uint k_WheelsNumber = 5;

        internal Car(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber, new Wheel[k_WheelsNumber], null)
        {
            base.MaxTierPressure = k_MaxAirPressure;
        }
        public override List<string> AdditionalVehicleRequirements()
        {
            List<string> v_Requirements = new List<string>();

            v_Requirements = base.AdditionalVehicleRequirements();
            v_Requirements.Add("Is the vehicle is electric (Yes or No)");
            v_Requirements.Add("for electric vehicle: remaining battery time in minutes (Maximun Battery Time is " + k_MaxBatteryTime.ToString() + ")\n"+
                             "  for none electric vehicle: current fuel amount in liters (Fual Tank Capacity is "+k_FualTankCapacity+")");
            v_Requirements.Add("Car color (White, Black, Yellow, Red)");
            v_Requirements.Add("Number of doors");   

            return v_Requirements;
        }
        public override void BuildTheAdditionalVehicleRequirements(List<string> i_Requirements)
        {
            bool v_Valid = true;
            float v_FuelAmount, v_BatteryTime;

            /// Lexicon index set of requirements:
            /// 0 - Current tiers air pressure
            /// 1 - Tiers manufactor name
            /// 2 - Is the vehicle is electric
            /// 3 - for electric vehicle: remaining battery time| for none electric vehicle: current fuel amount
            /// 4 - Car color
            /// 5 - Number of doors

            if (i_Requirements[2].ToLower() == "yes")
            {
                if (float.TryParse(i_Requirements[3], out v_BatteryTime) == !v_Valid)
                {
                    throw new FormatException("Buttery time must be a number!");
                }

                base.Engine = new ElectricEngine(v_BatteryTime / 60, k_MaxBatteryTime);
                base.PercentageOfEnrgyLeft = base.Engine.PrecentageEnergyLeft();
            }
            else if(i_Requirements[2].ToLower() == "no")
            {
                if (float.TryParse(i_Requirements[3], out v_FuelAmount) == !v_Valid)
                {
                    throw new FormatException("Fuel amount must be a number!");
                }

                base.Engine = new CombustionEngine(v_FuelAmount, k_FualTankCapacity, ePowerType.Octan95);
                base.PercentageOfEnrgyLeft = base.Engine.PrecentageEnergyLeft();
            }
            else
            {
                throw new ArgumentException("One of the arguments is not valid, Try again");
            }

            for (int i = 0; i < base.Wheels.Length; i++) 
            {
                base.Wheels[i] = new Wheel(i_Requirements[1], float.Parse(i_Requirements[0]), k_MaxAirPressure);
            }

            if(Enum.TryParse(i_Requirements[4], out m_Color) != v_Valid)
            {
                throw new ArgumentException("One of the arguments is not valid, Try again");
            }

            if (Enum.TryParse(i_Requirements[5], out m_NumOfDoors) != v_Valid)
            {
                throw new ArgumentException("One of the arguments is not valid, Try again");
            }
        }
        public override string ToString()
        {
            string v_Info = string.Format("\nCar:\n----\nColor: {0}\nNumber of doors: {1}\n", m_Color, m_NumOfDoors) + base.ToString();
            return v_Info;
        }
    }
}
