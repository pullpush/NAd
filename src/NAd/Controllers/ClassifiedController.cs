using System;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Json;
using Microsoft.ApplicationServer.Http.Dispatcher;
using NAd.Querying.Host.Infrastructure.Formatters;
using NAd.Querying.Host.Resources.Classifieds.Representations;
using Ncqrs.CommandService.Contracts;
using Newtonsoft.Json;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

using NAd.UI.ViewModels;
using NAd.UI.Commanding;
//using NAd.Querying.Core.Domain;
using NAd.UI.Facade;

namespace NAd.UI.Controllers
{
    public class ClassifiedController : Controller
    {
        private readonly ClassifiedServiceFacade classifiedFacade;
        //private static readonly MediaTypeFormatter[] formatters = new[] { new NewtonsoftJsonFormatter() };

        //REST service base url
        //static Uri baseAddress = new Uri("http://localhost:7777/");

        public ClassifiedController(ClassifiedServiceFacade classifiedFacade)
        {
            this.classifiedFacade = classifiedFacade;         
        }


        #region Business Logic
        
        //public static HttpResponseMessage SendRequest(string path)
        //{
        //    var client = new HttpClient {BaseAddress = baseAddress};
        //    var request = new HttpRequestMessage(HttpMethod.Get, path);
        //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    return client.SendAsync(request).Result;
        //}

        #endregion

        //
        // GET: /Classified/

        public ActionResult Index()
        {
            //var client = new Querying.QueryServiceClient();
            //client.fi
            //IEnumerable<Classified> items;

            //string requestMessage = "classifieds";

            IEnumerable<ClassifiedViewModel> resource = null;

            try
            {
                resource = classifiedFacade.GetAllClassifiedRepresentations();

                //using (HttpResponseMessage response = SendRequest(requestMessage))
                //{
                //    resource = response.Content.ReadAsAsync<IEnumerable<Classified>>(formatters).Result;

                //    //var classifieds = response.Content.ReadAsStringAsync().Result;
                //    //items = JsonConvert.DeserializeObject<List<Classified>>(classifieds);

                //    //JsonSerializer jsonSerializer = new JsonSerializer(typeof(PanoramioData));
                //    //DataContractJsonSerializer jsonSerializer =
                //    //    new DataContractJsonSerializer(typeof(Classified));

                //    //Classified classifieds = (Classified)jsonSerializer.ReadObject(ws.GetResponseStream());
                //}
            }
            catch (HttpResponseException caught)
            {
                ModelState.AddModelError(caught.Response.StatusCode.ToString(), caught.Message);
            }

            return View(resource);
        }

        //
        // GET: /Add/
        public ActionResult Add()
        {
            var classified = new ClassifiedViewModel();

            return View(classified);
            //var command = new CreateNewClassifiedCommand();
            //command.Id = Guid.NewGuid();

            //return View(command);
        }

        [HttpPost]
        public ActionResult Add(ClassifiedViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    classifiedFacade.CreateClassified(model.Name, model.Description);
                    //var command = new CreateNewClassifiedCommand { Name = model.Name, Description = model.Description };
                    //var client = new NAdCommandServiceClient();
                    //client.Execute(command);

                    // Return user back to the index that displays all the notes.;
                    return RedirectToAction("index");
                }
            }
            catch (FaultException<CommandWebServiceFault> caught)
            {
                ModelState.AddModelError(string.Empty, caught.Detail.Message + caught.Reason + caught.Message);
            }
            catch (FaultException caught)
            {
                ModelState.AddModelError(string.Empty, caught.Message);
            }
            catch (Exception caught)
            {
                ModelState.AddModelError(string.Empty, caught.Message);
            }

            return View();
        }


        //
        // GET: /Edit/
        public ActionResult Edit(string id)
        {
            //var classifiedModel = new ClassifiedViewModel();
            //var classifiedRepresentation = classifiedFacade.GetClassifiedById(id);

            //AI: For simple mapping between model objects, you can use ModelCopier but for complex scenarios, 
            //I highly recommend to use AutoMapper for mapping between model objects.
            //ModelCopier.CopyModel(classifiedRepresentation, classifiedModel);
            //AutoMapper.Mapper.Map(classifiedRepresentation, classifiedModel);

            var classifiedModel = classifiedFacade.GetClassifiedById(id);

            return View(classifiedModel);
            //var command = new CreateNewClassifiedCommand();
            //command.Id = Guid.NewGuid();

            //return View(command);
        }

        [HttpPost]
        public ActionResult Edit(ClassifiedViewModel model)
        {
            if (ModelState.IsValid)
            {
                classifiedFacade.EditClassified(model.Id, model.Name, model.Description);
            }
            //var expenseToEdit = expenseService.GetExpense(expenseViewModel.ExpenseId);
            //ModelCopier.CopyModel(expenseViewModel, expenseToEdit);
            //expenseService.SaveExpense();
            return RedirectToAction("Index");
        }


        #region Helpers

        //public static class HttpContentExtensions
        //{
        //    private static readonly JsonMediaTypeFormatter jsonMediaTypeFormatter = new JsonMediaTypeFormatter();

        //    public static Task<T> ReadAsAsyncJson<T>(this HttpContent content)
        //    {
        //        return content.ReadAsAsync<T>(new[] { jsonMediaTypeFormatter });
        //    }
        //}

        #endregion
    }
}
