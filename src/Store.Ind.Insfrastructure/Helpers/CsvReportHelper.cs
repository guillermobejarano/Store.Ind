using FileHelpers;
using Store.Ind.Domain.Dtos;
using Store.Ind.Insfrastructure.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Store.Ind.Insfrastructure.Helpers
{
    public class CsvReportHelper
    {
        /// <summary>
        /// Generación de un Archivo CSV
        /// </summary>
        /// <typeparam name="T">DTO Reporte CSV</typeparam>
        /// <param name="input">Colección de items que se exportará en el archivo</param>
        /// <param name="delimitador">Delimitador con el que se desea separar las columnas. El Delimitador por Default es coma</param>
        /// <param name="exportarHeaders">Indica si se agregar el nombre de las propiedades del DTO como headers del archivo. Por Default es true</param>
        /// <returns>Array de bites que representa un archivo CSV</returns>
        public byte[] WhriteCSVFile<T>(IEnumerable<T> input, CSVReportDelimiterEnum delimitador = CSVReportDelimiterEnum.SemiColon, bool exportarHeaders = true) where T : CsvReportBaseDto
        {
            var engine = new DelimitedFileEngine<T>(Encoding.UTF8);
            engine.Options.Delimiter = ObtenerDelimitador(delimitador);
            if (exportarHeaders)
                engine.HeaderText = typeof(T).GetCsvHeader(engine.Options.Delimiter);

            using (var stream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(stream, Encoding.UTF8))
                {
                    engine.WriteStream(streamWriter, input);
                    streamWriter.Flush();
                    stream.Position = 0;

                    return stream.ToArray();
                }
            }
        }

        private string ObtenerDelimitador(CSVReportDelimiterEnum delimitador)
        {
            string delimiter = ";";

            switch (delimitador)
            {
                case CSVReportDelimiterEnum.VerticalBar:
                    delimiter = "|";
                    break;
                case CSVReportDelimiterEnum.Comma:
                    delimiter = ",";
                    break;
                case CSVReportDelimiterEnum.Tab:
                    delimiter = "\t";
                    break;
            }

            return delimiter;
        }
    }
    /// <summary>
    /// Delimitadores posibles para la exportación de un archivo CVS
    /// </summary>
    public enum CSVReportDelimiterEnum
    {
        /// <summary>
        /// Delimitador de Barra Vertical: |
        /// </summary>
        VerticalBar,

        /// <summary>
        /// Delimitador de punto y coma: ;
        /// </summary>
        SemiColon,

        /// <summary>
        /// Delimitador de coma: ,
        /// NOTA: Este es el delimitador que se toma como Default en el Helper de CsvReportHelper
        /// </summary>
        Comma,

        /// <summary>
        /// Delimitador de TAB
        /// </summary>
        Tab
    }
}
