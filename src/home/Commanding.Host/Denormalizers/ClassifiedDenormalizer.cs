
using System.Linq;

using NAd.Events;
using NAd.Querying.Core.DataAccess;

using Ncqrs.Eventing.ServiceModel.Bus;


namespace NAd.Commanding.Host.Denormalizers
{
    public class ClassifiedDenormalizer : IEventHandler<NewClassifiedCreated>//, IEventHandler<NoteTextChanged>
    {
        public void Handle(IPublishedEvent<NewClassifiedCreated> evnt)
        {
            using (var ctx = new QueryContext())
            {
                var classified = new Classified
                {
                    Id = evnt.Payload.Id,
                    CreatedDate = evnt.Payload.CreationDate,
                    Name = evnt.Payload.Name,
                    Description = evnt.Payload.Description
                };

                ctx.Add(classified);
            }

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