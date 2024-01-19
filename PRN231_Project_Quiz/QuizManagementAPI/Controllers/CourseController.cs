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
        [EnableQuery]
        public ActionResult<IQueryable<CourseDTO>> Get()
        {
            try
            {
                return Ok(courseService.GetCourse().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public ActionResult Post([FromBody] CourseDTO courseDTO)
        {
            try
            {
                var tmp = courseService.GetCourse(courseDTO.CourseId);
                if (tmp != null)
                {
                    return Conflict();
                }
                courseService.SaveCourse(courseDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        public IActionResult Put([FromRoute] string key, [FromBody] CourseDTO course)
        {
            try
            {
                var tmp = courseService.GetCourse(key);
                if (tmp == null) { return NotFound(); }
                Type type = typeof(CourseDTO);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.Name != "CourseId" && property.Name != "Category")
                    {
                        object value = property.GetValue(course);
                        property.SetValue(tmp, value);
                    }


                }
                courseService.UpdateCourse(tmp);
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
                var tmp = courseService.GetCourse(key);
                if (tmp == null) { return NotFound(); }
                courseService.DeleteCourse(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
