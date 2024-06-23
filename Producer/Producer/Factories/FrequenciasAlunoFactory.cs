using System.Collections.Generic;

namespace Producer
{
    public class FrequenciasAlunoFactory : IAlunoFactory
    {
        public Aluno CriarAluno(Dictionary<string, object> frequencia, List<Dictionary<string, object>> frequencias)
        {
            var matricula = frequencia["Matricula"].ToString();
            var email = frequencia.ContainsKey("Email Aluno") ? frequencia["Email Aluno"].ToString() : "";

            var aluno = new Aluno
            {
                Matricula = matricula,
                Email = email,
                Notas = new Dictionary<string, object>(),
                Status = AlunoStatus.FrequenciaRegistrada
            };

            return aluno;
        }
    }
}
