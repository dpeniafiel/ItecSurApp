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
    public partial class JornadaAgregar : ContentPage
    {
       JornadaService jornadaService;
        NivelService nivelService;  //propiedad
        public JornadaAgregar()
        {
            InitializeComponent();
            jornadaService = new JornadaService();
            nivelService = new NivelService();
            CargarNivels();
        }

        private async void CargarNivels()
        {
            var nivels = await nivelService.GetNiveles();
            cmbNivel.ItemsSource = new ObservableCollection<NivelModel>(nivels);

        }


        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
               JornadaModel jornadaModel = new JornadaModel();
                NivelModel nivelModel = (NivelModel)cmbNivel.SelectedItem;
                jornadaModel.nivel_codigo = nivelModel.codigo;
                jornadaModel.nombre = txtNombre.Text;
                jornadaModel.estado = "ACTIVO";
                await jornadaService.PostJornada(jornadaModel);
                await DisplayAlert("CORRECTO", "Registro ingresado con éxito", "Aceptar");
                await Navigation.PushAsync(new JornadaPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JornadaPage());
        }

    }
}