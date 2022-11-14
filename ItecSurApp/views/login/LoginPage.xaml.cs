using ItecSurApp.services;
using ItecSurApp.views.inicio;
using ItecSurApp.views.registro;
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
        private UsuarioService usuarioService;
        private PerfilService perfilService;
        private PermisoService permisoService;
        public LoginPage()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            perfilService = new PerfilService();
            permisoService = new PermisoService();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string tUsuario = txtUsuario.Text;
                string tContrasenia = txtClave.Text;

                var usuario = await usuarioService.GetUsuarioPor(tUsuario, tContrasenia);

                if (usuario != null)
                {
                    App.Usuario = usuario;
                    App.Perfil = await perfilService.GetPerfilPor(App.Usuario.perfil_codigo);
                    App.Permisos = await permisoService.GetPermisosPorPerfil(App.Perfil.codigo);
                    await Navigation.PushAsync(new InicioPage());
                }
                else
                {
                    await DisplayAlert("Error de acceso", "Usuario o contraseña incorrectos", "Aceptar");

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error de acceso", "Usuario o contraseña incorrectos", "Aceptar");
            }
        }

        private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroPage());
        }
    }
}