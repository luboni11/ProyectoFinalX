using System;
using System.Collections.Generic;
using System.Text;
using AppBancaEnLinea2C2019.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace AppBancaEnLinea2C2019.Controllers
{
    public class ServicioManager
    {
        const string Url = "https://www.gruposama.com/WebApiSecureSAMA/api/Servicio";
        const string UrlIngresar = "https://www.gruposama.com/WebApiSecureSAMA/api/servicio/ingresar";

        public async Task<IEnumerable<Servicio>> ObtenerServicios()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(Url);

            return JsonConvert.DeserializeObject<IEnumerable<Servicio>>(result);
        }

        public async Task<Servicio> Ingresar(Servicio servicio)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(UrlIngresar, new StringContent(JsonConvert.SerializeObject(servicio),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Servicio>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Servicio> Actualizar (Servicio servicio)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsync(Url, new StringContent(JsonConvert.SerializeObject(servicio),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Servicio>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Eliminar(string id)
        {
            HttpClient client = new HttpClient();

            var response = await client.DeleteAsync(Url + id);

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }

        public ServicioManager()
        {
        }
    }
}

