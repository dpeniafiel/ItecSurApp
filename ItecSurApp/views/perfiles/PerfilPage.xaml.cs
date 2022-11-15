using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.perfiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.perfiles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilPage : ContentPage
    {
        private PerfilService PerfilService;
        public PerfilPage()
        {
            InitializeComponent();
            PerfilService = new PerfilService();
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try
            {
                var datos = await PerfilService.GetPerfiles();
                listRegistros.ItemsSource = new ObservableCollection<PerfilModel>(datos);
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void listRegistros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PerfilActualizarEliminar((PerfilModel)e.SelectedItem));
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PerfilAgregar());
        }

    }
}