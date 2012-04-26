using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

using Microsoft.ApplicationServer.Http.Dispatcher;

//using NAd.Querying.Core.Domain;
//using NAd.Querying.Core.ExceptionHandling;
//using NAd.Querying.Core.Persistency;
//using NAd.Querying.Core.Services;
using NAd.Framework.Services;
using NAd.Querying.Host.Infrastructure;
using NAd.Querying.Host.Resources.Classifieds.Representations;

namespace NAd.Querying.Host.Resources.Classifieds
{
    [ServiceContract]
    public class ClassifiedsResourceHandler
    {
        IClassifiedService classifiedService = null;

        public ClassifiedsResourceHandler(IClassifiedService classifiedService)
        {
            this.classifiedService = classifiedService;
        }

        //[WebGet]
        //public HttpResponseMessage GetClassifieds()
        //{
        //    return (GetClassifieds(string.Empty, string.Empty));
        //}

        //[WebGet(UriTemplate = "{partialName}/{partialDescription}")]
        //public HttpResponseMessage GetClassifieds(string partialName, string partialDescription)
        //{
        //    // Create a sample HttpResponseMessage
        //    //HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.Created);

        //    var restContext = new RestContext();

        //    var query = from classified in restContext.Classifieds
        //           where (partialName.Length == 0 || (classified.Name.Contains(partialName)))
        //           where (partialDescription.Length == 0 || (classified.Description.Contains(partialDescription)))
        //           select classified;

        //    // Create object content with the new contact
        //    //httpResponse.Content = new ObjectContent<List<Classified>>(query.ToList());

        //    // Create an HttpMessageContent encapsulating the sample HttpResponseMessage
        //    //HttpMessageContent content = new HttpMessageContent(httpResponse);
            
        //    //HttpResponseMessage response = content.ReadAsHttpResponseMessage();
        //    HttpResponseMessage response = new HttpResponseMessage<List<Classified>>(
        //        query.ToList(),
        //        HttpStatusCode.OK                
        //    );

        //    return response;
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <returns />
        /// <remarks>Return our model by wrapping it up with HttpResponseMessage class</remarks>
        [WebGet(UriTemplate = "")]
        [OperationContract(Name = "AllClassifieds")]
        //public IQueryable<Classified> GetClassifieds()
        public HttpResponseMessage GetClassifieds()
        {
            return (GetClassifieds(string.Empty, string.Empty));
        }


        /*
        [WebGet(UriTemplate = "")]
        public MenuRepresentation Get()
        {
            var products = productRepository.RetrieveAll().OrderBy(p => p.Name)
                .ToList()
                .Select(p => new ItemRepresentation { Name = p.Name, Price = p.Price }).ToArray();
            return new MenuRepresentation { Items = products };
        }
        */


        [WebGet(UriTemplate = "{partialName}/{partialDescription}")]
        [OperationContract(Name = "FilterClassifieds")]
        public HttpResponseMessage GetClassifieds(string partialName, string partialDescription)
        {
            //var restContext = new RestContext();
            //return from classified in restContext.Classifieds
            //        where (partialName.Length == 0 || (classified.Name.Contains(partialName)))
            //        where (partialDescription.Length == 0 || (classified.Description.Contains(partialDescription)))
            //        select classified;

            //try
            //{
                var classifieds = classifiedService.GetClassifieds(partialName, partialDescription);

                if (classifieds.Count() == 0) return Responses.NotFound();

                //return _cargoRepository.FindAll().Select(x => _cargoRoutingAssembler.ToDTO(x)).ToList();
                var classifiedsRepresentation = classifieds.Select(p => ClassifiedRepresentationMapper.Map(p));

                var responseMessage = Responses.WithContent(classifiedsRepresentation);
                                        //Responses.WithContent(classifieds);
                                        //.AddCacheHeaders(classifieds);

                //var responseMessage = new HttpResponseMessage<IQueryable<Classified>>(classifieds);

                //responseMessage.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddHours(1));

                return responseMessage;
            //}
            //catch (Exception ex)
            //{
            //NOTE:
            // FaultContract is only useful for webservice that will return standard SOAP format message.

            //return new HttpResponseMessage<PaymentRepresentation>(HttpStatusCode.BadRequest);
             //    throw new WebFaultException<ServiceError>(
            //        new SampleError()
            //        {
            //            ErrorCode = "123456789",
            //            Message = "."
            //        }, HttpStatusCode.BadRequest);
            //}
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <see cref="http://blog.alexonasp.net/post/2011/04/20/REST-using-the-WCF-Web-API-e28093-getting-more-RESTful-responses-%28Part-5%29.aspx"/>
        //[WebGet(UriTemplate = "{id}")]
        //public Classified GetById(Guid id)
        //{
        //    return classifiedService.GetById(id);
        //}  

    }
}