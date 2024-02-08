namespace AutomaticClimateControlSystem
{
    public class TempThresholdSensor(IEventAggregator eventAggregator, float tempVal)
    {
        private float thresholdTemp = tempVal;
        private float currentTemp;
        public void SetCurrentTemp(float temp)
        {
            currentTemp = temp;
            HandleTempThresholdChange();
        }
        public void HandleTempThresholdChange()
        {
            if (thresholdTemp != currentTemp)
            {
                eventAggregator.Publish(new TempThresholdExceededEvent(currentTemp));
            }
        }
    }
}
