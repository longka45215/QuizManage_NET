using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection;

namespace QuizManagementAPI.Controllers
{

    public class QuizController : ODataController
    {
        private readonly QuizService service;
        public QuizController(QuizService service)
        {
            this.service = service;
        }
        [EnableQuery]
        public ActionResult<IQueryable<QuizDTO>> Get()
        {
            try
            {
                return Ok(service.GetQuiz().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Post([FromBody] QuizDTO quiz)
        {
            try
            {
                service.SaveQuiz(quiz);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Put([FromRoute] int key, [FromBody] QuizDTO quiz)
        {
            try
            {
                var tmp = service.GetQuiz(key, quiz.SubjectId, quiz.UserId);
                if (tmp == null) { return NotFound(); }
                Type type = typeof(QuizDTO);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(quiz);
                    property.SetValue(tmp, value);
                }
                service.UpdateQuiz(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
