using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Consumer.Models
{
    public class Aluno
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Dictionary<string, double> Notas { get; set; }
        public AlunoStatus Status { get; set; }
    }
}
