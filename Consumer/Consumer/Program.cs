using System;
using Consumer.Factories;
using Consumer.Infrastructure;
using Consumer.Models;
using Consumer.Repositories;
using Consumer.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = MongoDBConnection.GetInstance();

            var connection = RabbitMQConnection.GetInstance();
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "alunos", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var alunoRepository = new AlunoRepository(database);
                var alunoService = new AlunoService(alunoRepository);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = System.Text.Encoding.UTF8.GetString(body);
                    var aluno = AlunoFactory.CriarAluno(message);

                    Console.WriteLine($" [x] Received {message}");

                    alunoService.ProcessarAluno(aluno);
                };

                channel.BasicConsume(queue: "alunos", autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
