using ItecSurApp.services;
using ItecSurApp.views.inicio;
using ItecSurApp.views.registro;
using Plugin.Media;
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

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("EROR", "cámara no disponible", "Aceptar");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions {
            Directory="Sample",
            Name="test.jpg",
            SaveToAlbum=true,
            CompressionQuality=75,
            CustomPhotoSize=50,
            PhotoSize=Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
            MaxWidthHeight=2000,
            DefaultCamera=Plugin.Media.Abstractions.CameraDevice.Front
            });

            if (file == null)
            {
                return;
            }

            await DisplayAlert("Dirección de imagen", file.Path, "Aceptar");

            imagen.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

        }

        private async void btnSeleccionarFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("EROR", "permiso no asignado a fotos", "Aceptar");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
            {
                return;
            }

            imagen.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
    }
}