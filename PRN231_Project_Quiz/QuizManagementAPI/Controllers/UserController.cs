using BusinessObject.Models;
using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizManagementAPI.Controllers
{

    public class UserController : ODataController
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [EnableQuery(PageSize = 10)]
        public ActionResult<IQueryable<UserDTO>> Get()
        {
            try
            {
                return Ok(_userService.GetUser().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<UsersController>

        public ActionResult Post([FromBody] UserDTO user)
        {
            try
            {
                var checkUser = _userService.GetUser().FirstOrDefault(x=>x.Email.Equals(user.Email));
                if(checkUser != null)
                {
                    return Conflict("Email exsited!!!");
                }
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<UsersController>/5

        public ActionResult Put([FromRoute] int key, [FromBody] UserDTO user)
        {
            try
            {
                var tmp = _userService.GetUser().FirstOrDefault(x => x.UserId == key); 
                if (tmp == null)
                {
                    return NotFound();
                }
                Type type = typeof(UserDTO);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.Name != "UserId"
                        && property.Name != "Password"&& property.Name != "RoleId")
                    {
                        object value = property.GetValue(user);
                        property.SetValue(tmp, value);
                    }
                }
                _userService.UpdateUser(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }   
        public ActionResult Patch([FromRoute] int key, [FromBody] Delta<UserDTO> delta)
        {
            try
            {
                var tmp = _userService.GetUser().FirstOrDefault(x => x.UserId == key);
                if (tmp == null)
                {
                    return NotFound();
                }
                delta.Patch(tmp);
                _userService.UpdateUser(tmp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
