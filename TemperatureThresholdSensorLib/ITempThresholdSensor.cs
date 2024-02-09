using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureThresholdSensorLib
{
    public interface ITempThresholdSensor
    {
        public void HandleTempThresholdChange();
    }
}
