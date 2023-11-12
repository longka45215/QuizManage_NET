using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace QuizManagementAPI.Controllers
{

    public class RoleController : ODataController
    {
        private readonly UserService _userService;
        public RoleController(UserService userService)
        {
            _userService = userService;
        }
        [EnableQuery(PageSize = 10)]
        public ActionResult<IQueryable<RoleDTO>> Get()
        {
            try
            {
                return Ok(_userService.GetRoles().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
