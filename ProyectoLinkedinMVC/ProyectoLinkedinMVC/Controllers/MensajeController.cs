using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using ProyectoLinkedinMVC.Models;



namespace ProyectoLinkedinMVC.Controllers
{
    public class MensajeController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44345/api/Mensaje";

            var respuestaJson = await GetAsync(apiUrl);
            //System.Diagnostics.Debug.WriteLine(respuestaJson); imprimir info
            List<Mensaje> listaMensaje = JsonConvert.DeserializeObject<List<Mensaje>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaMensaje, loadOptions));
        }
        [HttpGet]
        [Route("Mensaje/GetChat")]
        public async Task<HttpResponseMessage> GetChat()
        {
            try
            {
                var apiUrl = "https://localhost:44345/api/Mensaje/GetChat";
                var respuestaJson = await GetAsync(apiUrl);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(respuestaJson, Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("Mensaje/Send")]
        public async Task<HttpResponseMessage> Send([FromBody] MensajeModel mensaje)
        {
            try
            {
                var apiUrl = "https://localhost:44345/api/Mensaje/Send";
                var respuestaJson = await PostAsync(apiUrl, mensaje);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(respuestaJson, Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public static async Task<string> GetAsync(string uri)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                using (var client = new HttpClient(handler))
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(uri);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(
                            $"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetAsync: {e}");
                throw;
            }
        }
        private async Task<string> PostAsync(string uri, object data)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync(uri, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {

            var values = form.Get("values");

            var httpContent = new StringContent(values, System.Text.Encoding.UTF8, "application/json");

            var url = "https://localhost:44345/api/Mensaje";
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var response = await client.PostAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            //Parámetros del form
            var key = Convert.ToInt32(form.Get("key")); //llave que estoy modificando
            var values = form.Get("values"); //Los valores que yo modifiqué en formato JSON

            var apiUrlGetMensaje = "https://localhost:44345/api/Mensaje/" + key;
            var respuestaMensaje = await GetAsync(apiUrlGetMensaje = "https://localhost:44345/api/Mensaje/" + key);
            Mensaje mensaje = JsonConvert.DeserializeObject<Mensaje>(respuestaMensaje);

            JsonConvert.PopulateObject(values, mensaje);

            string jsonString = JsonConvert.SerializeObject(mensaje);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var url = "https://localhost:44345/api/Mensaje/" + key;
                var response = await client.PutAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }



        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDelMensaje = "https://localhost:44345/api/Mensaje/" + key;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var respuestaMensaje = await client.DeleteAsync(apiUrlDelMensaje);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }






    }
}
