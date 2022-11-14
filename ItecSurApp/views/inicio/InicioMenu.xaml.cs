using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.cambioClave;
using ItecSurApp.views.carreras;
using ItecSurApp.views.jornadas;
using ItecSurApp.views.nivel;
using ItecSurApp.views.permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.inicio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioMenu : ContentPage
    {
        public InicioMenu()
        {
            InitializeComponent();
            DeshabilitarBotones();
            VerificarPermisos();
            IniciarDatosInformativos();
        }

        private void IniciarDatosInformativos()
        {
            lblPerfil.Text = App.Perfil.nombre;
            lblUsuario.Text = App.Usuario.usuario;
        }

        private void DeshabilitarBotones()
        {
            btnPeriodo.IsVisible = false;
            btnCarrera.IsVisible = false;
            btnNivel.IsVisible = false;
            btnJornada.IsVisible = false;
            btnInscripcion.IsVisible = false;
            btnPerfil.IsVisible = false;
            btnUsuario.IsVisible = false;
            btnPermisos.IsVisible = false;
        }

        private void VerificarPermisos()
        {
            foreach (var permiso in App.Permisos)
            {
                if (permiso.opcion_codigo.Equals("PERIODO"))
                {
                    btnPeriodo.IsVisible = true;
                }

                if (permiso.opcion_codigo.Equals("CARRERA"))
                {
                    btnCarrera.IsVisible = true;
                }

                if (permiso.opcion_codigo.Equals("NIVEL"))
                {
                    btnNivel.IsVisible = true;
                }

                if (permiso.opcion_codigo.Equals("JORNADA"))
                {
                    btnJornada.IsVisible = true;
                }

                if (permiso.opcion_codigo.Equals("INSCRIPCION"))
                {
                    btnInscripcion.IsVisible = true;
                }

                if (permiso.opcion_codigo.Equals("PERFIL"))
                {
                    btnPerfil.IsVisible = true;
                }

                if (permiso.opcion_codigo.Equals("USUARIO"))
                {
                    btnUsuario.IsVisible = true;
                }

                if (permiso.opcion_codigo.Equals("PERMISO"))
                {
                    btnPermisos.IsVisible = true;
                }
            }
        }

        private async void btnPeriodo_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new PeriodoPage());
        }

        private async void btnCarrera_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new CarreraPage());
        }

        private async void btnNivel_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new NivelPage());
        }

        private async void btnJornada_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new JornadaPage());
        }

        private void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            App.Permisos = new List<PermisoModel>();
            Navigation.PopToRootAsync();
        }

        private async void btnUsuario_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void btnPermisos_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new PermisoPage());
        }

        private async void btnCambiarClave_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new CambioClavePage());
        }
    }
}