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
            // Aqui você pode adicionar lógica adicional para definir o status do aluno, se necessário
            _alunoRepository.InserirAluno(aluno);
        }
    }
}
