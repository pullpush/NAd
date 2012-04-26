using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

using NAd.Ncqrs.Commands;
using NAd.Querying.Core.Domain;
using NAd.Querying.Host.Infrastructure.Formatters;
using NAd.Querying.Host.Resources.Classifieds.Representations;
using NAd.UI.Commanding;
using NAd.UI.ViewModels;

using Ncqrs.CommandService;
using Ncqrs.CommandService.Contracts;

using NAd.Querying.Host.Resources.Classifieds;

namespace NAd.UI.Facade
{
    public class ClassifiedServiceFacade
    {
        //private readonly ClassifiedResourceHandler _classifiedResourceHandler;
        //private readonly ChannelFactory<ICommandWebServiceClient> _channelFactory;
        private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        //REST service base url
        private static readonly Uri BaseAddress = new Uri("http://localhost:7777/");
        private static readonly MediaTypeFormatter[] Formatters = new[] { new NewtonsoftJsonFormatter() };

        static ClassifiedServiceFacade()
        {
            _channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");

            //Mapping for AutoMapper
            AutoMapper.Mapper.CreateMap<ClassifiedRepresentation, ClassifiedViewModel>();
        }

        public ClassifiedServiceFacade()
            //ClassifiedResourceHandler classifiedResourceHandler
            //ChannelFactory<ICommandWebServiceClient> channelFactory
        {
            //this._classifiedResourceHandler = classifiedResourceHandler;
            //this._channelFactory = channelFactory;
        }



        public void CreateClassified(string name, string description)
        {
            var command = new CreateNewClassified (Guid.NewGuid(), name, description);

            ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                              client.Execute(new ExecuteRequest(command)));

            //var command = new CreateNewClassifiedCommand { Name = name, Description = description };
            //var client = new NAdCommandServiceClient();
            //client.Execute(command);
        }

        public void EditClassified(Guid id, string name, string description)
        {
            var command = new ChangeClassifiedDescription(id, name, description);

            ChannelHelper.Use(_channelFactory.CreateChannel(), (client) =>
                              client.Execute(new ExecuteRequest(command)));
        }



        public ClassifiedViewModel GetClassifiedById(string id)
        {
            var classifiedModel = new ClassifiedViewModel();
            var classifiedRepresentation = GetClassifiedRepresentationById(id);

            //AI: For simple mapping between model objects, you can use ModelCopier but for complex scenarios, 
            //I highly recommend to use AutoMapper for mapping between model objects.
            //ModelCopier.CopyModel(classifiedRepresentation, classifiedModel);
            AutoMapper.Mapper.Map(classifiedRepresentation, classifiedModel);

            return classifiedModel;
        }

        /// <summary>
        /// Returns a complete list of cargos stored in the system.
        /// </summary>
        /// <returns>A collection of cargo DTOs.</returns>
        //public IList<CargoRoutingDTO> ListAllCargos()
        //{
        //    return _cargoRepository.FindAll().Select(x => _cargoRoutingAssembler.ToDTO(x)).ToList();
        //}



        #region Send REST request helper


        public IEnumerable<ClassifiedViewModel> GetAllClassifiedRepresentations()
        {
            string requestMessage = "classifieds";

            IEnumerable<ClassifiedViewModel> resource = null;

            using (HttpResponseMessage response = SendRequest(requestMessage))
            {
                resource = response.Content.ReadAsAsync<IEnumerable<ClassifiedViewModel>>(Formatters).Result;
            }

            return resource;
        }
        

        private ClassifiedRepresentation GetClassifiedRepresentationById(string id)
        {
            string requestMessage = "classified/{0}";

            ClassifiedRepresentation resource = null;

            using (HttpResponseMessage response = SendRequest(string.Format(requestMessage, id)))
            {
                resource = response.Content.ReadAsAsync<ClassifiedRepresentation>(Formatters).Result;
            }

            return resource;
        }

        private HttpResponseMessage SendRequest(string path)
        {
            var client = new HttpClient { BaseAddress = BaseAddress };
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client.SendAsync(request).Result;
        }

        #endregion
    }
}