using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam1.DTO;
using OnlineExam1.Entity;
using OnlineExam1.Repo;
using Microsoft.AspNetCore.Authorization;

namespace OnlineExam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedTestController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly ILogger<AssignedTestController> _logger;
        public AssignedTestController(MyContext context, ILogger<AssignedTestController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _logger = logger;
        }
        // GET: api/AssignedTest
        [HttpGet, Route("GetAssignedTests")]
        public ActionResult<IEnumerable<AssignedTestDTO>> GetAssignedTests()
        {
            try
            {
                var assignedTests = unitOfWork.AssignedTestRepoImplObject.GetAll();
                return Ok(assignedTests);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/AssignedTest/5
        [HttpGet, Route("GetAssignedTest/{id}")]
        public ActionResult<AssignedTestDTO> GetAssignedTest(int id)
        {
            try
            {
                var assignedTest = unitOfWork.AssignedTestRepoImplObject.GetById(id);

                if (assignedTest == null)
                {
                    return NotFound();
                }

                return Ok(assignedTest);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/AssignedTest
        [HttpPost, Route("PostAssignedTest")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<AssignedTestDTO> PostAssignedTest(AssignedTestDTO assignedTestDTO)
        {
            try
            {
                unitOfWork.AssignedTestRepoImplObject.Add(assignedTestDTO);
                unitOfWork.SaveAll();

                return CreatedAtAction(nameof(GetAssignedTest), new { id = assignedTestDTO.AssignmentID }, assignedTestDTO);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/AssignedTest/5
        [HttpPut, Route("PutAssignedTest/{id}")]
       // [Authorize(Roles = "Admin")]
        public IActionResult PutAssignedTest(int id, AssignedTestDTO assignedTestDTO)
        {
            try
            {
                if (id != assignedTestDTO.AssignmentID)
                {
                    return BadRequest();
                }

                bool success = unitOfWork.AssignedTestRepoImplObject.Update(id, assignedTestDTO);

                if (!success)
                {
                    return NotFound();
                }

                unitOfWork.SaveAll();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // DELETE: api/AssignedTest/5
        [HttpDelete("DeleteAssignedTest/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteAssignedTest(int id)
        {
            try
            {
                bool success = unitOfWork.AssignedTestRepoImplObject.Delete(id);

                if (!success)
                {
                    return NotFound();
                }

                unitOfWork.SaveAll();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


    }
}
