using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    internal class Adapter
    {
        private TempCalculator _tempCalculator = null;
        private IECU _ecu = null;

        public Adapter(TempCalculator tempCalculator, IEventAggregator eventAggregator, IECU ecu)
        {
            this._tempCalculator = tempCalculator;
            this._ecu = ecu;
            eventAggregator.TempThresholdExceededEvent += HandleTempThresholdExceedsEvent;
            eventAggregator.NumPassengersChangedEvent += HandleNumPassengersChangedEvent;
        }

        public void HandleTempThresholdExceedsEvent(object sender, EventArgs e)
        {
            double currentTemperature = /* Get current temperature from the event */;
            _tempCalculator.CalculateNewTemperature(currentTemperature, _tempCalculator.NumPassengers);

            NotifyECU();
        }

        public void HandleNumPassengersChangedEvent(object sender, EventArgs e)
        {
            int numPassengers = /* Get the new number of passengers from the event */;
            _tempCalculator.CalculateNewTemperature(_tempCalculator.CurrentTemperature, numPassengers);

            
            NotifyECU();
        }

        private void NotifyECU()
        {
            // Notify the ECU through the interface
            _ecu.NotifyNewTemperature(_tempCalculator.CurrentTemperature);
        }
    }
}
