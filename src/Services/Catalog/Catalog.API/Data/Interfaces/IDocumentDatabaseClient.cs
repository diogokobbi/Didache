namespace Didache.Microservices.Catalog.API.Data.Interfaces
{
    public interface IDocumentDatabaseClient
    {
        IDocumentDatabase GetDatabase(string databaseName);
    }
}