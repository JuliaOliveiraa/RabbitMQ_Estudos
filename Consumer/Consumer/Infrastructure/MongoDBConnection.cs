using MongoDB.Driver;

namespace Consumer.Infrastructure
{
    public class MongoDBConnection
    {
        private static IMongoDatabase instance;
        private static readonly object lockObj = new object();

        private MongoDBConnection() { }

        public static IMongoDatabase GetInstance(string connectionString, string databaseName)
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        var client = new MongoClient(connectionString);
                        instance = client.GetDatabase(databaseName);
                    }
                }
            }
            return instance;
        }
    }
}
