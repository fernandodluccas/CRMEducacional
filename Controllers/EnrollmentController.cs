using CRMEducacional.Models;
using CRMEducacional.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRMEducacional.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            try
            {
                var enrollments = await _enrollmentRepository.GetAllEnrollments();
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            try
            {
                var enrollment = await _enrollmentRepository.GetEnrollmentById(id);
                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEnrollment([FromBody] Enrollment enrollment)
        {
            try
            {
                _enrollmentRepository.Create(enrollment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEnrollment([FromBody] Enrollment enrollment, int id)
        {
            try
            {
                Enrollment updatedEnrollment = await _enrollmentRepository.Update(enrollment, id);
                return Ok(updatedEnrollment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            try
            {
                _enrollmentRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}