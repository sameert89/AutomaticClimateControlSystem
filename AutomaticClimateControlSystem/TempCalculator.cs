using System;

namespace AutomaticClimateControlSystem
{
    internal class TempCalculator
    {
        private double previousTemperature = 20.0; 
        private int previousNumPassengers = 0; 

        public double CurrentTemperature { get; private set; }
        public int NumPassengers { get; private set; }

        public TempCalculator()
        {
 
            CurrentTemperature = previousTemperature;
            NumPassengers = previousNumPassengers;
        }

        public void CalculateNewTemperature(double currentTemperature, int numPassengers)
        {
            double temperatureDifference = currentTemperature - previousTemperature;
            int passengersDifference = numPassengers - previousNumPassengers;
            double temperatureIncrement = 0.5;
            double newTemperature = CurrentTemperature + (temperatureDifference * temperatureIncrement) + (passengersDifference * temperatureIncrement);

            previousTemperature = currentTemperature;
            previousNumPassengers = numPassengers;
        }


        private void SetNewTemperature(double newTemperature)
        {
            CurrentTemperature = newTemperature;
        }
    }
}
