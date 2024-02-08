namespace AutomaticClimateControlSystem
{
    public class TempThresholdSensor(IEventAggregator eventAggregator)
    {
    public class TempThresholdSensor(IEventAggregator eventAggregator, float tempVal)
    {
        private float thresholdTemp = tempVal;

        public void HandleTempThresholdChange() {
            eventAggregator.Publish(new TempThresholdExceededEvent(currentTemp));
        }
    }
}
