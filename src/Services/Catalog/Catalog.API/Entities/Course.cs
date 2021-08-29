using System.Collections.Generic;
using Didache.Microservices.Catalog.API.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Didache.Microservices.Catalog.API.Entities
{
    public class Course: IDocumentEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        
        public string[] Programs { get; set; }
        public int Credits { get; set; }
        
        public double Price { get; set; }
    }
}