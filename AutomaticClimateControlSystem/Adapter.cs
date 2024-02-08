using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    public class Adapter : ISubscriber
    {
        private TempCalculator _tempCalculator;
        private IECU _ecu;
        private readonly Dictionary<Type, Func<TempCalculator, object, double>> EventHandlerFunctions;

        public Adapter(IEventAggregator eventAggregator, IECU ecu)
        {
            this._tempCalculator = new TempCalculator();
            this._ecu = ecu;

            EventHandlerFunctions = new Dictionary<Type, Func<TempCalculator, object, double>>()
            {
                {typeof(TempThresholdExceededEvent), HandleTempThresholdExceedsEvent },
                {typeof(PassengerCountChangeEvent), HandleNumPassengersChangedEvent }
        
            };
            eventAggregator.Subscribe(typeof(TempThresholdExceededEvent), this);
            eventAggregator.Subscribe(typeof(PassengerCountChangeEvent), this);

        }

        public void OnEventHandler(object @event)
        {
            var eventType = @event.GetType();
            
            if (EventHandlerFunctions.ContainsKey(eventType))
            {
                double newTemp = EventHandlerFunctions[eventType].Invoke(_tempCalculator, @event);
                _ecu.NotifyNewTemperature(newTemp);
            }

        }

        public double HandleTempThresholdExceedsEvent(TempCalculator _tempCalculator, object e)
        {
            var @event = e as TempThresholdExceededEvent;
            double currentTemperature = @event?.CurrentTemp ?? 25;

            return _tempCalculator.CalculateNewTemperature(currentTemperature, _tempCalculator.NumPassengers);
            
            
        }

        public double HandleNumPassengersChangedEvent(TempCalculator _tempCalculator, object e)
        {
            var @event = e as PassengerCountChangeEvent;
            ushort numPassengers = @event?.CurrentPassengerCount ?? 2;

            return _tempCalculator.CalculateNewTemperature(_tempCalculator.CurrentTemperature, numPassengers);


        }


    }

}

