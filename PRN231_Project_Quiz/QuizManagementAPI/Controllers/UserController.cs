using BusinessObject.Models;
using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizManagementAPI.Controllers
{

    public class UserController : ODataController
    {
        private readonly UserService _userService ;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [EnableQuery(PageSize =10)]
        public ActionResult<IQueryable<UserDTO>> Get()
        {
            return Ok(_userService.GetUser().AsQueryable());
        }

        // POST api/<UsersController>

        public ActionResult Post([FromBody] UserDTO user)
        {
            Type type = typeof(UserDTO);
            PropertyInfo[] properties = type.GetProperties();
            UserDTO tmp = new UserDTO();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "UserId")
                {
                    object value = property.GetValue(user);
                    property.SetValue(tmp, value);
                }
            }
            _userService.SaveUser(tmp);
            return Ok();
        }

        // PUT api/<UsersController>/5

        public ActionResult Put([FromRoute] int key, [FromBody] UserDTO user)
        {
            var tmp = _userService.GetUser().FirstOrDefault(x => x.UserId == key); ;
            if (tmp == null)
            {
                return NotFound();
            }
            Type type = typeof(UserDTO);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name != "UserId")
                {
                    object value = property.GetValue(user);
                    property.SetValue(tmp, value);
                }
            }
            _userService.UpdateUser(tmp);
            return Ok();
        }
      
    }
}
