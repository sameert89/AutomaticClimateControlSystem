using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomaticClimateControlSystem;
using Moq;
namespace AutoClimateControlTestSuite
{
    public class AdapterTests
    {
        [Fact]
        public void OnEventHandler_HandlesTempThresholdExceededEvent_CallsNotifyNewTemperature()
        {
            // Arrange
            var mockEventAggregator = new Mock<IEventAggregator>();
            var mockECU = new Mock<IECU>();
            var adapter = new Adapter(mockEventAggregator.Object, mockECU.Object);
            var tempThresholdExceededEvent = new TempThresholdExceededEvent(35.0f);

            // Act
            adapter.OnEventHandler(tempThresholdExceededEvent);

            // Assert
            mockECU.Verify(x => x.NotifyNewTemperature(It.IsAny<double>()), Times.Once);
        }

        [Fact]
        public void OnEventHandler_HandlesPassengerCountChangeEvent_CallsNotifyNewTemperature()
        {
            // Arrange
            var mockEventAggregator = new Mock<IEventAggregator>();
            var mockECU = new Mock<IECU>();
            var adapter = new Adapter(mockEventAggregator.Object, mockECU.Object);
            var passengerCountChangeEvent = new PassengerCountChangeEvent(5);

            // Act
            adapter.OnEventHandler(passengerCountChangeEvent);

            // Assert
            mockECU.Verify(x => x.NotifyNewTemperature(It.IsAny<double>()), Times.Once);
        }

        
    }
}
