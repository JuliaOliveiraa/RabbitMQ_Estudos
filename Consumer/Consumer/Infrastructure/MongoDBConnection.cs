using MongoDB.Driver;

namespace Consumer.Infrastructure
{
    public class MongoDBConnection
    {
        private static IMongoDatabase instance;
        private static readonly object lockObj = new object();

        private MongoDBConnection() { }

        public static IMongoDatabase GetInstance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        var client = new MongoClient("mongodb://localhost:27017");
                        instance = client.GetDatabase("localTeste");
                    }
                }
            }
            return instance;
        }
    }
}
