using System.Collections.Generic;

namespace Producer
{
    public interface IFileProcessor
    {
        List<Dictionary<string, object>> ProcessarArquivo(string filePath);
    }
}
