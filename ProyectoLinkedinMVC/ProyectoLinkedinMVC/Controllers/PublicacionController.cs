using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoLinkedinMVC.Controllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;
    using System.Web.Http.Controllers;
    using System.Web.Http.Routing;
    using System.Collections.Specialized;
    using System;
    using ProyectoLinkedinMVC.Models;
    using System.Net.Http.Formatting;
    using System.Text;
    using System.Web.Security;
    using System.Web;

    public class PublicacionController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();
        

        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44345/api/Publicaciones";
            var respuestaJson = await GetAsync(apiUrl);
            var publicaciones = JsonConvert.DeserializeObject<List<dynamic>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(publicaciones, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            using (var client = new HttpClient(handler))
            {
                var response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {

            var values = form.Get("values");

            var httpContent = new StringContent(values, System.Text.Encoding.UTF8, "application/json");

            var url = "https://localhost:44345/api/Publicacion";
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var response = await client.PostAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }

}
