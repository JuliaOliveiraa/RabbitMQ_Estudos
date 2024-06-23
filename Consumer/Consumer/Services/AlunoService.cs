using Consumer.Models;
using Consumer.Repositories;

namespace Consumer.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void ProcessarAluno(Aluno aluno)
        {
            //logica a implementar
            _alunoRepository.InserirAlunoAsync(aluno);
        }
    }
}
