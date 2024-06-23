using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class Aluno
{
    public string Matricula { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public Dictionary<string, double> Notas { get; set; }
    public Dictionary<string, double> Frequencias { get; set; }
}

public class Program
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "alunos", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = System.Text.Encoding.UTF8.GetString(body);
                var aluno = JsonConvert.DeserializeObject<Aluno>(message);

                EnviarEmail(aluno);
            };

            channel.BasicConsume(queue: "alunos", autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    public static void EnviarEmail(Aluno aluno)
    {
        string assunto = "Resultado das Aprovações e Reprovações";
        string mensagem = GerarMensagem(aluno);

        var smtpClient = new SmtpClient("smtp.example.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("username", "password"),
            EnableSsl = true,
        };

        smtpClient.Send("from@example.com", aluno.Email, assunto, mensagem);
        Console.WriteLine($"Email sent to {aluno.Email}");
    }

    public static string GerarMensagem(Aluno aluno)
    {
        var mensagem = $"Olá {aluno.Nome},\n\n";
        mensagem += "Segue abaixo o resultado das suas aprovações e reprovações:\n";

        foreach (var materia in aluno.Notas.Keys)
        {
            var nota = aluno.Notas[materia];
            var frequencia = aluno.Frequencias[materia];
            var aprovado = nota >= 7 && frequencia >= 75;

            if (aprovado)
            {
                mensagem += $"- {materia}: Aprovado\n";
            }
            else
            {
                mensagem += $"- {materia}: Reprovado (";
                if (nota < 7)
                {
                    mensagem += "Nota baixa";
                }

                if (nota < 7 && frequencia < 75)
                {
                    mensagem += " e ";
                }

                if (frequencia < 75)
                {
                    mensagem += "Frequência baixa";
                }
                mensagem += ")\n";
            }
        }

        mensagem += "\nAtenciosamente,\nSua Instituição de Ensino";

        return mensagem;
    }
}
