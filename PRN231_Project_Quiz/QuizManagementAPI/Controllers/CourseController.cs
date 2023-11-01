using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection;

namespace QuizManagementAPI.Controllers
{

    public class CourseController : ODataController
    {
        private readonly CourseService courseService;
        public CourseController(CourseService courseService)
        {
            this.courseService = courseService;
        }
        [EnableQuery(PageSize = 10)]
        public ActionResult<IQueryable<CourseDTO>> Get()
        {
            return Ok(courseService.GetCourse().AsQueryable());
        }

        public ActionResult Post([FromBody]CourseDTO courseDTO)
        {
            var tmp = courseService.GetCourse(courseDTO.CourseId);
            if (tmp != null)
            {
                return BadRequest();
            }
            courseService.SaveCourse(courseDTO);
            return Ok();
        }
        public IActionResult Put([FromRoute] string key, [FromBody] CourseDTO course)
        {
            var tmp = courseService.GetCourse(key);
            if (tmp == null) { return NotFound(); }
            Type type = typeof(CourseDTO);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(course);
                property.SetValue(tmp, value);

            }
            courseService.UpdateCourse(tmp);
            return Ok();
        }
        public IActionResult Delete([FromRoute] string key)
        {
            var tmp = courseService.GetCourse(key);
            if (tmp == null) { return NotFound(); }
            courseService.DeleteCourse(tmp);
            return Ok();
        }
    }
}
