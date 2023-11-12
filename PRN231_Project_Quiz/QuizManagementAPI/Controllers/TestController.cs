using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuizManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly QuestionService questionService;
        public TestController(QuestionService questionService)
        {
            this.questionService = questionService;
        }
        [HttpGet]
        public IEnumerable<QuestionDTO> Get()
        {
            try
            {
                var list = questionService.GetQuestion();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
