using System;

using NAd.Common;
using NAd.Ncqrs.Events;
using NAd.Querying.Core.Services;
using NAd.Querying.Core.ExceptionHandling;

using Ncqrs;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing.Snapshotting;
//using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;

//using FluentValidation.Attributes;

namespace NAd.Ncqrs.Domain
{
    /// <summary>
    /// </summary>
    /// <remarks>
    /// WRIRE side.
    /// All business logic is captured within these objects and is not used for querying.
    /// Aggregate roots contain the actual business logic and are responsible for guarding their own invariants. 
    /// State changes on aggregate roots cause domain events to occur. 
    /// This sequence of domain events represents all the changes that has been made.  
    /// This pattern is called event sourcing.
    /// </remarks>
    //[DynamicSnapshot]
    //[Validator(typeof(CreateNewClassifiedValidator))]
    public class Classified : AggregateRootMappedByConvention
    {
        private string name;
        private string description;
        private DateTime createdDate;


        private Classified()
        {
            // Need a default ctor for Ncqrs.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <remarks>
        /// WRIRE side.
        /// This instance will be initialized with the <see cref="BasicGuidGenerator"/>.
        /// </remarks>
        public Classified(Guid id, string name, string description)
            : base(id)
        {
            var clock = NcqrsEnvironment.Get<IClock>();

            var service = NcqrsEnvironment.Get<IClassifiedService>();
            if (service.CheckNotUniqueClassifiedName(name))
                throw new ApplicationErrorException(ServiceError.NameCodeOrNumberIsNotUnique);


            //var violations = new ViolationCollector();

            //if (title.IsNullOrEmpty())
            //{
            //    violations.Add(new Violation(CookbookRule.RecipeTitleIsRequired)
            //    { 
            //        {"Property", "Title"}
            //    });
            //}

            //if (description.IsNullOrEmpty())
            //{
            //    violations.Add(new Violation(CookbookRule.RecipeDescriptionIsRequired)
            //    {
            //        {"Property", "Description"}
            //    });
            //}

            //violations.ThrowIfAny();

            // Publish event via the event bus. 
            // Apply a NewClassifiedCreated event that reflects the
            // creation of this instance. The state of this
            // instance will be update in the handler of 
            // this event (the OnNewClassifiedCreated method).
            ApplyEvent(new NewClassifiedCreated
            {
                Id = id,
                Name = name,
                Description = description,
                CreationDate = clock.UtcNow()
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="newDescription"></param>
        public void ChangeClassifiedDescription(string newName, string newDescription)
        {
            // Apply a ClassifiedDescriptionChanged event that reflects
            // the occurence of a text change. The state of this
            // instance will be updated in the handler of 
            // this event (the OnClassifiedDescriptionChanged method).
            ApplyEvent(new ClassifiedDescriptionChanged
            {
                NewName = newName,
                NewDescription = newDescription
            });
        }


        /// <summary>
        /// Event handler for the NewClassifiedCreated event.
        /// </summary>
        /// <param name="e"></param>
        protected void OnNewClassifiedCreated(NewClassifiedCreated e)
        {
            name = e.Name;
            description = e.Description;
            createdDate = e.CreationDate;
        }


        /// <summary>
        /// Event handler for the ClassifiedDescriptionChanged event. This method 
        /// is automaticly wired as event handler based on convension.
        /// </summary>
        /// <param name="e"></param>
        protected void OnClassifiedDescriptionChanged(ClassifiedDescriptionChanged e)
        {
            name = e.NewName;
            description = e.NewDescription;
        }
    }
}
