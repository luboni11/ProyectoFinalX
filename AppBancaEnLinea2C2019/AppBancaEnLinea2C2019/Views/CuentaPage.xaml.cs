using System;
using System.Collections.Generic;
using AppBancaEnLinea2C2019.Models;
using AppBancaEnLinea2C2019.Controllers;

using Xamarin.Forms;

namespace AppBancaEnLinea2C2019.Views
{
    public partial class CuentaPage : ContentPage
    {
        public CuentaPage()
        {
            InitializeComponent();
            txtCodigo.IsVisible = false;
        }

        public CuentaPage(Cuenta cuenta)
        {
            InitializeComponent();

            txtCodigo.Text = cuenta.CUE_CODIGO.ToString();
            txtDescripcion.Text = cuenta.CUE_DESCRIPCION;
            txtSaldo.Text = cuenta.CUE_SALDO.ToString();
            //pkrMoneda.SelectedItem = cuenta.CUE_MONEDA;
            pkrEstado.SelectedItem = 
                (cuenta.CUE_ESTADO.Equals("A") ? "Activo" : "Inactivo");
            //Activo es el "If" y el Inactivo es el "Else"

            txtCodigo.IsReadOnly = true;
        }

        async void AgregarTapped(object sender, System.EventArgs e)
        {
            try
            {
                    
                CuentaManager cuentaManager = new CuentaManager();
                Cuenta cuentaIngresada = new Cuenta();

                string moneda = string.Empty;

                switch (pkrMoneda.SelectedItem.ToString())
                {
                    case "Colones":
                        moneda = "COL";
                        break;
                    case "Dólares":
                        moneda = "DOL";
                        break;
                    default:
                        moneda = "EUR";
                        break;
                }

                Cuenta cuenta = new Cuenta()
                {
                    USU_CODIGO = App.usuarioActual.USU_CODIGO,
                    CUE_DESCRIPCION = txtDescripcion.Text,
                    CUE_MONEDA = moneda,
                    CUE_SALDO = Convert.ToDecimal(txtSaldo.Text),
                    CUE_ESTADO = pkrEstado.SelectedItem.ToString().Substring(0, 1)
                };

                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    await DisplayAlert("Codigo",
                    "Complete el espacio",
                    "Ok", "Cancel");
                };
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    await DisplayAlert("Descripcion",
                    "Complete el espacio",
                    "Ok", "Cancel");
                };
                if (string.IsNullOrEmpty(txtSaldo.Text))
                {
                    await DisplayAlert("Saldo",
                    "Complete el espacio",
                    "Ok", "Cancel");
                };
                cuentaIngresada = await cuentaManager.Ingresar(cuenta);

                await DisplayAlert("Cuentas",
                    "Cuenta agregada correctamente",
                    "Ok", "Cancel");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Cuentas",
                    "Error" + ex.Message,
                    "Ok", "Cancel");
            }
               
            }


        async void ActualizarTapped(object sender, System.EventArgs e)
        {
            try
            {
                    
                CuentaManager cuentaManager = new CuentaManager();
                Cuenta cuentaActualizada = new Cuenta();

                string moneda = string.Empty;

                switch (pkrMoneda.SelectedItem.ToString())
                {
                    case "Colones":
                        moneda = "COL";
                        break;
                    case "Dólares":
                        moneda = "DOL";
                        break;
                    default:
                        moneda = "EUR";
                        break;
                }

                Cuenta cuenta = new Cuenta()
                {
                    CUE_CODIGO = Convert.ToInt32(txtCodigo.Text),
                    USU_CODIGO = App.usuarioActual.USU_CODIGO,
                    CUE_DESCRIPCION = txtDescripcion.Text,
                    CUE_MONEDA = moneda,
                    CUE_SALDO = Convert.ToDecimal(txtSaldo.Text),
                    CUE_ESTADO = pkrEstado.SelectedItem.ToString().Substring(0, 1)
                };

                cuentaActualizada = await cuentaManager.Actualizar(cuenta);

                await DisplayAlert("Actualizar",
                    "Cuenta actualizada correctamente",
                    "Ok", "Cancel");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Actualizar",
                    "Error" + ex.Message,
                    "Ok", "Cancel");
            }        
        }

        void RegresarTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
        void Limpiar(object sender, System.EventArgs e)
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtSaldo.Text = "";
            pkrMoneda.SelectedItem = 0;
            pkrEstado.SelectedItem = 0;
        }
    }
}
