using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Didache.Microservices.Catalog.API.Application;
using Didache.Microservices.Catalog.API.Entities;
using Didache.Microservices.Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Didache.Microservices.Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICourseRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ICourseRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Course>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses([FromQuery] QueryOptions queryOptions)
        {
            var courses = await _repository.Read(queryOptions ?? new QueryOptions());
            return Ok(courses);
        }

        [HttpGet("{id:length(24)}", Name = "GetCourseById")]
        [ProducesResponseType(typeof(Course), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Course>> GetCourseById([FromRoute] string id)
        {
            var course = await _repository.Read(id);
            if (course != null)
            {
                return Ok(course);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost(Name = "CreateCourse")]
        [ProducesResponseType(typeof(Course), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Course>> Create([FromBody] Course course)
        {
            await _repository.Create(course);
            
            //HATEOAS
            return CreatedAtRoute("GetCourseById", new { id = course.Id }, course);
        }

        [HttpPut(Name = "UpdateCourse")]
        [ProducesResponseType(typeof(Course), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCourse([FromBody] Course course)
        {
            return Ok(await _repository.Update(course));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteCourse")]
        [ProducesResponseType(typeof(Course), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}