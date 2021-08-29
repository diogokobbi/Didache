namespace Didache.Microservices.Catalog.API.Application
{
    public class QueryOptions: IQueryOptions
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public QueryOptions()
        {
            
        }
        
        public QueryOptions(int page = 1, int pageSize = 50)
        {
            this.Page = page;
            this.PageSize = pageSize;
        }
    }
}