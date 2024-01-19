using BusinessObject.Models;
using DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace QuizManage.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
        }
        public async Task<IActionResult> OnPost(string username, string email, string password,string repassword, string fullName)
        {
            if(!password.Equals(repassword)) {
                ModelState.AddModelError(string.Empty, "Password and Re-Password not Match.Try Again!");
                return Page();
            }
            HttpClient client = new HttpClient();
            var user = new UserDTO
            {
                UserName = username,
                Email = email,
                Password = password,
                FullName = fullName,
                Avatar = null,
                Description = null,
                RoleId = 2,
            };
            string api = "http://localhost:5298/odata/User";
            var content = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(api, httpContent);
            if((int)response.StatusCode==409) {
                ModelState.AddModelError(string.Empty, "Email Exsit");
                return Page();
            }
            return Redirect("/Login");
        }
    }
}
