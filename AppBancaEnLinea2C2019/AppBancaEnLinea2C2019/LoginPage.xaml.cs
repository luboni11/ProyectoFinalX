using System;
using System.Collections.Generic;
using AppBancaEnLinea2C2019.Views;
using AppBancaEnLinea2C2019.Models;
using Xamarin.Forms;
using AppBancaEnLinea2C2019.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancaEnLinea2C2019
{
    public partial class LoginPage : ContentPage
    {
        Dispositivo dispositivo = new Dispositivo();

        public LoginPage()
        {
            InitializeComponent();
            

            var semiTransparentColor = new Color(0, 0, 0, 0.65);
            //Stack1.BackgroundColor = semiTransparentColor;
            //logo.Source = ImageSource.FromResource("AppBancaEnLinea2C2019.img.ulacit_logo.png");
        }
        async void LoginWS(object sender, System.EventArgs e)
        {
            try
            {
                if (dispositivo.ValidarConexionInternet())
                {
                    var manager = new UsuarioManager();
                    App.usuarioActual = await manager.Validar(txtUsername.Text, txtPassword.Text);
                    if (App.usuarioActual != null)
                    {
                        var jwthandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                        App.usuarioActual.Token = jwthandler.ReadToken(App.usuarioActual.TOKEN);

                        Application.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        await DisplayAlert("Error al ingresar", " No hay conexion con internet", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error de conexion", " No hay conexion con internet", "Ok");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No se puede ingresar", "Ok");
                throw;
            }
            
        }
    }
}
