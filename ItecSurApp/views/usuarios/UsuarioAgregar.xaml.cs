using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.login;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioAgregar : ContentPage
    {
        private UsuarioService usuarioService;
        PerfilService perfilService;  //propiedad
        private List<PerfilModel> perfils;
        public UsuarioAgregar()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            this.perfilService = new PerfilService();
            CargarPerfils();
        }

        private async Task CargarPerfils()
        {
            perfils = await perfilService.GetPerfiles();
            cmbPerfil.ItemsSource = new ObservableCollection<PerfilModel>(perfils);

        }
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();

                PerfilModel perfilModel = (PerfilModel)cmbPerfil.SelectedItem;
                usuario.perfil_codigo = perfilModel.codigo;            
                usuario.primer_nombre = txtPrimerNombre.Text;
                usuario.segundo_nombre = txtSegundoNombre.Text;
                usuario.primer_apellido = txtPrimerApellido.Text;
                usuario.segundo_apellido = txtSegundoApellido.Text;
                usuario.identificacion = txtIdentificacion.Text;
                usuario.usuario = txtUsuario.Text;
                usuario.clave = txtClave.Text;
                usuario.correo = txtCorreo.Text;
                usuario.celular = txtCelular.Text;
                usuario.direccion = txtDireccion.Text;
                usuario.fotografia = txtFotografia.Text;
                usuario.estado = "ACTIVO";

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

                await usuarioService.PostUsuario(usuario);
                await DisplayAlert("CORRECTO", "Usuario registrado con éxito", "Aceptar");
                await Navigation.PushAsync(new UsuarioPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "Verifica que todos los datos sean válidos, ", "Aceptar");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioPage());
        }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("EROR", "cámara no disponible", "Aceptar");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "itecsur",
                Name = "foto.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            });

            if (file == null)
            {
                return;
            }

            //await DisplayAlert("Dirección de imagen", file.Path, "Aceptar");



            Byte[] bytes = File.ReadAllBytes(file.Path);
            String encodedFile = Convert.ToBase64String(bytes);
            txtFotografia.Text = encodedFile;

            imgFoto.Source = ImageSource.FromStream(() =>
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

            Byte[] bytes = File.ReadAllBytes(file.Path);
            String encodedFile = Convert.ToBase64String(bytes);
            txtFotografia.Text = encodedFile;

            imgFoto.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
    }
}