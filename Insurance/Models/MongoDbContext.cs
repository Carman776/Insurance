using MongoDB.Driver;
using MongoDB.Bson;

namespace Insurance.Models
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("DatabaseMongo"));
            Database = client.GetDatabase("Insurance");
        }

        public IMongoCollection<T>GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }
        
    }
}
