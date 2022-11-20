using ItecSurApp.models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ItecSurApp.GenerateExcel
{
    public partial class ExportingEPage : ContentPage
    {
        public ExportingEPage()
        {
          InitializeComponent();
            BindingContext = new ExportingExcelViewModel();
        }
    }
}
