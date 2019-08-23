using System;
using System.Collections.Generic;
using Xamarin.Forms;
using AppBancaEnLinea2C2019.Models;
using AppBancaEnLinea2C2019.Controllers;

namespace AppBancaEnLinea2C2019.Views
{
    public partial class MainPage : ContentPage
    {

        CuentaManager cuentaManager = new CuentaManager();

        public MainPage()
        {
            InitializeComponent();
            CargarListaCuentas();
            var semiTransparentColor = new Color(0, 0, 0, 0.65);
            Stack2.BackgroundColor = semiTransparentColor;

        }

        async void CargarListaCuentas()
        {
            IEnumerable<Cuenta> cuentas = await
                cuentaManager.GetCuentas(App.usuarioActual.USU_CODIGO.ToString());

            CuentasList.ItemsSource = cuentas;
            CuentasList.BindingContext = cuentas;
        }

        void AgregarTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new CuentaPage();
        }

        void PagarTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new PagoPage();
        }

        void TransferenciaTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new TransferPage();
        }

        void ActualizarTapped(object sender, System.EventArgs e)
        {
            Cuenta cuenta = (Cuenta)CuentasList.SelectedItem;

            Application.Current.MainPage = new CuentaPage(cuenta);
        }

        async void EliminarTapped(object sender, System.EventArgs e)
        {

            try
            {               
                Cuenta cuenta = (Cuenta)CuentasList.SelectedItem;

                string idCuentaEliminada = string.Empty;

                idCuentaEliminada = await cuentaManager.Eliminar(cuenta.CUE_CODIGO.ToString());

                await DisplayAlert("Cuentas",
                    "Cuenta eliminada correctamente",
                    "Ok", "Cancel");

                CargarListaCuentas();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Cuentas",
                    "Cuenta actualizada " + "correctamente",
                    "Ok", "Cancel");
            }
        }

        void TranRealizadoTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new TranReaPage();
        }

        void PagoRealizadoTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new PagoReaPage();
        }

        void CerrarTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}
