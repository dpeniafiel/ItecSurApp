using ItecSurApp.views.inicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string usuario = "a";
            string clave = "1";

            string tUsuario = txtUsuario.Text;
            string tContrasenia = txtClave.Text;

            if (usuario == tUsuario & clave == tContrasenia)
            {
                Navigation.PushAsync(new InicioPage());
            }
            else
            {
                DisplayAlert("Ops", "Usuario  no contraseña incorrectos", "OK");

            }
        }
    }
}