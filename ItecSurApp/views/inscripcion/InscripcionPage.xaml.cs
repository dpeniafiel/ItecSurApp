using ItecSurApp.models;
using ItecSurApp.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.inscripcion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscripcionPage : ContentPage
    {
        private PeriodoService periodoService;
        private CarreraService carreraService;
        private NivelService nivelService;
        private JornadaService jornadaService;
        private InscripcionService inscripcionService;
        public InscripcionPage()
        {
            InitializeComponent();
            periodoService = new PeriodoService();
            carreraService = new CarreraService();
            nivelService = new NivelService();
            jornadaService = new JornadaService();
            inscripcionService = new InscripcionService();
            CargarPeriodos();
        }

        private async void CargarPeriodos()
        {
            var periodos = await periodoService.GetPeriodosActivos();
            cmbPeriodo.ItemsSource = new ObservableCollection<PeriodoModel>(periodos);
        }

        private async void CargarCarreras()
        {
            PeriodoModel periodo = cmbPeriodo.SelectedItem as PeriodoModel;
            var carreras = await carreraService.GetCarrerasActivasPorPeriodo(periodo.codigo);
            cmbCarrera.ItemsSource = new ObservableCollection<CarreraModel>(carreras);
        }

        private async void CargarNiveles()
        {
            CarreraModel carrera = cmbCarrera.SelectedItem as CarreraModel;
            var niveles = await nivelService.GetNivelesActivosPorCarrera(carrera.codigo);
            cmbNivel.ItemsSource = new ObservableCollection<NivelModel>(niveles);
        }

        private async void CargarJornadas()
        {
            NivelModel nivel = cmbNivel.SelectedItem as NivelModel;
            var jornadas = await jornadaService.GetJornadasActivasPorNivel(nivel.codigo);
            foreach(var jornada in jornadas)
            {
                jornada.nombre = jornada.nombre + " " + jornada.descripcion;
            }
            cmbJornada.ItemsSource = new ObservableCollection<JornadaModel>(jornadas);
        }


        private async void btnInscribir_Clicked(object sender, EventArgs e)
        {
            try {
                InscripcionModel inscripcionModel = new InscripcionModel();
                inscripcionModel.usuario_codigo = App.Usuario.codigo;
                JornadaModel jornadaModel = (JornadaModel)cmbJornada.SelectedItem;
                inscripcionModel.jornada_codigo = jornadaModel.codigo;
                inscripcionModel.estado = "INSCRITO";
                await inscripcionService.PostInscripcion(inscripcionModel);
                await DisplayAlert("CORRECTO", "Estudiante inscrito con éxito", "Aceptar");
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "Procesando la inscripción, "+ex.Message, "Aceptar");
            }
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCarreras();
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNiveles();
        }

        private void cmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarJornadas();
        }
    }
}