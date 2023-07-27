using System;


namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        private float m_RemainingBatteryTime;
        private float m_MaximumBatteryTime;

        internal ElectricEngine(float i_RemainingBatteryTime, float i_MaximumBatteryTime)
        {
            if(i_RemainingBatteryTime < 0 || i_RemainingBatteryTime > i_MaximumBatteryTime)
            {
                throw new ValueOutOfRangeException("Amount to charge", i_MaximumBatteryTime, 0);
            }

            m_RemainingBatteryTime = i_RemainingBatteryTime;
            m_MaximumBatteryTime = i_MaximumBatteryTime;
        }
        internal override void ChargeUp(float i_ChargingBatteryTime, ePowerType i_FuelType)
        {
            if (i_ChargingBatteryTime + m_RemainingBatteryTime > m_MaximumBatteryTime || i_ChargingBatteryTime < 0)
            {
                throw new ValueOutOfRangeException("Amount to charge", (m_MaximumBatteryTime - m_RemainingBatteryTime) * 60, 0);
            }
            
            if(i_FuelType != ePowerType.Electric)
            {
                throw new ArgumentException("Invalid power type");
            }

            m_RemainingBatteryTime += i_ChargingBatteryTime;
        }
        internal override float PrecentageEnergyLeft()
        {
            return (float)((m_RemainingBatteryTime / m_MaximumBatteryTime) * 100);
        }
        public override string ToString()
        {
            return string.Format("\nEngine:\n-------\nEngine type: Electric engine\nRemaining battery time: {0}\nMaximum battery time: {1}\n", m_RemainingBatteryTime, m_MaximumBatteryTime);
        }
    }
}
