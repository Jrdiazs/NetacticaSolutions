using CsvHelper;
using CsvHelper.Configuration;
using Netactica.Tools.StringTools;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Netactica.Tools
{
    /// <summary>
    /// Clase para generar metodos de exportacion
    /// </summary>
    public class ExportTools
    {
        /// <summary>
        /// Exporta un listado a un csv
        /// </summary>
        /// <typeparam name="T">tipo de dato listado</typeparam>
        /// <param name="path">path</param>
        /// <param name="records">listado</param>
        public static void ToCsv<T>(string path, List<T> records, string delimiter = ";", bool printheader = false, ClassMap map = null)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                if (File.Exists(path))
                    File.Delete(path);

                using (var writer = new StreamWriter(path))
                {
                    var config = new Configuration();
                    config.CultureInfo = CultureInfo.CreateSpecificCulture("es-CO");
                    config.Encoding = Encoding.UTF8;
                    config.HasHeaderRecord = printheader;

                    if (map != null)
                        config.RegisterClassMap(map);

                    config.Delimiter = delimiter;
                    using (var csv = new CsvWriter(writer, config))
                    {
                        csv.WriteRecords(records);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="path"></param>
        /// <param name="nameSheet"></param>
        /// <param name="printHeadersProperties"></param>
        /// <param name="headers"></param>
        public static void ToExcel<T>(IEnumerable<T> data, string path, string nameSheet = "sheet1", bool printHeadersProperties = true, string[] headers = null)
        {
            try
            {
                headers = headers ?? new string[] { };

                if (nameSheet.IsEmpty())
                    throw new Exception("el nombre de la hoja no puede ser null !!");

                using (var pck = new ExcelPackage())
                {
                    var ws = pck.Workbook.Worksheets.Add(nameSheet);

                    if (!printHeadersProperties)
                    {
                        if (!headers.Any())
                            throw new Exception("debe declarar los nombres de las columnas");

                        var COLUMN = 'A';
                        var ROW = 1;
                        foreach (var headerText in headers)
                        {
                            ws.Cells[string.Format("{0}{1}", COLUMN, ROW)].Value = headerText;
                            COLUMN++;
                        }

                        ws.Cells["A2"].LoadFromCollection(data, PrintHeaders: false);
                    }
                    else
                    {
                        ws.Cells["A1"].LoadFromCollection(data, printHeadersProperties);
                    }

                    if (path.IsEmpty())
                        throw new Exception("el path no puede ser null !!");

                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                        Directory.CreateDirectory(Path.GetDirectoryName(path));

                    using (var stream = File.Create(path))
                    {
                        pck.SaveAs(stream);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crea un archivo excel a partir de una lista de datos y retorna un array de bytes con el contenido
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameSheet">Nombre de la hoja </param>
        /// <param name="printHeadersProperties">determina si imprime el encabezado de columnas </param>
        /// <param name="headers">listado de nombres de las columnas</param>
        public static byte[] ToExcel<T>(IEnumerable<T> data, string nameSheet = "sheet1", bool printHeadersProperties = true, string[] headers = null)
        {
            try
            {
                byte[] file = null;
                headers = headers ?? new string[] { };

                if (nameSheet.IsEmpty())
                    throw new Exception("el nombre de la hoja no puede ser null !!");

                using (var pck = new ExcelPackage())
                {
                    var ws = pck.Workbook.Worksheets.Add(nameSheet);

                    if (!printHeadersProperties)
                    {
                        if (!headers.Any())
                            throw new Exception("debe declarar los nombres de las columnas");

                        var COLUMN = 'A';
                        var ROW = 1;
                        foreach (var headerText in headers)
                        {
                            ws.Cells[string.Format("{0}{1}", COLUMN, ROW)].Value = headerText;
                            COLUMN++;
                        }

                        ws.Cells["A2"].LoadFromCollection(data, PrintHeaders: false);
                    }
                    else
                    {
                        ws.Cells["A1"].LoadFromCollection(data, printHeadersProperties);
                    }

                    pck.Save();

                    file = pck.GetAsByteArray();

                    return file;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee un archivo csv y lo convierte a un listado t
        /// </summary>
        /// <typeparam name="T">tipo de dato</typeparam>
        /// <param name="path"></param>
        /// <param name="headerRecord"></param>
        /// <param name="map"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static List<T> ReadCsv<T>(string path, bool headerRecord = false, ClassMap map = null, string delimiter = ";")
        {
            try
            {
                var data = new List<T>();
                var config = new Configuration()
                {
                    HasHeaderRecord = headerRecord,
                    CultureInfo = CultureInfo.CreateSpecificCulture("es-CO"),
                    Encoding = Encoding.UTF8,
                    Delimiter = delimiter
                };

                if (map != null)
                    config.RegisterClassMap(map);

                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<T>();
                    if (records.Any()) data = records.ToList();
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee un archivo csv y lo convierte a un listado t
        /// </summary>
        /// <typeparam name="T">tipo de dato</typeparam>
        /// <param name="file">array de bytes</param>
        /// <param name="headerRecord"></param>
        /// <param name="map"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static List<T> ReadCsv<T>(byte[] file, bool headerRecord = false, ClassMap map = null, string delimiter = ";")
        {
            try
            {
                var data = new List<T>();
                var config = new Configuration()
                {
                    HasHeaderRecord = headerRecord,
                    CultureInfo = CultureInfo.CreateSpecificCulture("es-CO"),
                    Encoding = Encoding.UTF8,
                    Delimiter = delimiter
                };

                if (map != null)
                    config.RegisterClassMap(map);

                using (var stream = new MemoryStream(file))
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<T>();
                    if (records.Any()) data = records.ToList();
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crea un archivo excel a partir de un datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">lista generica</param>
        /// <param name="nameSheet">nombre de la hoja</param>
        /// <param name="printHeaders">imprime los encabezados</param>
        /// <returns> byte[]</returns>
        public static byte[] ToExcel(DataTable table, string nameSheet, bool printHeaders)
        {
            try
            {
                byte[] fileEcel = null;
                using (var pck = new ExcelPackage())
                {
                    var ws = pck.Workbook.Worksheets.Add(nameSheet);
                    ws.Cells["A1"].LoadFromDataTable(table, printHeaders);
                    fileEcel = pck.GetAsByteArray();
                }
                return fileEcel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}