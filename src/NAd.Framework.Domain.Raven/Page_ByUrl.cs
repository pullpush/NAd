
using System.Linq;
using NAd.Framework.Persistence.Abstractions.Model;
using Raven.Client.Indexes;

namespace NAd.Framework.Domain.Raven
{
    public class Page_ByUrl : AbstractIndexCreationTask<IPageModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Page_ByUrl"/> class.
        /// </summary>
        public Page_ByUrl()
        {
            Map = classifieds => from classified in classifieds
                               select new
                                          {
                                              Metadata_Url = classified.Metadata.Url
                                          };
        }
    }
}
