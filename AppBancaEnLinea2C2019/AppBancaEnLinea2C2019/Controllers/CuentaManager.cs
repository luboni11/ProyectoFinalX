﻿using System;
using System.Collections.Generic;
using System.Text;
using AppBancaEnLinea2C2019.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace AppBancaEnLinea2C2019.Controllers
{
    public class CuentaManager
    {
        const string Url = "https://www.gruposama.com/WebApiSecureSAMA/api/cuenta/";
        const string UrlIngresar = "https://www.gruposama.com/WebApiSecureSAMA/api/cuenta/ingresar/";

        HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", App.usuarioActual.TOKEN);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<IEnumerable<Cuenta>> GetCuentas(string id)
        {
            //HttpClient client = new HttpClient();
            HttpClient client = GetClient();
            var uri = new Uri(string.Format(Url + "{0}", id));
            string result = await client.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<IEnumerable<Cuenta>>(result);
        }
        public async Task<Cuenta> Ingresar(Cuenta cuenta)
        {
            //HttpClient client = new HttpClient();
            HttpClient client = GetClient();
            var response = await client.PostAsync(UrlIngresar, new StringContent(JsonConvert.SerializeObject(cuenta),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Cuenta>(await response.Content.ReadAsStringAsync());
        }

        public async Task <Cuenta> Actualizar(Cuenta cuenta)
        {
            //HttpClient client = new HttpClient();
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url, new StringContent(JsonConvert.SerializeObject(cuenta),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Cuenta>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Eliminar(string id)
        {
            //HttpClient client = new HttpClient();
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + id);

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public CuentaManager()
        {
        }
    }
}
