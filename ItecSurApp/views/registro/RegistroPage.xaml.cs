using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.carreras;
using ItecSurApp.views.login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        private UsuarioService usuarioService;
        public RegistroPage()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                usuario.perfil_codigo = 2;
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
                await Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "Verifica que todos los datos sean válidos, ", "Aceptar");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}