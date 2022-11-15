using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.usuarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioActualizarEliminar : ContentPage
    {
        private UsuarioModel usuarioModel;
        private UsuarioService usuarioService;
        PerfilService perfilService;  //propiedad
        private List<PerfilModel> perfils;
        public UsuarioActualizarEliminar(UsuarioModel usuarioModel)
        {
            InitializeComponent();
            this.usuarioModel = usuarioModel;
            this.usuarioService = new UsuarioService();
            this.perfilService = new PerfilService();
            CargarDatosIniciales();

        }

        private async void CargarDatosIniciales()
        {
            await CargarPerfils();
            await CargarRegistroSeleccionado();
        }

        private async Task CargarPerfils()
        {
            perfils = await perfilService.GetPerfiles();
            cmbPerfil.ItemsSource = new ObservableCollection<PerfilModel>(perfils);

        }

        private async Task CargarRegistroSeleccionado()
        {
            try
            {
                txtCodigo.Text = usuarioModel.codigo.ToString();
                var indeceSeleccionado = perfils.FindIndex(it => it.codigo.Equals(usuarioModel.perfil_codigo));
                cmbPerfil.SelectedIndex = indeceSeleccionado;
                txtPrimerNombre.Text = usuarioModel.primer_nombre;
                txtSegundoNombre.Text = usuarioModel.segundo_nombre;
                txtPrimerApellido.Text = usuarioModel.primer_apellido;
                txtSegundoApellido.Text = usuarioModel.segundo_apellido;
                txtIdentificacion.Text = usuarioModel.identificacion;
                txtUsuario.Text = usuarioModel.usuario;
                txtClave.Text = usuarioModel.clave;
                txtCorreo.Text = usuarioModel.correo;
                txtCelular.Text = usuarioModel.celular;
                txtDireccion.Text = usuarioModel.direccion;
                txtFotografia.Text = usuarioModel.fotografia;
                cmbEstado.SelectedItem = usuarioModel.estado;
            }
            catch (Exception)
            {
                DisplayAlert("ADVERTENCIA", "Problema cargando información del registro seleccionado", "Aceptar");
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                UsuarioModel usuarioModel = this.usuarioModel;
                PerfilModel perfilModel = (PerfilModel)cmbPerfil.SelectedItem;
                usuarioModel.perfil_codigo = perfilModel.codigo;
                usuarioModel.primer_nombre = txtPrimerNombre.Text;
                usuarioModel.segundo_nombre = txtSegundoNombre.Text;
                usuarioModel.primer_apellido = txtPrimerApellido.Text;
                usuarioModel.segundo_apellido = txtSegundoApellido.Text;
                usuarioModel.identificacion = txtIdentificacion.Text;
                usuarioModel.usuario = txtUsuario.Text;
                usuarioModel.clave = txtClave.Text;
                usuarioModel.correo = txtPrimerNombre.Text;
                usuarioModel.celular = txtPrimerNombre.Text;
                usuarioModel.direccion = txtPrimerNombre.Text;
                usuarioModel.fotografia = txtPrimerNombre.Text;

                usuarioModel.estado = cmbEstado.SelectedItem.ToString();
                await usuarioService.PutUsuario(Int32.Parse(txtCodigo.Text), usuarioModel);
                await DisplayAlert("CORRECTO", "Registro actualizado con éxito", "Aceptar");
                await Navigation.PushAsync(new UsuarioPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var respuesta = await DisplayAlert("ADVERTENCIA", "¿Eliminar registro?", "SI", "NO");
                if (respuesta)
                {
                    await usuarioService.DeleteUsuario(Int32.Parse(txtCodigo.Text));
                    await DisplayAlert("CORRECTO", "Registro eliminado con éxito", "Aceptar");
                    await Navigation.PushAsync(new UsuarioPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioPage());
        }
    }
}