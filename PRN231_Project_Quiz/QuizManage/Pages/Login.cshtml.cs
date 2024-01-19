
using DTO.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace QuizManage.Pages
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class LoginModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string UserApiUrl = "";
        public UserDTO UserDTO { get; set; } = default!;
        [TempData]
        public string ErrorMessage { get; set; }
        public LoginModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            UserApiUrl = "http://localhost:5298/odata/User";
        }
        private async Task<string> CallApi(string api)
        {
            HttpResponseMessage respone = await client.GetAsync(api);
            return await respone.Content.ReadAsStringAsync();
        }
        private T? DeserializeJson<T>(string data)
        {
            var list = JObject.Parse(data)["value"];
            return list.ToObject<T>();
        }
        private async Task<UserDTO> GetUser(string email, string password)
        {
            string CurApi = UserApiUrl + $"?$filter=Email eq '{email}' and Password eq '{password}'";
            var list = DeserializeJson<List<UserDTO>>(await CallApi(CurApi));
            return list.Count==0?null: list[0];
        }
        public async void OnGet()
        {
            await HttpContext.SignOutAsync();
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

        }
        public async Task<IActionResult> OnPost(string email, string password)
        {
            UserDTO user = await GetUser(email,password);
            if (user != null)
            {

                var userClaims = new List<Claim> {
                    new Claim("Role", user.RoleId.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("Name", user.FullName),
                    new Claim("Id", user.UserId.ToString())
                };
                var userIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var userClaimsPrincipal = new ClaimsPrincipal(userIdentity);
                var authProperties = new AuthenticationProperties
                {
                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                };
                await HttpContext.
                    SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userClaimsPrincipal, authProperties);
                
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                if (user.RoleId==0)
                {
                    return Redirect("/Admin/CoursePages/Index");
                }
                else
                {
                    return RedirectToPage("/All/CoursePages/Index");
                }


            }

            ModelState.AddModelError(string.Empty, "Login Failed. Check Your Account and Try Again");
            return Page();
        }
        public async Task<IActionResult> OnGetLogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToPage("Index");
        }


    }
}
