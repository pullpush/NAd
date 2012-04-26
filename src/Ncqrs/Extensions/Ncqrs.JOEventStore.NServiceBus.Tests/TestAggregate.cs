using System;
using Ncqrs.Domain;

namespace Ncqrs.JOEventStore.NServiceBus.Tests
{
    public class TestAggregate : AggregateRootMappedByConvention
    {
        private string _helloText;

        public string HelloText
        {
            get { return _helloText; }
        }

        public TestAggregate(Guid id) : base(id)
        {            
        }

        public void SayHello(string helloText)
        {
            ApplyEvent(new HelloSaidEvent(){HelloText = helloText});
        }

        private void OnHelloSaidEvent(HelloSaidEvent evnt)
        {
            _helloText = evnt.HelloText;
        }
    }
}