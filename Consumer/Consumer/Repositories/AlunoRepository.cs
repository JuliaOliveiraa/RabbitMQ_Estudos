using Consumer.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Consumer.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Aluno> _alunosCollection;

        public AlunoRepository(IMongoDatabase database)
        {
            _database = database;
            _alunosCollection = _database.GetCollection<Aluno>("alunos");
        }

        public void InserirAluno(Aluno aluno)
        {
            _alunosCollection.InsertOne(aluno);
        }

        public List<Aluno> ObterTodosAlunos()
        {
            return _alunosCollection.Find(a => true).ToList();
        }
    }
}
