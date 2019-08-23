using System;
using Xamarin.Essentials;

namespace AppBancaEnLinea2C2019.Models
{
    public class Dispositivo
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceName { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public string Idiom { get; set; }
        public string DeviceType { get; set; }

        public Dispositivo()
        {
        }

        public bool ValidarConexionInternet()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
                return true;

            return false;

        }
    }
}
