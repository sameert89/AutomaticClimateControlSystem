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

// adapter
IEventAggregator eventAggregator;
Adapter`(IEventAggregator eventAggregator){
    this.eventAggregator = eventAggregator;
    eventAggregator.Subscribe(PassengerCountChangeEvent,this)
    eventAggregator.Subscribe(TempThresholdExceededEvent, this)

    calculator object

    dictionary <Type, Action<object>>()


    Event Aggregator -> sent event -> Adapter -> gets type of event -> Action<object> // event object -> 