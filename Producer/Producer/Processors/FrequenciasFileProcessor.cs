using System.Collections.Generic;

namespace Producer
{
    public class FrequenciasFileProcessor : IFileProcessor
    {
        public List<Dictionary<string, object>> ProcessarArquivo(string filePath)
        {
            return CsvHelper.LerCsv(filePath);
        }
    }
}
