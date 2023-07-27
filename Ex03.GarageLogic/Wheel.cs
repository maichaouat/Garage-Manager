using System;

namespace Ex03.GarageLogic
{
    internal struct Wheel
    {
        private string m_ManufactorName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        internal Wheel(string i_ManufactorName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            if (i_CurrentAirPressure < 0 || i_CurrentAirPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("Tyres air pressure", i_MaxAirPressure, 0);
            }

            m_ManufactorName = i_ManufactorName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }
        internal void InflatWheel(float i_AirPressureToAdd)
        {
            if (i_AirPressureToAdd + m_CurrentAirPressure > m_MaxAirPressure || i_AirPressureToAdd < 0)
            {
                throw new ValueOutOfRangeException("Tyres air pressure", m_MaxAirPressure - m_CurrentAirPressure, 0);
            }

            m_CurrentAirPressure += i_AirPressureToAdd;
        }
        internal void InflateWheelToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }
        public override string ToString()
        {
            return string.Format("\nWheel:\n------\nManufactor: {0}\nCurrent air pressure: {1}\nMax air pressure: {2}\n", m_ManufactorName, m_CurrentAirPressure, m_MaxAirPressure);
        }
    }
}
