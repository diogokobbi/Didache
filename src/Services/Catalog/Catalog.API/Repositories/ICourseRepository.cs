using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Didache.Microservices.Catalog.API.Application;
using Didache.Microservices.Catalog.API.Entities;

namespace Didache.Microservices.Catalog.API.Repositories
{
    public interface ICourseRepository
    {
        Task Create(Course product);
        Task<IEnumerable<Course>> Read(IQueryOptions queryOptions);
        Task<Course> Read(string id);
        Task<IEnumerable<Course>> Read(Func<Course,bool> expression);
        Task<bool> Update(Course product);
        Task<bool> Delete(string id);
    }
}