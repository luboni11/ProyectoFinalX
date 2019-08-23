using System;
using System.Collections.Generic;
using Xamarin.Forms;
using AppBancaEnLinea2C2019.Models;
using AppBancaEnLinea2C2019.Controllers;
using AppBancaEnLinea2C2019.Views;

namespace AppBancaEnLinea2C2019
{
    public partial class PagoReaPage : ContentPage
    {

        PagosManager pagosManager = new PagosManager();

        public PagoReaPage()
        {
            InitializeComponent();
            CargarListaPagos();
            var semiTransparentColor = new Color(0, 0, 0, 0.65);
            Stack4.BackgroundColor = semiTransparentColor;
        }

        async void CargarListaPagos()
        {
            IEnumerable<Pago> pagos = await
                pagosManager.GetPagos(App.usuarioActual.USU_CODIGO.ToString());

            PagosList.ItemsSource = pagos;
            PagosList.BindingContext = pagos;
        }

        void RegresarTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}
