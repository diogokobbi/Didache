using System;
using System.Runtime.Serialization;
using Didache.Microservices.Catalog.API.Data.Interfaces;
using Didache.Microservices.Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Didache.Microservices.Catalog.API.Data
{
    public class CatalogContext: ICatalogContext
    {
        public IDocumentDatabaseCollection<Course> Courses { get; }
        
        public CatalogContext(IDocumentDatabaseClient documentDatabaseClient, IConfiguration configuration)
        {
            if (documentDatabaseClient == null || configuration == null)
            {
                throw new ArgumentNullException();
            }
                
            var database = documentDatabaseClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Courses = database.GetCollection<Course>("Courses");
        }
    }
}