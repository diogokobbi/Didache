using System;
using Didache.Microservices.Catalog.API.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Didache.Microservices.Catalog.API.Data.MongoDB
{
    public class MongodbDatabaseClient: IDocumentDatabaseClient
    {
        private IMongoClient _client;
        public MongodbDatabaseClient(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException();
            }
            _client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }
        public IDocumentDatabase GetDatabase(string databaseName)
        {
            var mongodbDatabase = _client.GetDatabase(databaseName);
            return new MongodbDatabase(mongodbDatabase);
        }
    }
}