using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.jornadas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.jornadas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JornadaActualizarEliminar : ContentPage
    {
        private JornadaModel jornadaModel;
        private JornadaService jornadaService;
        NivelService nivelService;  //propiedad
        private List<NivelModel> niveles;
        public JornadaActualizarEliminar(JornadaModel jornadaModel)
        {
            InitializeComponent();
            this.jornadaModel = jornadaModel;
            this.jornadaService = new JornadaService();
            this.nivelService = new NivelService();
            CargarDatosIniciales();
        }
        private async void CargarDatosIniciales()
        {
            await CargarNivels();
            await CargarRegistroSeleccionado();
        }

        private async Task CargarNivels()
        {
            niveles = await nivelService.GetNiveles();
            cmbNivel.ItemsSource = new ObservableCollection<NivelModel>(niveles);

        }

        private async Task CargarRegistroSeleccionado()
        {
            try
            {
                txtCodigo.Text = jornadaModel.codigo.ToString();
                var indeceSeleccionado = niveles.FindIndex(it => it.codigo.Equals(jornadaModel.nivel_codigo));
                cmbNivel.SelectedIndex = indeceSeleccionado;
                txtNombre.Text = jornadaModel.nombre;
                cmbEstado.SelectedItem = jornadaModel.estado;
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
                JornadaModel jornadaModel = this.jornadaModel;
                NivelModel nivelModel = (NivelModel)cmbNivel.SelectedItem;
                jornadaModel.nivel_codigo = nivelModel.codigo;
                jornadaModel.nombre = txtNombre.Text;
                jornadaModel.estado = cmbEstado.SelectedItem.ToString();
                await jornadaService.PutJornada(Int32.Parse(txtCodigo.Text), jornadaModel);
                await DisplayAlert("CORRECTO", "Registro actualizado con éxito", "Aceptar");
                await Navigation.PushAsync(new JornadaPage());
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
                    await jornadaService.DeleteJornada(Int32.Parse(txtCodigo.Text));
                    await DisplayAlert("CORRECTO", "Registro eliminado con éxito", "Aceptar");
                    await Navigation.PushAsync(new JornadaPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new JornadaPage());
        }


    }
}