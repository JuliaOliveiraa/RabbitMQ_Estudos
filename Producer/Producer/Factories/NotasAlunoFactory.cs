using System;
using System.Collections.Generic;

namespace Producer
{
    public class NotasAlunoFactory : IAlunoFactory
    {
        public Aluno CriarAluno(Dictionary<string, object> notas, List<Dictionary<string, object>> frequencias)
        {
            var matricula = notas["Matricula"].ToString();
            var email = notas["Email Aluno"].ToString();

            var notasAluno = new Dictionary<string, object>();

            foreach (var notaKey in notas.Keys)
            {
                if (notaKey == "Matricula" || notaKey == "Email Aluno" || notaKey == "Nome Aluno")
                {
                    continue;
                }

                notasAluno.Add(notaKey, notas[notaKey]);
            }

            var aluno = new Aluno
            {
                Matricula = matricula,
                Email = email,
                Notas = notasAluno,
                Status = frequencias.Exists(f => f["Matricula"].ToString() == matricula) ? AlunoStatus.Sucesso : AlunoStatus.FrequenciaNaoRegistrada
            };

            return aluno;
        }
    }
}
