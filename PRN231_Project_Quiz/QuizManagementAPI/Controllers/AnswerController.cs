using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection;

namespace QuizManagementAPI.Controllers
{

    public class AnswerController : ODataController
    {
        private readonly AnswerService service;
        public AnswerController(AnswerService service)
        {
            this.service = service;
        }

        [EnableQuery]
        public ActionResult<IQueryable<AnswerDTO>> Get()
        {
            try
            {
                return Ok(service.GetAnswer().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IActionResult Post([FromBody] AnswerDTO answer)
        {
            try
            {
                service.SaveAnswer(answer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Put([FromRoute] int key, [FromBody] AnswerDTO answer)
        {
            try
            {
                var tmp = service.GetAnswer(key);
                if (tmp == null) { return NotFound(); }
                Type type = typeof(AnswerDTO);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(answer);
                    property.SetValue(tmp, value);
                }
                service.UpdateAnswer(tmp);
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
                var tmp = service.GetAnswer(key);
                if (tmp == null) { return NotFound(); }
                service.DeleteAnswer(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
