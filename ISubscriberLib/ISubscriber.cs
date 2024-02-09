using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEventLib;

namespace AutomaticClimateControlSystem
{
    public interface ISubscriber
    {
        public void SubscribeToEvents(IEvent[] eventsToSubscribe);
        public void OnEventHandler(object @event);
    }
}
