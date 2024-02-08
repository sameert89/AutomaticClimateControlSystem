using System;

namespace AutomaticClimateControlSystem
{
    public class ECU : IECU
    {
        private ACUnit _acUnit;

        public ECU(ACUnit acUnit)
        {
            _acUnit = acUnit;
        }

        public void NotifyNewTemperature(double newTemperature)
        {
            _acUnit.CurrentTemperature = newTemperature;
            
        }
    }
}
