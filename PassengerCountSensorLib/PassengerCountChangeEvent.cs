using IEventLib;
namespace AutomaticClimateControlSystem
{
    public class PassengerCountChangeEvent(ushort currentPassengerCount) : IEvent
    {
        public ushort CurrentPassengerCount = currentPassengerCount;
    }
}