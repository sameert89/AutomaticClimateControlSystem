using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    public sealed class ClimateControlEventAggregator : IEventAggregator
    {
        // singleton
        private static readonly ClimateControlEventAggregator instance = new();
        public static ClimateControlEventAggregator Instance => instance;

        private readonly Dictionary<Type, List<ISubscriber>> subscribers = [];

        public void Publish(object @event)
        {
            var eventType = @event.GetType();
            if (subscribers.TryGetValue(eventType, out List<ISubscriber>? value))
            {
                foreach(var subscriber in value)
                {
                    subscriber.OnEventHandler(@event);
                }
            }
        }

        public void Subscribe(Type eventType, ISubscriber subscriber)
        { 
            if (!subscribers.TryGetValue(eventType, out List<ISubscriber>? value))
            {
                value = [];
                subscribers[eventType] = value;
            }

            value.Add(subscriber);
        }
    }
}
