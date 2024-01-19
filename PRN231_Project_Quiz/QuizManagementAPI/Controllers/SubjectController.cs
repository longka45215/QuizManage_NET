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

    public class SubjectController : ODataController
    {
        private readonly SubjectService subjectService;
        public SubjectController(SubjectService subjectService)
        {
            this.subjectService = subjectService;
        }
        [EnableQuery]
        public ActionResult<IQueryable<SubjectDTO>> Get()
        {
            try
            {
                return Ok(subjectService.GetSubjects().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Post([FromBody] SubjectDTO subject)
        {
            try
            {
                var tmp = subjectService.GetSubject(subject.SubjectId);
                if (tmp != null)
                {
                    return BadRequest();
                }
                subjectService.SaveSubject(subject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Put([FromRoute] string key, [FromBody] SubjectDTO subject)
        {
            try
            {
                var tmp = subjectService.GetSubject(key);
                if (tmp == null) { return NotFound(); }
                Type type = typeof(SubjectDTO);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(subject);
                    property.SetValue(tmp, value);

                }
                subjectService.UpdateSubject(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Delete([FromRoute] string key)
        {
            try
            {
                var tmp = subjectService.GetSubject(key);
                if (tmp == null) { return NotFound(); }
                subjectService.DeleteSubject(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
