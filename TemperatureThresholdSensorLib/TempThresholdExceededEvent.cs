using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEventLib;

namespace AutomaticClimateControlSystem
{
    public class TempThresholdExceededEvent(float currentTemp) : IEvent
    {
        public float CurrentTemp = currentTemp;
        // public float thresholdTemp = thresholdTemp;
    }
}
