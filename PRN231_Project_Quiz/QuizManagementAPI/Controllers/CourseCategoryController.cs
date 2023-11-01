using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection;

namespace QuizManagementAPI.Controllers
{
  
    public class CourseCategoryController : ODataController
    {
        private readonly CourseCategoryService service;
        public CourseCategoryController(CourseCategoryService service)
        {
            this.service = service;
        }
        [EnableQuery(PageSize = 10)]
        public ActionResult<IQueryable<CourseCategoryDTO>> Get()
        {
            return Ok(service.GetCourseCategory().AsQueryable());
        }

        public ActionResult Post([FromBody] CourseCategoryDTO courseDTO)
        {
            var tmp = service.GetCourseCategory(courseDTO.CategoryId);
            if (tmp != null)
            {
                return BadRequest();
            }
            service.SaveCourseCategory(courseDTO);
            return Ok();
        }
        public IActionResult Put([FromRoute] int key, [FromBody] CourseCategoryDTO course)
        {
            var tmp = service.GetCourseCategory(key);
            if (tmp == null) { return NotFound(); }
            Type type = typeof(CourseCategoryDTO);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(course);
                property.SetValue(tmp, value);

            }
            service.UpdateCourseCategory(tmp);
            return Ok();
        }
        public IActionResult Delete([FromRoute] int key)
        {
            var tmp = service.GetCourseCategory(key);
            if (tmp == null) { return NotFound(); }
            service.DeleteCourseCategory(tmp);
            return Ok();
        }
    }
}
