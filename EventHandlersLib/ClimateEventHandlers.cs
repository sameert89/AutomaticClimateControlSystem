using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    public static class ClimateEventHandlers
    {
        public static double HandleTempThresholdExceedsEvent(TempCalculator _tempCalculator, object e)
        {
            var @event = e as TempThresholdExceededEvent;
            double currentTemperature = @event?.CurrentTemp ?? 25;

            return _tempCalculator.CalculateNewTemperature(currentTemperature, _tempCalculator.NumPassengers);


        }

        public static double HandleNumPassengersChangedEvent(TempCalculator _tempCalculator, object e)
        {
            var @event = e as PassengerCountChangeEvent;
            ushort numPassengers = @event?.CurrentPassengerCount ?? 2;

            return _tempCalculator.CalculateNewTemperature(_tempCalculator.CurrentTemperature, numPassengers);


        }
    }
}
