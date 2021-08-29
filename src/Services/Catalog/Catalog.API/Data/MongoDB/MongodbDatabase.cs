using Didache.Microservices.Catalog.API.Data.Interfaces;
using MongoDB.Driver;

namespace Didache.Microservices.Catalog.API.Data.MongoDB
{
    public class MongodbDatabase: IDocumentDatabase
    {
        private readonly IMongoDatabase _database;

        public MongodbDatabase(IMongoDatabase mongoDatabase)
        {
            _database = mongoDatabase;
        }
        public IDocumentDatabaseCollection<T> GetCollection<T>(string collectionName) where T: IDocumentEntity
        {
            var collection = _database.GetCollection<T>(collectionName);
            return new MongodbCollection<T>(collection);
        }
    }
}