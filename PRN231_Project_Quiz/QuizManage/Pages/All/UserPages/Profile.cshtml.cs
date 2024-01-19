using DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizManage.Helper;
using System.Text;

namespace QuizManage.Pages.All.UserPages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public class UserUpdate
        {
            public string UserName { get; set; } = null!;
            public string FullName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string? Description { get; set; }
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(string username, string email, string fullName,string description)
        {
            var user = SessionHelper.GetObjectFromJson<UserDTO>(HttpContext.Session, "User");
            HttpClient client = new HttpClient();
            var newuser = new UserUpdate
            {
                UserName = username,
                Email = email,
                FullName = fullName,
                Description = description
            };
            string api = "http://localhost:5298/odata/User/"+user.UserId;
            var content = JsonConvert.SerializeObject(newuser);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync(api, httpContent);
            return Redirect("/All/UserPages/Profile");
        }
    }
}
