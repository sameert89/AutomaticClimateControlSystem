using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    public class TempThresholdExceededEvent(float currentTemp, float thresholdTemp)
    {
        public float currentTemp = currentTemp;
        public float thresholdTemp = thresholdTemp;
    }
}
