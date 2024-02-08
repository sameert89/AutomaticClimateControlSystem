namespace AutomaticClimateControlSystem
{
    public class PassengerCountChangeEvent(ushort currentPassengerCount)
    {
        public ushort CurrentPassengerCount = currentPassengerCount;
    }
}