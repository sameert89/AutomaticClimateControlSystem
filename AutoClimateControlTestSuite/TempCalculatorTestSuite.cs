using AutomaticClimateControlSystem;

namespace AutoClimateControlTestSuite
{

    public class TempCalculatorTestsFixture : IDisposable
    {
        
        public TempCalculator TempCalculator { get; private set; }

        public TempCalculatorTestsFixture()
        {
            TempCalculator = new TempCalculator();
        }

        public void Dispose()
        {

        }
    }
     public class TempCalculatorTestSuite(TempCalculatorTestsFixture fixture) : IClassFixture<TempCalculatorTestsFixture> 
    {
        private readonly TempCalculatorTestsFixture _fixture = fixture;
        [Fact]
        public void DefaultInitializationTest()
        {
            Assert.Equal(20.0, _fixture.TempCalculator.CurrentTemperature);
            Assert.Equal(0, _fixture.TempCalculator.NumPassengers);
        }

        [Fact]
        public void CalculateNewTemperature_UpdatesCurrentTemperatureAndReturnsCorrectTemperature()
        {
            double newTemperature = 25.0;
            int numPassengers = 0;
            double expectedNewTemperature = 22.5;
            double actualNewTemperature = _fixture.TempCalculator.CalculateNewTemperature(newTemperature, numPassengers);
            Assert.Equal(expectedNewTemperature, actualNewTemperature);
        }

        [Fact]
        public void CalculateNewTemperature_UpdatesNumPassengersAndReturnsCorrectTemperature()
        {
            double initialTemperature = 20.0;
            int newNumPassengers = 5;
            double expectedNewTemperature = 22.5;
            double actualNewTemperature = _fixture.TempCalculator.CalculateNewTemperature(initialTemperature, newNumPassengers);
            Assert.Equal(expectedNewTemperature, actualNewTemperature);
        }

        [Fact]
        public void CalculateNewTemperature_UpdatesTemperatureAndPassengerCount_ReturnsCorrectTemperature()
        {
            double newTemperature = 20;
            int newNumPassengers = 0;
            double expectedNewTemperature = 20;
            double actualNewTemperature = _fixture.TempCalculator.CalculateNewTemperature(newTemperature, newNumPassengers);
            Assert.Equal(expectedNewTemperature, actualNewTemperature);
        }

        [Fact]
        public void CalculateNewTemperature_WithNegativeTemperatureDifference_ReturnsCorrectTemperature()
        {
            double newTemperature = 15;
            int newNumPassengers = 0;
            double expectedNewTemperature = 17.5;
            double actualNewTemperature = _fixture.TempCalculator.CalculateNewTemperature(newTemperature, newNumPassengers);
            Assert.Equal(expectedNewTemperature, actualNewTemperature);
        }
    }
}