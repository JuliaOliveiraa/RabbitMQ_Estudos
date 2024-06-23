using Consumer.Models;
using System.Collections.Generic;

namespace Consumer.Repositories
{
    public interface IAlunoRepository
    {
        void InserirAluno(Aluno aluno);
        List<Aluno> ObterTodosAlunos();
    }
}
