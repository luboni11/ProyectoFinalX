using System;
using System.Collections.Generic;
using System.Text;
using AppBancaEnLinea2C2019.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace AppBancaEnLinea2C2019.Controllers
{
    public class PagosManager
    {
        const string Url = "https://www.gruposama.com/WebApiSecureSAMA/api/Pago/";
        const string UrlIngresar = "https://www.gruposama.com/WebApiSecureSAMA/api/pago/ingresar/";

        HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", App.usuarioActual.TOKEN);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<IEnumerable<Pago>> GetPagos(string id)
        {
            HttpClient client = GetClient();
            var uri = new Uri(string.Format(Url));
            string result = await client.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<IEnumerable<Pago>>(result);
        }

        public async Task<Pago> Ingresar(Pago pago)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(UrlIngresar, new StringContent(JsonConvert.SerializeObject(pago),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Pago>(await response.Content.ReadAsStringAsync());
        }

        public PagosManager()
        {
        }
    }
}

