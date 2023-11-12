using BusinessObject.Models;
using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection;

namespace QuizManagementAPI.Controllers
{

    public class QuestionController : ODataController
    {
        private readonly QuestionService questionService;
        public QuestionController(QuestionService questionService)
        {
            this.questionService = questionService;
        }

        [EnableQuery]
        public ActionResult<IQueryable<QuestionDTO>> Get()
        {
            try
            {
                return Ok(questionService.GetQuestion().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IActionResult Post([FromBody] QuestionDTO question)
        {
            try
            {
                questionService.SaveQuestion(question);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Put([FromRoute] int key, [FromBody] QuestionDTO question)
        {
            try
            {
                var tmp = questionService.GetQuestion(key);
                if (tmp == null) { return NotFound(); }
                Type type = typeof(QuestionDTO);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.Name != "QuestionId"&& property.Name != "Answers")
                    {
                        object value = property.GetValue(question);
                        property.SetValue(tmp, value);
                    }
                }
                questionService.UpdateQuestion(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Delete([FromRoute] int key)
        {
            try
            {
                var tmp = questionService.GetQuestion(key);
                if (tmp == null) { return NotFound(); }
                questionService.DeleteQuestion(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
