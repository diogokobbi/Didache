using Didache.Microservices.Catalog.API.Entities;
using MongoDB.Driver;

namespace Didache.Microservices.Catalog.API.Data.Interfaces
{
    public interface ICatalogContext
    {
        IDocumentDatabaseCollection<Course> Courses { get; }
    }
}