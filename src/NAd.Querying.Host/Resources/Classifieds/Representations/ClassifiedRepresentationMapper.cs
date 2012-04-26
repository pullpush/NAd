
using System.Collections.Generic;
using System.Linq;
using NAd.Framework.Domain;

//using NAd.Querying.Core.Domain;

namespace NAd.Querying.Host.Resources.Classifieds.Representations
{
    public static class ClassifiedRepresentationMapper
    {
        public static ClassifiedRepresentation Map(Classified classified)
        {
            return new ClassifiedRepresentation
                       {
                           Id = classified.Id,
                           Description = classified.Description,
                           Name = classified.Name,
                           //Location = classified.Location,
                           //Items = classified.Items.Select(i => new classifiedItemRepresentation
                           //                                    {
                           //                                        Name = i.Product.Name,
                           //                                        Preferences = i.Preferences.ToDictionary(p => p.Key, p => p.Value),
                           //                                        Quantity = i.Quantity
                           //                                    }).ToList(),
                           //Links = GetLinks(classified).ToList()   
                       };
            
        }

        //public static IEnumerable<Link> GetLinks(Classified classified)
        //{
        //    var get = Link.FromRelativeUri("docs/classified-get.htm", "classified/{classifiedId}", new { classifiedId = classified.Id });
        //    var update = Link.FromRelativeUri("docs/classified-update.htm", "classified/{classifiedId}", new { classifiedId = classified.Id });
        //    var cancel = Link.FromRelativeUri("docs/classified-cancel.htm", "classified/{classifiedId}", new { classifiedId = classified.Id });
        //    var pay = Link.FromRelativeUri("docs/classified-pay.htm", "classified/{classifiedId}/payment", new { classifiedId = classified.Id });
        //    var receipt = Link.FromRelativeUri("docs/receipt-coffee.htm", "classified/ready/{classifiedId}", new { classifiedId = classified.Id });
        //    switch (classified.Status)
        //    {
        //        case classifiedStatus.Unpaid:
        //            yield return get;
        //            yield return update;
        //            yield return cancel;
        //            yield return pay;
        //            break;
        //        case classifiedStatus.Paid:
        //        case classifiedStatus.Delivered:
        //            yield return get;
        //            break;
        //        case classifiedStatus.Ready:
        //            yield return receipt;
        //            break;
        //        case classifiedStatus.Canceled:
        //            yield break;
        //        default:
        //            yield break;
        //    }
        //}
    }
}