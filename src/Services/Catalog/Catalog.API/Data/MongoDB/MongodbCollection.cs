using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Didache.Microservices.Catalog.API.Data.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;
using Didache.Microservices.Catalog.API.Application;

namespace Didache.Microservices.Catalog.API.Data.MongoDB
{
    public class MongodbCollection<T>: IDocumentDatabaseCollection<T> where T : IDocumentEntity
    {
        private IMongoCollection<T> _collection;
        
        public MongodbCollection(IMongoCollection<T> collection)
        {
            _collection = collection;
        }
        public async Task<T> FindAsync(string id)
        {
            var entityCollection = await _collection.FindAsync(c => c.Id == id);
            return await entityCollection.FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<T>> FindAsync(IQueryOptions queryOptions)
        {
            var findOptions = new FindOptions<T>();
            if(queryOptions != null)
            {
                findOptions.Skip = (queryOptions.Page - 1) * queryOptions.PageSize;
                findOptions.Limit = queryOptions.PageSize;
            }
            var entityCollection = await _collection.FindAsync(c => true, findOptions);
            return await entityCollection.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertOneAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ReplaceOneAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteOneAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}