using System;

namespace Ex03.GarageLogic
{
   
    internal class CombustionEngine : Engine
    {
        private ePowerType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_FuelTankCapacity;

        internal CombustionEngine(float i_CurrentFuelAmount, float i_FuelTankCapacity, ePowerType i_FuelType)
        {
            if (i_CurrentFuelAmount < 0 || i_CurrentFuelAmount > i_FuelTankCapacity)
            {
                throw new ValueOutOfRangeException("Amount to fuel", i_FuelTankCapacity, 0);
            }

            m_FuelType = i_FuelType;
            m_CurrentFuelAmount = i_CurrentFuelAmount;
            m_FuelTankCapacity = i_FuelTankCapacity;
        }
        // $G$ CSS-999 (0) Good with the override.
        internal override void ChargeUp(float i_AmountToRefuel, ePowerType i_FuelType)
        {
            if(i_FuelType != m_FuelType)
            {
                throw new ArgumentException("Invalid fuel type");
            }
            
            if(i_AmountToRefuel + m_CurrentFuelAmount > m_FuelTankCapacity || i_AmountToRefuel < 0)
            {
                throw new ValueOutOfRangeException("Amount to fuel", m_FuelTankCapacity - m_CurrentFuelAmount, 0);
            }

            m_CurrentFuelAmount += i_AmountToRefuel;
        }
        internal override float PrecentageEnergyLeft()
        {
            return (float)((m_CurrentFuelAmount/ m_FuelTankCapacity) * 100);
        }
        public override string ToString()
        {
            return string.Format("\nEngine:\n-------\nEngine type: Combustion engine\nFuel type: {0}\nCurrent fuel amount: {1}\nFuel tank capacity: {2}\n", m_FuelType, m_CurrentFuelAmount, m_FuelTankCapacity);
        }
    }
}
