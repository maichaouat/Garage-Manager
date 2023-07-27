using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private string m_Message;

        public override string Message
        {
            get
            {
                return m_Message;
            }
        }
        public ValueOutOfRangeException(string i_TypeOutOfRandge, float i_MaxValue, float i_MinValue)
        {
            m_Message = string.Format("{0} out of range. Valid range is ({1} - {2})", i_TypeOutOfRandge, i_MinValue, i_MaxValue);
        }
    }
}
