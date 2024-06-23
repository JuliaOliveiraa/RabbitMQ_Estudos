using System.Collections.Generic;

namespace Producer
{
    public class NotasFileProcessor : IFileProcessor
    {
        public List<Dictionary<string, object>> ProcessarArquivo(string filePath)
        {
            return CsvHelper.LerCsv(filePath);
        }
    }
}
