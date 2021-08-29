using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Didache.Microservices.Catalog.API.Application;

namespace Didache.Microservices.Catalog.API.Data.Interfaces
{
    public interface IDocumentDatabaseCollection<T> where T : IDocumentEntity
    {
        Task<IEnumerable<T>> FindAsync(IQueryOptions queryOptions);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        Task<T> FindAsync(string id);
        Task<bool> InsertOneAsync(T entity);
        Task<bool> ReplaceOneAsync(T entity);
        Task<bool> DeleteOneAsync(T entity);
    }
}