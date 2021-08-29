namespace Didache.Microservices.Catalog.API.Data.Interfaces
{
    public interface IDocumentDatabase
    {
        IDocumentDatabaseCollection<T> GetCollection<T>(string collectionName) where T: IDocumentEntity;
    }
}