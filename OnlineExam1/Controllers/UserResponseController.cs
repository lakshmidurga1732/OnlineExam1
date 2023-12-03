using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam1.DTO;
using OnlineExam1.Entity;
using OnlineExam1.Repo;

namespace OnlineExam1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserResponseController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly ILogger<UserResponseController> _logger;

        public UserResponseController(MyContext context, ILogger<UserResponseController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _logger = logger;
        }

        // GET: api/UserResponse
        [HttpGet, Route("GetAll")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<UserResponseDTO>> GetUserResponses()
        {
            try
            {
                var userResponses = unitOfWork.UserResponseRepoImplObject.GetAll();
                return Ok(userResponses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);

            }
        }

        // GET: api/UserResponse/5
        [HttpGet, Route("GetById/{id}")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<UserResponseDTO> GetUserResponse(int id)
        {
            try
            {
                var userResponse = unitOfWork.UserResponseRepoImplObject.GetById(id);

                if (userResponse == null)
                {
                    return NotFound();
                }

                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);

            }
        }

        // POST: api/UserResponse
        [HttpPost, Route("Add")]
        //[Authorize(Roles = "Admin")]
        public ActionResult<UserResponseDTO> PostUserResponse(UserResponseDTO userResponseDTO)
        {
            try
            {

                unitOfWork.UserResponseRepoImplObject.Add(userResponseDTO);
                unitOfWork.SaveAll();

                return CreatedAtAction(nameof(GetUserResponse), new { id = userResponseDTO.ResponseID }, userResponseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);

            }
        }

        // PUT: api/UserResponse/5
        [HttpPut, Route("Update/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult PutUserResponse(int id, UserResponseDTO userResponseDTO)
        {
            try
            {
                if (id != userResponseDTO.ResponseID)
                {
                    return BadRequest();
                }

                bool success = unitOfWork.UserResponseRepoImplObject.Update(id, userResponseDTO);

                if (!success)
                {
                    return NotFound();
                }

                unitOfWork.SaveAll();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);

            }
        }

        // DELETE: api/UserResponse/5
        [HttpDelete, Route("Delete/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteUserResponse(int id)
        {
            try
            {
                bool success = unitOfWork.UserResponseRepoImplObject.Delete(id);

                if (!success)
                {
                    return NotFound();
                }

                unitOfWork.SaveAll();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);

            }
        }
    }
}