﻿

using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            m_MaxValue= i_MaxValue;
            m_MinValue= i_MinValue;
        }
    }
}
