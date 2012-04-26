using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

using NAd.Querying.Core.DataAccess;

namespace NAd.Querying
{
    /// <summary>
    /// Exposes our data model as a REST-based service.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    //[ServiceContract]
    //[ExceptionShieldingBehavior]
    public class QueryService : DataService<QueryContext>
    {
        /// <summary>
        /// Initializes the service.
        /// </summary>
        /// <param name="config">The config.</param>
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.UseVerboseErrors = true;
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        [WebGet(UriTemplate = "?partialName={partialName}&partialDescription={partialDescription}")]
        public IQueryable<Classified> FindClassifieds(string partialName, string partialDescription)
        {
            return from classified in CurrentDataSource.Classifieds
                   where (partialName.Length == 0 || (classified.Name.Contains(partialName)))
                   where (partialDescription.Length == 0 || (classified.Description.Contains(partialDescription)))
                   select classified;
        }
    }
}
