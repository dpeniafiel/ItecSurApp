using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.informes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informe1 : ContentPage
    {
        public Informe1()
        {
            InitializeComponent();
            paginaweb.Source = "https://app.powerbi.com/view?r=eyJrIjoiOTg4OGM4ZGMtMGViMy00M2ZiLWI5ZGQtMTNhZGQ2ZjI1ZTg1IiwidCI6IjY4NjA4ZWNiLTY1M2YtNGI2YS04MzVmLTMzZmY5M2Q5MDNiNSJ9&pageName=ReportSection";
        }
    }
}