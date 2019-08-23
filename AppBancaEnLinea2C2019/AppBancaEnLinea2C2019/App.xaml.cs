using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBancaEnLinea2C2019.Models;

namespace AppBancaEnLinea2C2019
{
    public partial class App : Application
    {
        static public Usuario usuarioActual = new Usuario();

        public App()

        {
            InitializeComponent();
                
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
