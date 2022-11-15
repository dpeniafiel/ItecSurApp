using ItecSurApp.models;
using ItecSurApp.services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.perfiles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilActualizarEliminar : ContentPage
    {
        private PerfilModel perfilModel;
        private PerfilService perfilService;
        public PerfilActualizarEliminar(PerfilModel perfilModel)
        {
            InitializeComponent();
            this.perfilModel = perfilModel;
            this.perfilService = new PerfilService();
            CargarRegistroSeleccionado();
        }

        private void CargarRegistroSeleccionado()
        {
            try
            {
                txtCodigo.Text = perfilModel.codigo.ToString();
                txtNombre.Text = perfilModel.nombre;               
                cmbEstado.SelectedItem = perfilModel.estado;
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
                PerfilModel perfilModel = this.perfilModel;
                perfilModel.nombre = txtNombre.Text;                
                perfilModel.estado = cmbEstado.SelectedItem.ToString();
                await perfilService.PutPerfil(Int32.Parse(txtCodigo.Text), perfilModel);
                await DisplayAlert("CORRECTO", "Registro actualizado con éxito", "Aceptar");
                await Navigation.PushAsync(new PerfilPage());
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
                    await perfilService.DeletePerfil(Int32.Parse(txtCodigo.Text));
                    await DisplayAlert("CORRECTO", "Registro eliminado con éxito", "Aceptar");
                    await Navigation.PushAsync(new PerfilPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage());
        }
    }
}