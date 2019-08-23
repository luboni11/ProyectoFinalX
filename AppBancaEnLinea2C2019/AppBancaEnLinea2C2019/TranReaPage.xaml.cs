using System;
using System.Collections.Generic;
using Xamarin.Forms;
using AppBancaEnLinea2C2019.Models;
using AppBancaEnLinea2C2019.Controllers;
using AppBancaEnLinea2C2019.Views;

namespace AppBancaEnLinea2C2019
{
    public partial class TranReaPage : ContentPage
    {

        TransferenciaManager transferenciaManager = new TransferenciaManager();
        private List<Transferencia> transferenciasList = new List<Transferencia>();

        //constructor
        public TranReaPage()
        {
            InitializeComponent();
            CargarListaTransferencia();
            var semiTransparentColor = new Color(0, 0, 0, 0.65);
            Stack3.BackgroundColor = semiTransparentColor;
        }

        async void CargarListaTransferencia()
        {
            try
            {
                IEnumerable<Transferencia> transferencias = await
                    transferenciaManager.GetTransferencia();

                foreach (var item in transferencias)
                {
                    transferenciasList.Add(item);
                }

                TransferenciasList.ItemsSource = transferencias;
                TransferenciasList.BindingContext = transferencias;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Error al mostrar las transferencias.", "OK");
            }
        }

        void RegresarTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}