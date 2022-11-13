using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.carreras;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.carreras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarreraPage : ContentPage
    {
        private CarreraService CarreraService;
        public CarreraPage()
        {
            InitializeComponent();
            CarreraService = new CarreraService();
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try
            {
                var datos = await CarreraService.GetCarreras();
                listRegistros.ItemsSource = new ObservableCollection<CarreraModel>(datos);
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void listRegistros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new CarreraActualizarEliminar((CarreraModel)e.SelectedItem));
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CarreraAgregar());
        }

    }
}