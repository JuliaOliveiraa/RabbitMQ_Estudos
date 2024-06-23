using Consumer.Models;
using MongoDB.Driver;

namespace Consumer.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IMongoCollection<Aluno> _alunosCollection;

        public AlunoRepository(IMongoDatabase database)
        {
            _alunosCollection = database.GetCollection<Aluno>("alunos");
        }

        public async Task InserirAlunoAsync(Aluno aluno)
        {
            try
            {
                await _alunosCollection.InsertOneAsync(aluno);
                Console.WriteLine($"Aluno com Matrícula {aluno.Matricula} salvo no MongoDB.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar aluno no MongoDB: {ex.Message}");
            }
        }
    }
}
