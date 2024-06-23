using System.Collections.Generic;

namespace Producer
{
    public class Aluno
    {
        public string Matricula { get; set; }
        public string Email { get; set; }
        public Dictionary<string, object> Notas { get; set; }
        public AlunoStatus Status { get; set; }
    }
}
