using RabbitMQ.Client;

namespace Consumer.Infrastructure
{
    public class RabbitMQConnection
    {
        private static IConnection instance;
        private static readonly object lockObj = new object();

        private RabbitMQConnection() { }

        public static IConnection GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        var factory = new ConnectionFactory() { HostName = "localhost" };
                        instance = factory.CreateConnection();
                    }
                }
            }
            return instance;
        }
    }
}
