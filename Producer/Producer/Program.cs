using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: program <notas_csv_path> <frequencias_csv_path>");
                return;
            }

            var notasCsvPath = args[0];
            var frequenciasCsvPath = args[1];

            var alunos = ProcessarArquivos(notasCsvPath, frequenciasCsvPath);
            EnviarParaFila(alunos);
        }

        static List<Aluno> ProcessarArquivos(string notasCsvPath, string frequenciasCsvPath)
        {
            var notasFileProcessor = new NotasFileProcessor();
            var frequenciasFileProcessor = new FrequenciasFileProcessor();
            var alunos = new List<Aluno>();

            var notasAlunos = notasFileProcessor.ProcessarArquivo(notasCsvPath);
            var frequenciasAlunos = frequenciasFileProcessor.ProcessarArquivo(frequenciasCsvPath);

            var notasAlunoFactory = new NotasAlunoFactory();

            foreach (var alunoNota in notasAlunos)
            {
                var aluno = notasAlunoFactory.CriarAluno(alunoNota, frequenciasAlunos);
                alunos.Add(aluno);
            }

            return alunos;
        }

        static void EnviarParaFila(List<Aluno> alunos)
        {
            var connection = RabbitMQConnection.GetInstance();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "alunos", durable: false, exclusive: false, autoDelete: false, arguments: null);

                foreach (var aluno in alunos)
                {
                    var message = JsonConvert.SerializeObject(aluno);
                    var body = System.Text.Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "", routingKey: "alunos", basicProperties: null, body: body);
                    Console.WriteLine($" [x] Sent {message}");
                }
            }
        }
    }
}
