using System;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
namespace ItecSurApp.models
{
    public class ExcelService
    {
        private string AppFolder => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private Cell ConstructCell(string value, CellValues dataTypes) =>
            new Cell()
            {  
                 CellValue = new CellValue(value),
                 DataType = new EnumValue<CellValues>(dataTypes)
            };

        public string GenerateExcel(String archivo)
        {
            Environment.SetEnvironmentVariable("MONO_URI_DOTNETRELATIVEORABSOLUTE", "true");

            // Creando el documento de hoja de cálculo en el FilePath indicado
            var filePath = Path.Combine(AppFolder, archivo);
            var document = SpreadsheetDocument.Create(Path.Combine(AppFolder, archivo), SpreadsheetDocumentType.Workbook);

            var wbPart = document.AddWorkbookPart();
            wbPart.Workbook = new Workbook();

            var part = wbPart.AddNewPart<WorksheetPart>();
            part.Worksheet = new Worksheet(new SheetData());

            // Aquí se crean las hojas, puede agregar todas las hojas secundarias que necesite.
            var sheets = wbPart.Workbook.AppendChild
                (
                   new Sheets(
                            new Sheet()
                            {
                                Id = wbPart.GetIdOfPart(part),
                                SheetId = 1,
                                Name = "Usuario"
                            }
                        )
                );


            // Simplemente guarde y cierre su archivo de Excel
            wbPart.Workbook.Save();
            document.Close();
            // No olvides devolver la ruta del archivo
            return filePath;
        }

        public void InsertDataIntoSheet(string archivo, string sheetName, ExcelStructure data)
        {
            Environment.SetEnvironmentVariable("MONO_URI_DOTNETRELATIVEORABSOLUTE", "true");

            using (var document = SpreadsheetDocument.Open(archivo, true))
            {
                var wbPart = document.WorkbookPart;
                var sheets = wbPart.Workbook.GetFirstChild<Sheets>().
                             Elements<Sheet>().FirstOrDefault().
                             Name = sheetName;

                var part = wbPart.WorksheetParts.First();
                var sheetData = part.Worksheet.Elements<SheetData>().First();

                var row = sheetData.AppendChild(new Row());

                foreach (var header in data.Headers)
                { 
                    row.Append(ConstructCell(header, CellValues.String));
                }

                foreach (var value in data.Values)
                {
                    var dataRow = sheetData.AppendChild(new Row());

                    foreach (var dataElement in value)
                    { 
                        dataRow.Append(ConstructCell(dataElement, CellValues.String));
                    }
                } 
                wbPart.Workbook.Save(); 
            }
        }
    }
}
