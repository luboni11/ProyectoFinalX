using System;
using System.Collections.Generic;
using System.Text;
using AppBancaEnLinea2C2019.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace AppBancaEnLinea2C2019.Controllers
{
    public class TransferenciaManager
    {
        const string Url = "https://www.gruposama.com/WebApiSecureSAMA/api/Transferencia/";
        const string UrlIngresar = "https://www.gruposama.com/WebApiSecureSAMA/api/transferencia/ingresar/";

        HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", App.usuarioActual.TOKEN);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<IEnumerable<Transferencia>> GetTransferencia()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);

            return JsonConvert.DeserializeObject<IEnumerable<Transferencia>>(result);
        }

        public async Task<Transferencia> Ingresar(Transferencia transferencia)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(UrlIngresar, new StringContent(JsonConvert.SerializeObject(transferencia),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Transferencia>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Transferencia> AgregarTransferencia(Transferencia transferencia)
        {
            HttpClient cliente = GetClient();
            var response = await cliente.PostAsync(UrlIngresar,
                new StringContent(JsonConvert.SerializeObject(transferencia),
                Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<Transferencia>(await
            response.Content.ReadAsStringAsync());
        }

        public TransferenciaManager()
        {
        }
    }
}

