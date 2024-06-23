using Consumer.Models;
using Newtonsoft.Json;

namespace Consumer.Factories
{
    public static class AlunoFactory
    {
        public static Aluno CriarAluno(string message)
        {
            var aluno = JsonConvert.DeserializeObject<Aluno>(message);
            return aluno;
        }
    }
}
