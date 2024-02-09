using AutomaticClimateControlSystem;

namespace AutoClimateControlTestSuite
{
    public class TempCalculatorTestsFixture : IDisposable
    {
        private TempCalculator tempCalculator;

        public TempCalculatorTestsFixture()
        {
            tempCalculator = new TempCalculator();
        }

        public void Dispose()
        {
            
        }

        [Fact]
        public void DefaultInitializationTest()
        {
            Assert.Equal(20.0, tempCalculator.CurrentTemperature);
            Assert.Equal(0, tempCalculator.NumPassengers);
        }

        [Fact]
        public void CalculateNewTemperature_UpdatesCurrentTemperatureAndReturnsCorrectTemperature()
        {
            double newTemperature = 25.0;
            int numPassengers = 0;
            double expectedNewTemperature = 22.5;
            double actualNewTemperature = tempCalculator.CalculateNewTemperature(newTemperature, numPassengers);
            Assert.Equal(expectedNewTemperature, actualNewTemperature);
        }

        [Fact]
        public void CalculateNewTemperature_UpdatesNumPassengersAndReturnsCorrectTemperature()
        {
            double initialTemperature = 20.0;
            int newNumPassengers = 5;
            double expectedNewTemperature = 22.5;
            double actualNewTemperature = tempCalculator.CalculateNewTemperature(initialTemperature, newNumPassengers);
            Assert.Equal(expectedNewTemperature, actualNewTemperature);
        }

        [Fact]
        public void CalculateNewTemperature_UpdatesTemperatureAndPassengerCount_ReturnsCorrectTemperature()
        {
            double newTemperature = 20;
            int newNumPassengers = 0;
            double expectedNewTemperature = 20;
            double actualNewTemperature = tempCalculator.CalculateNewTemperature(newTemperature, newNumPassengers);
            Assert.Equal(expectedNewTemperature, actualNewTemperature);
        }

        [Fact]
        public void CalculateNewTemperature_WithNegativeTemperatureDifference_ReturnsCorrectTemperature()
        {
            double newTemperature = 15;
            int newNumPassengers = 0;
            double expectedNewTemperature = 17.5;
            double actualNewTemperature = tempCalculator.CalculateNewTemperature(newTemperature, newNumPassengers);
            Assert.Equal(expectedNewTemperature, actualNewTemperature);
        }
    }
}