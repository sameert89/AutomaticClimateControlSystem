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
                {typeof(TempThresholdExceededEvent), ClimateEventHandlers.HandleTempThresholdExceedsEvent },
                {typeof(PassengerCountChangeEvent), ClimateEventHandlers.HandleNumPassengersChangedEvent }
        
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

    }

}

