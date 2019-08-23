using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using AppBancaEnLinea2C2019.Models;
using System.Threading.Tasks;

namespace AppBancaEnLinea2C2019.Controllers
{
    public class UsuarioManager
    {
        const string UrlAuthenticate = "https://www.gruposama.com/WebApiSecureSAMA/api/loginext/authenticate/";
        const string UrlRegister = "https://www.gruposama.com/WebApiSecureSAMA/api/register/";

        //metodo para Validar
        public async Task<Usuario> Validar(string username, string password)
        {
            LoginRequest login = new LoginRequest() { Username = username, Password = password };
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(UrlAuthenticate,
                new StringContent(JsonConvert.SerializeObject(login),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
        
        }
        //metodo para Registrar
        public async Task<Usuario> Registrar(UsuarioManager usuario)
        {
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(UrlRegister,
                new StringContent(JsonConvert.SerializeObject(usuario),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
        }

        public UsuarioManager()
        {
        }
    }
}
//Json
//System.Net.http
//Carpeta Modelos
//System.Thread. 
//Sincronico: flujo definido una tras de otra 
//Asincronico: los web services son asincronicos porque no sabemos cuanto va a tardar, dependiendo de la conexion de la red
//o el llamado a la base de datos, lo que vamos a devolver una tarea, llevando un string. Await, se espera la respuesta del
//web service porque necesitamos los datos.
//Cerializar: tomar una clase y convertirlo en bytes