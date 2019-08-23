using System;
using System.Collections.Generic;
using AppBancaEnLinea2C2019.Controllers;
using AppBancaEnLinea2C2019.Models;
using Xamarin.Forms;
using System.Linq;

namespace AppBancaEnLinea2C2019.Views
{

    public partial class TransferPage : ContentPage
    {
        CuentaManager cuentaManager = new CuentaManager();
        TransferenciaManager transferenciaManager = new TransferenciaManager();
        private List<Cuenta> cuentaList = new List<Cuenta>();

        public TransferPage()
        {
            InitializeComponent();
            CargarDatos();
            var semiTransparentColor = new Color(0, 0, 0, 0.65);
            Stack5.BackgroundColor = semiTransparentColor;
        }

        async void CargarDatos()
        {
            //IEnumerable<Cuenta> cuentasList = await cuentaManager.GetCuentas(App.usuarioActual.USU_CODIGO.ToString());
            foreach (var item in cuentaList)
            {
                cuentaList.Add(item);
            }

            pkrCuentas.ItemsSource = cuentaList;
            pkrCuentasDestino.ItemsSource = cuentaList;
        }

        async void AgregarTapped(object sender, System.EventArgs e)
        {
            try
            {
                int cuentaorigen = pkrCuentas.SelectedIndex;
                int cuentadestino = pkrCuentasDestino.SelectedIndex;
                string monto = txtMonto.Text;
                bool BCuentaOrigen = true;
                bool BCuentaDestino = true;

                if (cuentaorigen == -1)
                {
                    BCuentaOrigen = false;
                    await DisplayAlert("Alerta", "Debes seleccionar una cuenta de origen.", "OK");
                }
                if (cuentadestino == -1)
                {
                    BCuentaDestino = false;
                    await DisplayAlert("Alerta", "Debes seleccionar una cuenta de destino.", "OK");
                }

                if (BCuentaOrigen && BCuentaDestino)
                {
                    if (cuentaorigen != cuentadestino)
                    {
                        int imonto = int.Parse(monto);

                        if (imonto > 0)
                        {
                            if (cuentaList[cuentaorigen].CUE_SALDO > imonto)
                            {
                                if (cuentaList[cuentaorigen].CUE_MONEDA.Equals(cuentaList[cuentadestino].CUE_MONEDA))
                                {
                                    Cuenta cuentaOrigen = new Cuenta()
                                    {
                                        USU_CODIGO = App.usuarioActual.USU_CODIGO,
                                        CUE_MONEDA = cuentaList[cuentaorigen].CUE_MONEDA,
                                        CUE_SALDO = cuentaList[cuentaorigen].CUE_SALDO - int.Parse(monto),
                                    };
                                    Cuenta cuentaDestino = new Cuenta()
                                    {
                                        USU_CODIGO = App.usuarioActual.USU_CODIGO,
                                        CUE_MONEDA = cuentaList[cuentaorigen].CUE_MONEDA,
                                        CUE_SALDO = cuentaList[cuentaorigen].CUE_SALDO + int.Parse(monto),
                                    };

                                    Transferencia transferencia = new Transferencia()
                                    {
                                        TRA_CODIGO = App.usuarioActual.USU_CODIGO,
                                        TRA_CUENTA_ORIGEN = ((Cuenta)pkrCuentas.SelectedItem).CUE_CODIGO,
                                        TRA_CUENTA_DESTINO = ((Cuenta)pkrCuentasDestino.SelectedItem).CUE_CODIGO,
                                        TRA_FECHA = DateTime.Now,
                                        TRA_MONTO = Convert.ToDecimal(txtMonto.Text),
                                        TRA_ESTADO = "A"
                                    };

                                    bool respuesta = await DisplayAlert("Agregar transferencia", "", "Agregar", "Cancelar");

                                    if (respuesta)
                                    {
                                        //Agregar la transferencia.
                                        transferencia = await transferenciaManager.AgregarTransferencia(transferencia);
                                        cuentaOrigen = await cuentaManager.Actualizar(cuentaOrigen);
                                        cuentaDestino = await cuentaManager.Actualizar(cuentaDestino);
                                        
                                        await DisplayAlert("Mensaje", "Transferencia agregada correctamente", "Aceptar");
                                    }
                                }
                                else
                                {
                                    await DisplayAlert("Atencion", "Monedas no son iguales", "Aceptar");
                                }
                            }
                            else
                            {
                                await DisplayAlert("Atencion", "Monto insuficiente", "Aceptar");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Atencion", "Monto debe ser mayor a cero", "Aceptar");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Atencion", "Cuentas iguales", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Atencion", "Revise sus de datos", "Aceptar");
                }
            }
            catch (System.Exception ex)
            {
                await DisplayAlert("Transferencias1",
                    "Error " + ex.Message,
                    "Ok", "Cancel");
            }
        }

        void RegresarTapped(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        void Limpiar(object sender, System.EventArgs e)
        {
            pkrCuentas.SelectedItem = 0;
            pkrCuentasDestino.SelectedItem = 0;
            txtMonto.Text = "";
        }
    }
}
