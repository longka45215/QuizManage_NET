using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizHistoryController : ControllerBase
    {
        private readonly QuizHistoryService service;
        public QuizHistoryController(QuizHistoryService service)
        {
            this.service = service;
        }
        

        // GET: api/<QuizHistoryController>
        [HttpGet("quizId")]
        public IEnumerable<QuizHistoryDTO> Get(int quizId)
        {
            return service.GetQuizHistory().Where(x=>x.QuizId==quizId);
        }

        

        // POST api/<QuizHistoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuizHistoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuizHistoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
