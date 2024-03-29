using BusinessLogic.IBL;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectBL subjectBL;

        public SubjectController(ISubjectBL subjectBL)
        {
            this.subjectBL = subjectBL ?? throw new ArgumentNullException(nameof(subjectBL));
        }

        [HttpGet("{subjectId}")]
        public async Task<IActionResult> GetSubject(int subjectId)
        {
            try
            {
                var subject = await subjectBL.GetSubject(subjectId);
                if (subject == null)
                    return NotFound();

                return Ok(subject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] Subject subject)
        {
            try
            {
                await subjectBL.AddSubject(subject);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{subjectId}")]
        public async Task<IActionResult> UpdateSubject(int subjectId, [FromBody] Subject subject)
        {
            try
            {
                await subjectBL.UpdateSubject(subject, subjectId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{subjectId}")]
        public async Task<IActionResult> DeleteSubject(int subjectId)
        {
            try
            {
                await subjectBL.DeleteSubject(subjectId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
