using System;

namespace AutomaticClimateControlSystem
{
    public class ACUnit
    {
        private double _currentTemperature;

        public double CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                _currentTemperature = value;
                Console.WriteLine($"AC Unit updated. New Temperature: {_currentTemperature}");
            }
        }
    }
}
