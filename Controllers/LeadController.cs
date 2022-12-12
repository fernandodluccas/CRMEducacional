using CRMEducacional.Models;
using CRMEducacional.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace CRMEducacional.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LeadController : Controller
    {
        private readonly ILeadRepository _leadRepository;

        public LeadController(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeads()
        {
            var leads = await _leadRepository.GetAllLeads();
            return Ok(leads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeadById([FromRoute] int id)
        {
            var lead = await _leadRepository.GetLeadById(id);
            return Ok(lead);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Lead lead)
        {
            _leadRepository.Create(lead);
            return Ok(lead);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Lead lead, int id)
        {
            await _leadRepository.Update(lead, id);
            return Ok(lead);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _leadRepository.Delete(id);

            return NoContent();
        }
    }
}