namespace Didache.Microservices.Catalog.API.Application
{
    public interface IQueryOptions
    {
        public int Page { get; }
        public int PageSize { get; }
    }
}