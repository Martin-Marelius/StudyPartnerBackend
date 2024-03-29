using BusinessLogic.IBL;
using Database.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseBL courseBL;

        public CourseController(ICourseBL courseBL)
        {
            this.courseBL = courseBL;
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourse(string courseId)
        {
            try
            {
                var course = await courseBL.GetCourse(courseId);
                if (course == null)
                    return NotFound();

                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            try
            {
                await courseBL.AddCourse(course);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse(string courseId, [FromBody] Course course)
        {
            try
            {
                await courseBL.UpdateCourse(course, courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(string courseId)
        {
            try
            {
                await courseBL.DeleteCourse(courseId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
