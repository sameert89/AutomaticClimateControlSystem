using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerCountSensorLib
{
    public interface IPassengerCountSensor
    {
        public void HandlePassengerCountChange();
    }
}
