using System.Collections.Generic;

namespace Producer
{
    public class NotasAlunoFactory : IAlunoFactory
    {
        public Aluno CriarAluno(Dictionary<string, object> notas, List<Dictionary<string, object>> frequencias)
        {
            var matricula = notas["Matricula"].ToString();
            var email = notas["Email Aluno"].ToString();

            var aluno = new Aluno
            {
                Matricula = matricula,
                Email = email,
                Notas = notas,
                Status = frequencias.Exists(f => f["Matricula"].ToString() == matricula) ? AlunoStatus.Sucesso : AlunoStatus.FrequenciaNaoRegistrada
            };

            return aluno;
        }
    }
}
