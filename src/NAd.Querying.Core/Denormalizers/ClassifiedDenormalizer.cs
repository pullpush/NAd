using System;
//using System.Linq;

using NAd.Ncqrs.Events;
using NAd.Querying.Core.Domain;
using NAd.Querying.Core.Persistency;
using NAd.Querying.Core.Common;
using NAd.Querying.Core.Services;


using Ncqrs;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Commanding.ServiceModel;

using Autofac;

namespace NAd.Querying.Core.Denormalizers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// READ side.
    /// There are different event handlers subscribed to the events bus. 
    /// The most common one are denormalizers. 
    /// These event handlers take events and makes changes to the read model based on them.
    /// </remarks>
    public class ClassifiedDenormalizer : IEventHandler<NewClassifiedCreated>, 
                                          IEventHandler<ClassifiedDescriptionChanged>
    {
        //Generate generic factories with Autofac
        //http://peterspattern.com/generate-generic-factories-with-autofac/
        //private static readonly Func<NAdUnitOfWork> unitOfWorkFactory;
        //private static IClassifiedService classifiedService;
        //private readonly IClassifiedService classifiedService;

        //public ClassifiedDenormalizer(Func<NAdUnitOfWork> unitOfWorkFactory)
        //{
        //    this.unitOfWorkFactory = unitOfWorkFactory;
        //}
        //static ClassifiedDenormalizer()
        //{
        //    //var classifiedService = NcqrsEnvironment.Get<IClassifiedService>();
        //    //classifiedService = Ioc.Global.Resolve<IClassifiedService>();
        //    //unitOfWorkFactory = Ioc.Global.Resolve<Func<NAdUnitOfWork>>();
        //}

        //public ClassifiedDenormalizer(IClassifiedService classifiedService)
        //{
        //    this.classifiedService = classifiedService;
        //}
        //public ClassifiedDenormalizer()
        //{
        //    this.classifiedService = NcqrsEnvironment.Get<IClassifiedService>();
        //}

        public void Handle(IPublishedEvent<ClassifiedDescriptionChanged> evnt)
        {
            var classifiedService = NcqrsEnvironment.Get<IClassifiedService>();

            var classified = classifiedService.GetById(evnt.Payload.ClassifiedId);

            if (classified == null) return;

            classified.Name = evnt.Payload.NewName;
            classified.Description = evnt.Payload.NewDescription;

            classifiedService.Save(classified);
        }

        public void Handle(IPublishedEvent<NewClassifiedCreated> evnt)
        {
            var classifiedService = NcqrsEnvironment.Get<IClassifiedService>();

            var classified = new Classified
            {
                Id = evnt.Payload.Id,
                CreatedDate = evnt.Payload.CreationDate,
                Name = evnt.Payload.Name,
                Description = evnt.Payload.Description
            };

            classifiedService.Save(classified);

            //var unitOfWorkFactory = NcqrsEnvironment.Get<NAdUnitOfWorkFactory>();
            //var container = Ioc.LocalContainer;
            
            //using (var uow = unitOfWorkFactory.Create())
            //using (var uow = unitOfWorkFactory())
            //using (var uow = Ioc.Global.Resolve<Func<NAdUnitOfWork>>()())
            //{
            //    var classified = new Classified
            //    {
            //        Id = evnt.Payload.Id,
            //        CreatedDate = evnt.Payload.CreationDate,
            //        Name = evnt.Payload.Name,
            //        Description = evnt.Payload.Description
            //    };

            //    uow.Classifieds.Add(classified);
            //    //it works without it --
            //    //uow.SubmitChanges();
            //}


            //AI: this was last working version before big NH factory redesign change
            //using (var ctx = new QueryContext())
            //{
            //    var classified = new Classified
            //    {
            //        Id = evnt.Payload.Id,
            //        CreatedDate = evnt.Payload.CreationDate,
            //        Name = evnt.Payload.Name,
            //        Description = evnt.Payload.Description
            //    };

            //    ctx.Add(classified);
            //}

            //using (var context = new ReadModelContainer())
            //{
            //    var existing = context.NoteItemSet.SingleOrDefault(x => x.Id == evnt.Payload.NoteId);
            //    if (existing != null)
            //    {
            //        return;                    
            //    }

            //    var newItem = new NoteItem
            //    {
            //        Id = evnt.Payload.NoteId,
            //        Text = evnt.Payload.Text,
            //        CreationDate = evnt.Payload.CreationDate
            //    };

            //    context.NoteItemSet.AddObject(newItem);
            //    context.SaveChanges();
            //}
        }

        //public void Handle(IPublishedEvent<NoteTextChanged> evnt)
        //{
        //    using (var context = new ReadModelContainer())
        //    {
        //        var itemToUpdate = context.NoteItemSet.Single(item => item.Id == evnt.EventSourceId);
        //        itemToUpdate.Text = evnt.Payload.NewText;

        //        context.SaveChanges();
        //    }
        //}
    }
}