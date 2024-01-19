using BusinessObject.Models;
using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpertAssignController : ControllerBase
    {
        private readonly ExpertAssignService service;
        public ExpertAssignController(ExpertAssignService service)
        {
            this.service = service;
        }

        // GET api/<ExpertAssignController>/5
        [HttpGet("{subjectId}")]
        public ActionResult<ExpertAssignDTO> Get(string subjectId)
        {
            try
            {
                var exp = service.GetExpertAssign().FirstOrDefault(x=>x.SubjectId.Equals(subjectId));
                if (exp == null)
                {
                    return NotFound();
                }
                return Ok(exp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet("{UserId}")]
        public ActionResult<List<ExpertAssignDTO>> GetExpert(int UserId)
        {
            try
            {
                var exp = service.GetExpertAssign().Where(x => x.UserId==UserId);
                if (exp == null)
                {
                    return NotFound();
                }
                return Ok(exp);
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
                var exp = service.GetExpertAssign().FirstOrDefault(x => x.SubjectId.Equals(expertAssign.SubjectId));
                if (exp != null)
                {
                    service.DeleteExpertAssign(exp);
                }
                service.SaveExpertAssign(expertAssign);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        // DELETE api/<ExpertAssignController>/5
        [HttpDelete("{subjectId}")]
        public IActionResult Delete(string subjectId)
        {
            try
            {
                var exp = service.GetExpertAssign().FirstOrDefault(x => x.SubjectId.Equals(subjectId));
                if (exp != null) {
                    service.DeleteExpertAssign(exp);
                }
                else
                {
                    return NotFound();
                }
                
                return Ok();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
