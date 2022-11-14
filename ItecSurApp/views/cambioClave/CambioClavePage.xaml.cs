using ItecSurApp.services;
using ItecSurApp.views.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.cambioClave
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CambioClavePage : ContentPage
    {
        private UsuarioService usuarioService;
        public CambioClavePage()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtClave.Text.Count() < 6)
                {
                    await DisplayAlert("ADVERTENCIA", "la clave debe tener al menos 6 caracteres", "Aceptar");
                    return;
                }

                if (!txtClave.Text.Equals(txtClaveVerificacion.Text))
                {
                    await DisplayAlert("ADVERTENCIA", "las claves ingresadas no coinciden", "Aceptar");
                    return;
                }

                var usuarioLogeado = App.Usuario;
                usuarioLogeado.clave = txtClave.Text;
                await usuarioService.PutUsuario(usuarioLogeado.codigo, usuarioLogeado);
                await DisplayAlert("CORRECTO", "Clave actualizada con éxito", "Aceptar");
                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "Verifica que todos los datos sean válidos, ", "Aceptar");
            }
        }
    }
}