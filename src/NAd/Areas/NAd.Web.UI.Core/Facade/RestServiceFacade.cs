using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.ServiceModel;
using NAd.Querying.Host.Infrastructure.Formatters;
using Ncqrs.CommandService.Contracts;

namespace NAd.Web.UI.Core.Facade
{
    public class RestServiceFacade<T> : IRestServiceFacade<T> where T : class
    {
        private readonly ChannelFactory<ICommandWebServiceClient> _channelFactory;
        private readonly Uri _baseUri;

        //private static readonly Uri BaseAddress = new Uri("http://localhost:7777/");
        private static readonly MediaTypeFormatter[] Formatters = new[] { new NewtonsoftJsonFormatter() };


        //public string RequestMessageFormat { get; private set; }


        public RestServiceFacade(ChannelFactory<ICommandWebServiceClient> channelFactory, string baseAddress)
        {
            _channelFactory = channelFactory;
            _baseUri = new Uri(baseAddress);
        }


        //public T SingleOrDefault<T>(Expression<Func<T, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        public T GetById(string requestMessage, string id)
        {
            return GetModelRepresentationById(requestMessage, id);
        }

        //public IEnumerable<T> List<T>(Expression<Func<T, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}


        #region Send REST request helper

        private IEnumerable<T> GetModelRepresentationList(string requestMessage)
        {
            //string requestMessage = "classifieds";

            IEnumerable<T> resource = null;

            using (HttpResponseMessage response = SendRequest(requestMessage))
            {
                resource = response.Content.ReadAsAsync<IEnumerable<T>>(Formatters).Result;
            }

            return resource;
        }


        private T GetModelRepresentationById(string requestMessage, string id)
        {
            //string requestMessage = "classified/{0}";

            //T resource = null;
            var resource = default(T);

            using (HttpResponseMessage response = SendRequest(string.Format(requestMessage, id)))
            {
                resource = response.Content.ReadAsAsync<T>(Formatters).Result;
            }

            return resource;
        }


        private HttpResponseMessage SendRequest(string path)
        {
            var client = new HttpClient { BaseAddress = _baseUri };
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client.SendAsync(request).Result;
        }

        #endregion
    }
}