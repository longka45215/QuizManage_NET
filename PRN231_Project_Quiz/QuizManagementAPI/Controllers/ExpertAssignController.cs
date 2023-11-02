using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertAssignController : ControllerBase
    {
        private readonly ExpertAssignService service;
        public ExpertAssignController(ExpertAssignService service)
        {
            this.service = service;
        }

        // GET api/<ExpertAssignController>/5
        [HttpGet("{userId}/{subjectId}")]
        public ActionResult<ExpertAssignDTO?> Get(int userId,string subjectId)
        {
            try
            {
                var exp = service.GetExpertAssign(userId, subjectId);
                if (exp == null)
                {
                    return NotFound();
                }
                return exp;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // POST api/<ExpertAssignController>
        [HttpPost]
        public IActionResult Post([FromBody] ExpertAssignDTO expertAssign)
        {
            try
            {
                service.SaveExpertAssign(expertAssign);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        // DELETE api/<ExpertAssignController>/5
        [HttpDelete("{userId}/{subjectId}")]
        public IActionResult Delete(int userId, string subjectId)
        {
            try
            {
                var exp = new ExpertAssignDTO
                {
                    UserId = userId,
                    SubjectId = subjectId
                };
                service.DeleteExpertAssign(exp);
                return Ok();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
