using ItecSurApp.GenerateExcel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace ItecSurApp.models
{
    public class ExportingExcelViewModel
    {
        public  ICommand ExportToExcelCommand { private set; get; }
        private ExcelService excelService;
        public  ObservableCollection<Usuario> contacts;
        

        public ExportingExcelViewModel()
        {
            contacts = new ObservableCollection<Usuario>
            {
                new Usuario{  primer_nombre="Diego",       segundo_nombre="Armando",   primer_apellido="Penafiel" },
                new Usuario{  primer_nombre="Ronald",      segundo_nombre="Wilfrido", primer_apellido="Gubio" },
                new Usuario{  primer_nombre="Carlos",     segundo_nombre="Arturo",  primer_apellido="Munioz" }, 
            };

            ExportToExcelCommand = new Command(async () => await ExportToExcel());
            excelService = new ExcelService();
        }

        async Task ExportToExcel()
        { 
            var fileprimer_nombre = $"Usuario-{Guid.NewGuid()}.xlsx";
            string filepath = excelService.GenerateExcel(fileprimer_nombre);

            var data = new ExcelStructure
            {
                Headers = new List<string>() { "primer_nombre", "segundo_nombre", "primer_apellido" }
            };

            foreach (var item in contacts)
            { 
                data.Values.Add(new List<string>() { item.primer_nombre, item.segundo_nombre, item.primer_apellido });
            }

            excelService.InsertDataIntoSheet(filepath, "Usuario",data);

            await Launcher.OpenAsync(new OpenFileRequest()
            {
                File = new ReadOnlyFile(filepath)
            });
        }

        
    }
}
