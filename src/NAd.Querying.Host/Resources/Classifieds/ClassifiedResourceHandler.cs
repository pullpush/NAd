
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.ServiceModel.Web;
using Microsoft.ApplicationServer.Http;

//using RestBucks.Data;
//using RestBucks.Domain;
using NAd.Framework.Domain;
using NAd.Framework.Services;
using NAd.Querying.Host.Infrastructure;
using NAd.Querying.Host.Infrastructure.Linking;
using NAd.Querying.Host.Resources.Classifieds.Representations;
//using NAd.Querying.Core.Services;

namespace NAd.Querying.Host.Resources.Classifieds

{
    [ServiceContract, WithUriPrefix("classified")]
    public class ClassifiedResourceHandler
    {
        //private readonly IRepository<classified> classifiedRepository;
        private readonly IClassifiedService classifiedService;
        private readonly IResourceLinker linker;

        public ClassifiedResourceHandler(IClassifiedService classifiedService, IResourceLinker linker)
        {
            this.classifiedService = classifiedService;
            this.linker = linker;
        }

        [WebGet(UriTemplate = "{id}")]
        public HttpResponseMessage Get(string id, HttpRequestMessage request)
        {
            Guid classifiedId = Guid.Empty;
            Guid.TryParse(id, out classifiedId);

            var classified = classifiedService.Get(classifiedId);
            if (classified == null) return Responses.NotFound();
            
            //if(classified.Status == classifiedStatus.Canceled)
            //{
            //    return Responses.MovedTo(linker.GetUri<CanceledclassifiedHandler>(rh => rh.GetCanceled(0), new {classifiedId}));
            //}

            if (request.IsNotModified(classified)) return Responses.NotModified(maxAge: TimeSpan.FromSeconds(10));

            var response = Responses.WithContent(ClassifiedRepresentationMapper.Map(classified))
                                    .AddCacheHeaders(classified);
            
            return response;
        }


        [WebGet(UriTemplate = "{url}/pagebyurl")]
        public HttpResponseMessage GetByUrl(string url, HttpRequestMessage request)
        {
            var classified = classifiedService.GetByUrl(url);

            if (classified == null) return Responses.NotFound();

            if (request.IsNotModified(classified)) return Responses.NotModified(maxAge: TimeSpan.FromSeconds(10));

            var response = Responses.WithContent(ClassifiedRepresentationMapper.Map(classified))
                                    .AddCacheHeaders(classified);

            return response;
        }


        //[WebInvoke(UriTemplate = "{classifiedId}", Method = "POST")]
        //public HttpResponseMessage Update(int classifiedId, classifiedRepresentation classifiedRepresentation)
        //{
        //    var classified = classifiedRepository.GetById(classifiedId);
        //    if (classified == null) return Responses.NotFound();
        //    classified.Location = classifiedRepresentation.Location;
        //    return Responses.Ok();
        //}

        //[WebInvoke(UriTemplate = "{classifiedId}", Method = "DELETE")]
        //public HttpResponseMessage Cancel(int classifiedId)
        //{
        //    var classified = classifiedRepository.GetById(classifiedId);
        //    if(classified == null) return Responses.NotFound();
        //    classified.Cancel("canceled thru rest interface");

        //    var newLocation = linker.GetUri<CanceledclassifiedHandler>(rh => rh.GetCanceled(0), new { classifiedId });
        //    return new HttpResponseMessage(HttpStatusCode.OK, "OK"){Headers = {Location = new Uri(newLocation)}};
        //}

        //[WebInvoke(UriTemplate = "{classifiedId}/payment", Method = "POST")]
        //public HttpResponseMessage Pay(int classifiedId, PaymentRepresentation paymentArgs)
        //{
        //    var classified = classifiedRepository.GetById(classifiedId);
        //    if (classified == null) return Responses.NotFound();
        //    classified.Pay(paymentArgs.CardNumber, paymentArgs.CardOwner);
        //    return Responses.Ok();
        //}

        //[WebGet(UriTemplate = "{classifiedId}/receipt")]
        //public HttpResponseMessage Receipt(int classifiedId)
        //{
        //    //return Get(classifiedId);
        //    throw new NotImplementedException();
        //}
    }
}