using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;


using NAd.Framework.Persistence.Abstractions.Model;

using Ncqrs.CommandService;
using Ncqrs.CommandService.Contracts;

using NAd.Querying.Host.Resources.Classifieds;

namespace NAd.Web.UI.Core.Facade
{
    public class PageServiceFacade : RestServiceFacade<IPageModel>, IPageServiceFacade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageServiceFacade" /> class.
        /// </summary>
        /// <param name="channelFactory"></param>
        /// <param name="baseAddress"></param>
        public PageServiceFacade(ChannelFactory<ICommandWebServiceClient> channelFactory, string baseAddress)
            : base(channelFactory, baseAddress) {
        }


        /// <summary>
        /// Get a page by the url !!!!!!!!!!!!!!1
        /// write service and a web service to be called from here. think why we need to write a service method.
        /// perhaps we can use the queryable repository directly instead.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public IPageModel GetPageByUrl(string url)
        {
            return GetById("classified/{0}/pagebyurl", url);
            //return _documentSession.Query<T, Document_ByUrl>()
            //    .Customize(x => x.WaitForNonStaleResultsAsOfLastWrite())
            //    .Where(x => x.Metadata.Url == url)
            //    .FirstOrDefault();
        }


        //public void CreateClassified(string name, string description)
        //{
        //    var command = new CreateNewClassified(Guid.NewGuid(), name, description);

        //    ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //                      client.Execute(new ExecuteRequest(command)));
        //}

        //public void EditClassified(Guid id, string name, string description)
        //{
        //    var command = new ChangeClassifiedDescription(id, name, description);

        //    ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
        //                      client.Execute(new ExecuteRequest(command)));
        //}

        /// <summary>
        /// Returns a complete list of cargos stored in the system.
        /// </summary>
        /// <returns>A collection of cargo DTOs.</returns>
        //public IList<CargoRoutingDTO> ListAllCargos()
        //{
        //    return _cargoRepository.FindAll().Select(x => _cargoRoutingAssembler.ToDTO(x)).ToList();
        //}

    }
}