using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Didache.Microservices.Catalog.API.Application;
using Didache.Microservices.Catalog.API.Data.Interfaces;
using Didache.Microservices.Catalog.API.Entities;
using Microsoft.VisualBasic;

namespace Didache.Microservices.Catalog.API.Repositories
{
    public class CourseRepository: ICourseRepository
    {
        private ICatalogContext _context;

        public CourseRepository(ICatalogContext context)
        {
            _context = context;
        }
        
        public Task Create(Course product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> Read(IQueryOptions queryOptions)
        {
            return await _context.Courses.FindAsync(queryOptions);
        }

        public async Task<Course> Read(string id)
        {
            return await _context.Courses.FindAsync(id);

        }

        public async Task<IEnumerable<Course>> Read(Func<Course, bool> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Course product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}