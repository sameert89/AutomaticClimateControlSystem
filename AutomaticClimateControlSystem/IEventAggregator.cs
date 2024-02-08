using AutomaticClimateControlSystem;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    public interface IEventAggregator
    {
        public void Publish(object @event);
        public void Subscribe(Type eventType, ISubscriber subscriber);
    }
}