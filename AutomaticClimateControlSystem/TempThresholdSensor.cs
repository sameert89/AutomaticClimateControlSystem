namespace AutomaticClimateControlSystem
{
    public class TempThresholdSensor(IEventAggregator eventAggregator)
    {
        // private float thresholdTemp = tempVal;
        public float currentTemp;
        private readonly IEventAggregator eventAggregator = eventAggregator;

        public void HandleTempThresholdChange() {
            eventAggregator.Publish(new TempThresholdExceededEvent(currentTemp));
        }
    }
}
