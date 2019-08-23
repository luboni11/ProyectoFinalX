using System;
using System.Collections.Generic;
using AppBancaEnLinea2C2019.Controllers;
using AppBancaEnLinea2C2019.Models;
using Xamarin.Forms;
using System.Linq;

namespace AppBancaEnLinea2C2019.Views
{
    public partial class PagoPage : ContentPage
    {
        CuentaManager cuentaManager = new CuentaManager();
        ServicioManager servicioManager = new ServicioManager();
        PagosManager pagosManager = new PagosManager();

        public PagoPage()
        {
            InitializeComponent();
            CargarDatos();
            var semiTransparentColor = new Color(0, 0, 0, 0.65);
            Stack6.BackgroundColor = semiTransparentColor;
        }

        async void CargarDatos()
        {
            IEnumerable<Cuenta> cuentas = await
                cuentaManager.GetCuentas(App.usuarioActual.USU_CODIGO.ToString());

            IEnumerable<Servicio> servicios = await
                servicioManager.ObtenerServicios();

            pkrCuentas.ItemsSource = cuentas.ToList();
            pkrServicios.ItemsSource = servicios.ToList();

            IEnumerable<Pago> pagos = await
                pagosManager.GetPagos(App.usuarioActual.USU_CODIGO.ToString());

            PagoList.ItemsSource = pagos;
            PagoList.BindingContext = pagos;
        }

        async void AgregarTapped(object sender, System.EventArgs e)
        {
            try
            {
                Pago pagoIngresado = new Pago();

                Pago pago = new Pago()
                {
                    CUE_CODIGO = ((Cuenta)pkrCuentas.SelectedItem).CUE_CODIGO,
                    SER_CODIGO = ((Servicio)pkrServicios.SelectedItem).SER_CODIGO,
                    PAG_MONTO = Convert.ToDecimal(txtMonto.Text),
                    PAG_FECHA = DateTime.Now
                };

                if (string.IsNullOrEmpty(txtMonto.Text))
                {
                    await DisplayAlert("Monto",
                    "Complete el espacio",
                    "Ok", "Cancel");
                };

                pagoIngresado = await pagosManager.Ingresar(pago);
                CargarDatos();

                await DisplayAlert("Pagos",
                    "Pago agregado correctamente",
                    "Ok", "Cancel");
            }
            catch (System.Exception ex)
            {
                await DisplayAlert("Pagos",
                    "Error" + ex.Message,
                    "Ok", "Cancel");
            }
        }

        void RegresarTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        void Limpiar(object sender ,System.EventArgs e)
        {
            pkrServicios.SelectedItem = 0;
            pkrCuentas.SelectedItem = 0;
            txtMonto.Text = "";
        }
    }
}
