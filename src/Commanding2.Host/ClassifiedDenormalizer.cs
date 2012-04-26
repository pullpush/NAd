
using System.Linq;

using NAd.Events;
using NAd.Querying.Core.DataAccess;

using Ncqrs.Eventing.ServiceModel.Bus;

namespace Commanding2.Host
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
        }
    }
}