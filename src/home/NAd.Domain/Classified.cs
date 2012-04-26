using System;

using NAd.Events;

using Ncqrs;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing.Snapshotting;
//using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;

namespace NAd.Domain
{
    //[DynamicSnapshot]
    public class Classified : AggregateRootMappedByConvention
    {
        private string name;
        private string description;
        private DateTime createdDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <remarks>
        /// This instance will be initialized with the <see cref="BasicGuidGenerator"/>.
        /// </remarks>
        public Classified(Guid id, string name, string description)
        {
            var clock = NcqrsEnvironment.Get<IClock>();

            ApplyEvent(new NewClassifiedCreated
            {
                Id = id,
                Name = name,
                Description = description,
                CreationDate = clock.UtcNow()
            });
        }

        protected void OnTweetPosted(NewClassifiedCreated e)
        {
            name = e.Name;
            description = e.Description;
            createdDate = e.CreationDate;
        }
    }
}
