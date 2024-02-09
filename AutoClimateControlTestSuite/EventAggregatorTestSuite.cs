using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TemperatureThresholdSensorLib;
using PassengerCountSensorLib;
using AutomaticClimateControlSystem;
using IEventLib;
using System.Security.Cryptography.X509Certificates;

namespace AutoClimateControlTestSuite
{
    public class EventAggregatorTestFixture : IDisposable
    {
        public Mock<ITempThresholdSensor> TempSensorMock = new();
        public IEvent FakeTempEvent = new TempThresholdExceededEvent(25.0f);
        
        public Mock<IPassengerCountSensor> PassengerSensorMock = new();
        public IEvent FakePassengerEvent = new PassengerCountChangeEvent(5);
        public Mock<ISubscriber> SubscriberMock = new();
        public IEventAggregator ClimateControlEventAggregatorObj = new ClimateControlEventAggregator();

        public EventAggregatorTestFixture() {
            TempSensorMock.Setup(x => x.HandleTempThresholdChange()).Callback(() =>
            {
                ClimateControlEventAggregatorObj.Publish(FakeTempEvent);

            });
            PassengerSensorMock.Setup(x => x.HandlePassengerCountChange()).Callback(() =>
            {
                ClimateControlEventAggregatorObj.Publish(new PassengerCountChangeEvent(5));
            });
            IEvent[] events = [FakeTempEvent, FakePassengerEvent];
            SubscriberMock.Setup(x => x.SubscribeToEvents(events)).Callback(() =>
            {
                foreach(var e in events)
                {
                    ClimateControlEventAggregatorObj.Subscribe(e.GetType(), SubscriberMock.Object);
                }

            });
        }

        public void Dispose() { }

        [Fact]
        public void Test_Singleton()
        {
            // Arrange & Act
            var eventAggregatorDuplicate = new ClimateControlEventAggregator();

            // Assert
            Assert.Same(ClimateControlEventAggregatorObj, eventAggregatorDuplicate);
        }
        [Fact]
        public void Test_Publish_TempEvent()
        {
            // Arrange
            var mockSubscriber = SubscriberMock.Object;

            // Act
            ClimateControlEventAggregatorObj.Publish(FakeTempEvent);

            // Assert
            mockSubscriber.Verify(x => x.Receive(eventAggregatorFixture.FakeTempEvent), Times.Once);
        }
        [Fact]
        public void Test_Publish_PassengerEvent()
        {
            // Arrange
            var mockSubscriber = SubscriberMock.Object;

            // Act
            ClimateControlEventAggregatorObj.Publish(FakePassengerEvent);

            // Assert
            mockSubscriber.Verify(x => x.Receive(eventAggregatorFixture.FakeTempEvent), Times.Once);
        }
        [Fact]
        public void Test_Subscribe()
        {
            // Arrange
            var eventAggregatorFixture = new EventAggregatorTestFixture();
            var mockSubscriber = eventAggregatorFixture.SubscriberMock.Object;

            
            // Assert
            Assert.Contains(mockSubscriber, ClimateControlEventAggregatorObj.GetSubscribers(eventAggregatorFixture.FakeTempEvent.GetType()));
        }
    }
    
}
