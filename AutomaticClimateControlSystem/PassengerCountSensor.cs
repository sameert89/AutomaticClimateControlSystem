using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    public class PassengerCountSensor(IEventAggregator eventAggregator, ushort currentPassengerCount)
    {
        private readonly IEventAggregator eventAggregator = eventAggregator;
        public void HandlePassengerCountChange()
        {
            eventAggregator.Publish(new PassengerCountChangeEvent(currentPassengerCount));
        }
    }
}
