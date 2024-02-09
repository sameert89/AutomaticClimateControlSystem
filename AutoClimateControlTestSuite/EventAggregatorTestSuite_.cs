using Moq;
using AutomaticClimateControlSystem;
using IEventLib;


namespace AutoClimateControlTestSuite
{
    public class EventAggregatorTestFixture_ : IDisposable
    {
        // Publish : FakeEvent
        public readonly IEvent fakeEvent;
        // Subscribe: FakeEvent, FakeSubsciber
        public readonly Mock<ISubscriber> fakeSubscriber;
        // SingleTon same or not : Event aggregator which we are testing
        public readonly IEventAggregator eventAggregator;

        public EventAggregatorTestFixture_()
        {
            fakeEvent = new TempThresholdExceededEvent(35.0f);
            fakeSubscriber = new Mock<ISubscriber>();
            eventAggregator = new ClimateControlEventAggregator();
        }
        public void Dispose() { 
            GC.SuppressFinalize(this);
        }
    }
    public class EventAggregatorTestSuite(EventAggregatorTestFixture_ fixture) : IClassFixture<EventAggregatorTestFixture_>
    {
        private readonly EventAggregatorTestFixture_ _fixture = fixture;

        [Fact]
        public void Test_Singleton()
        {
            // Arrange & Act
            var eventAggregatorDuplicate = new ClimateControlEventAggregator();

            // Assert
            Assert.Same(_fixture.eventAggregator, eventAggregatorDuplicate);
        }

        [Fact]
        public void Test_Subscribe()
        {
            // Arrange
            // Act
            _fixture.eventAggregator.Subscribe(_fixture.fakeEvent.GetType(), _fixture.fakeSubscriber.Object);
            // Assert
            Assert.True(_fixture.eventAggregator.GetSubscribers().ContainsKey(_fixture.fakeEvent.GetType()) && _fixture.eventAggregator.GetSubscribers()[_fixture.fakeEvent.GetType()].Count != 0);
        }

        [Fact]
        public void Test_Publish()
        {
            // Arrange
            if (!_fixture.eventAggregator.GetSubscribers().ContainsKey(_fixture.fakeEvent.GetType()))
            {
                _fixture.eventAggregator.Subscribe(_fixture.fakeEvent.GetType(), _fixture.fakeSubscriber.Object);
            }
            // Act
            _fixture.eventAggregator.Publish(_fixture.fakeEvent);
            // Assert
            _fixture.fakeSubscriber.Verify(x => x.OnEventHandler(_fixture.fakeEvent), Times.Once);
            // If the above method fails it will throw and exception which causes this test to fail
        }
    }
}
    


