using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    public class TempThresholdExceededEvent(float currentTemp)
    {
        public float CurrentTemp = currentTemp;
        // public float thresholdTemp = thresholdTemp;
    }
}
