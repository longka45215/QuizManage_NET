using BusinessObject.Models;
using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterService _service;
        public RegisterController(RegisterService service)
        {
            _service = service;
        }



        // GET: api/<RegisterController>
        [HttpGet("{UserId}/{CourseId}")]
        public ActionResult<RegisterDTO> Get(int UserId,string CourseId)
        {
            try
            {
                var register = _service.GetRegister(UserId, CourseId);
                if (register == null)
                {
                    return NotFound();
                }
                return register;
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<RegisterController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterDTO register)
        {
            try
            {
                _service.SaveRegister(register);
                return Ok();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }


        // DELETE api/<RegisterController>/5
        [HttpDelete("{UserId}/{CourseId}")]
        public IActionResult Delete(int UserId,string CourseId)
        {
            try
            {
                var register = new RegisterDTO
                {
                    UserId = UserId,
                    CourseId = CourseId
                };
                _service.DeleteRegister(register);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
    }
}
