using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.inicio
{
    public partial class InicioPage : MasterDetailPage
    {
        public InicioPage()
        {
            InitializeComponent();
            this.Master = new InicioMenu();
            this.Detail = new NavigationPage(new InicioDetail());
            App.MasterDet = this;
        }
    }
}