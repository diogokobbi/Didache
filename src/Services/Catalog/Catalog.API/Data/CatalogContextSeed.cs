using System.Collections;
using System.Collections.Generic;
using Didache.Microservices.Catalog.API.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Didache.Microservices.Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Course> courseCollection)
        {
            bool existCourse = courseCollection.Find(c => true).Any();
            if (!existCourse)
            {
                courseCollection.InsertManyAsync(GetDemoCourses());
            }
        }

        private static IEnumerable<Course> GetDemoCourses()
        {
            return new List<Course>()
            {
                new Course()
                {
                    Name = "Abc",
                    Credits = 1,
                    Description = "",
                    Summary = ""
                }
            };
        }
    }
}