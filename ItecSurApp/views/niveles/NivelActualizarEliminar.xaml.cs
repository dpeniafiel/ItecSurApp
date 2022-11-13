using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.nivel;
using ItecSurApp.views.niveles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.niveles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NivelActualizarEliminar : ContentPage
    {
        private NivelModel nivelModel;
        private NivelService nivelService;
        CarreraService carreraService;  //propiedad
        private List<CarreraModel> carreras;
        public NivelActualizarEliminar(NivelModel nivelModel)
        {
            InitializeComponent();
            this.nivelModel = nivelModel;
            this.nivelService = new NivelService();
            this.carreraService = new CarreraService();
            CargarDatosIniciales();

        }

        private async void CargarDatosIniciales()
        {
            await CargarCarreras();
            await CargarRegistroSeleccionado();
        }

        private async Task CargarCarreras()
        {
            carreras = await carreraService.GetCarreras();
            cmbCarrera.ItemsSource = new ObservableCollection<CarreraModel>(carreras);

        }

        private async Task CargarRegistroSeleccionado()
        {
            try
            {
                txtCodigo.Text = nivelModel.codigo.ToString();
                var indeceSeleccionado = carreras.FindIndex(it => it.codigo.Equals(nivelModel.carrera_codigo));
                cmbCarrera.SelectedIndex = indeceSeleccionado;
                txtNombre.Text = nivelModel.nombre;
                cmbEstado.SelectedItem = nivelModel.estado;
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
                NivelModel nivelModel = this.nivelModel;
                CarreraModel carreraModel = (CarreraModel)cmbCarrera.SelectedItem;
                nivelModel.carrera_codigo = carreraModel.codigo;
                nivelModel.nombre = txtNombre.Text;
                nivelModel.estado = cmbEstado.SelectedItem.ToString();
                await nivelService.PutNivel(Int32.Parse(txtCodigo.Text), nivelModel);
                await DisplayAlert("CORRECTO", "Registro actualizado con éxito", "Aceptar");
                await Navigation.PushAsync(new NivelPage());
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
                    await nivelService.DeleteNivel(Int32.Parse(txtCodigo.Text));
                    await DisplayAlert("CORRECTO", "Registro eliminado con éxito", "Aceptar");
                    await Navigation.PushAsync(new NivelPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NivelPage());
        }
    }
}