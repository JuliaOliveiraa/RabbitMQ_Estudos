using Consumer.Models;

namespace Consumer.Repositories
{
    public interface IAlunoRepository
    {
        Task InserirAlunoAsync(Aluno aluno);
    }
}
