using CRMEducacional.Models;
using CRMEducacional.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRMEducacional.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)

        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseRepository.GetCourseById(id);
            return Ok(course);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            _courseRepository.Create(course);
            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Course course, int id)
        {
            await _courseRepository.Update(course, id);
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(id);
            return Ok();
        }
    }
}
