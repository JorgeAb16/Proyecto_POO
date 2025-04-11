﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using ProyectoLinkedinMVC.Models;

namespace ProyectoLinkedinMVC.Controllers
{
    public class AdministradorController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44345/api/Adminstrador";

            var respuestaJson = await GetAsync(apiUrl);
            //System.Diagnostics.Debug.WriteLine(respuestaJson); imprimir info
            List<Administrador> listaadmin = JsonConvert.DeserializeObject<List<Administrador>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaadmin, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var client = new HttpClient(handler))
                {
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception e)
            {
                var m = e.Message;
                return null;
            }

        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {

            var values = form.Get("values");

            var httpContent = new StringContent(values, System.Text.Encoding.UTF8, "application/json");

            var url = "https://localhost:44345/api/Adminstrador";
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

            var apiUrlGetAdmin = "https://localhost:44345/api/Adminstrador/" + key;
            var respuestaAdmin = await GetAsync(apiUrlGetAdmin = "https://localhost:44345/api/Adminstrador/" + key);
            Administrador admin = JsonConvert.DeserializeObject<Administrador>(respuestaAdmin);

            JsonConvert.PopulateObject(values, admin);

            string jsonString = JsonConvert.SerializeObject(admin);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var url = "https://localhost:44345/api/Adminstrador/" + key;
                var response = await client.PutAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDelAdmin = "https://localhost:44345/api/Adminstrador/" + key;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var respuestaAdmin = await client.DeleteAsync(apiUrlDelAdmin);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
