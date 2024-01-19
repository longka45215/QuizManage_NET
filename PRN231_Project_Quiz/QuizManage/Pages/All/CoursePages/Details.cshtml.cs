using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using System.Net.Http.Headers;
using DTO.DTOs;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using QuizManage.Helper;

namespace QuizManage.Pages.All.CoursePages
{
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string CourseApiUrl = "";
        private readonly string SubjectApiUrl = "";
        private readonly string ExpertApiUrl = "";
        private readonly string ExpertAssignApiUrl = "";
        private readonly string RegisterApiUrl = "";
        public CourseDTO Course { get; set; } = default!;
        public IList<(SubjectDTO, ExpertAssignDTO)> Subjects { get; set; } = default!;
        public IList<UserDTO> Expert { get; set; } = default!;
        private IList<ExpertAssignDTO> ExpertAssign { get; set; } = default!;
        public RegisterDTO Register { get; set; } = default!;
        public DetailsModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CourseApiUrl = "http://localhost:5298/odata/Course";
            SubjectApiUrl = "http://localhost:5298/odata/Subject";
            ExpertApiUrl = "http://localhost:5298/odata/User?$filter=RoleId eq 1&$select=UserId,UserName";
            ExpertAssignApiUrl = "http://localhost:5298/api/ExpertAssign";
            RegisterApiUrl = "http://localhost:5298/api/Register";
        }

        private async Task<string> CallApi(string api)
        {
            HttpResponseMessage respone = await client.GetAsync(api);
            return await respone.Content.ReadAsStringAsync();
        }
        private T? DeserializeJsonOdata<T>(string data)
        {
            var list = JObject.Parse(data)["value"];
            return list.ToObject<T>();
        }
        private T? DeserializeJson<T>(string data)
        {
            var list = JObject.Parse(data);
            return list.ToObject<T>();
        }
        private async Task<List<SubjectDTO>> GetSubjectByCourseId(string id)
        {
            string CurApi = SubjectApiUrl + $"?$filter=CourseId eq '{id}'";
            return DeserializeJsonOdata<List<SubjectDTO>>(await CallApi(CurApi));
        }
        private async Task<List<UserDTO>> GetExpert()
        {
            return DeserializeJsonOdata<List<UserDTO>>(await CallApi(ExpertApiUrl));
        }
        private async Task<ExpertAssignDTO> GetExpertAssignBySubjectId(string subjectid)
        {
            string CurApi = ExpertAssignApiUrl + $"/Get/{subjectid}";
            var list = DeserializeJson<ExpertAssignDTO>(await CallApi(CurApi));
            return list;
        }
        private async Task<RegisterDTO> GetUserRegister(int userid, string courseid)
        {
            string CurApi = RegisterApiUrl + $"/Get/{userid}/{courseid}";
            return DeserializeJson<RegisterDTO>(await CallApi(CurApi));
        }

        private async Task<CourseDTO> GetCourseByCourseId(string id)
        {
            string CurApi = CourseApiUrl + $"?$filter=CourseId eq '{id}'";
            return DeserializeJsonOdata<List<CourseDTO>>(await CallApi(CurApi))[0];
        }

        public async Task OnGetAsync(string id)
        {
            var user = SessionHelper.GetObjectFromJson<UserDTO>(HttpContext.Session, "User");
            Course = await GetCourseByCourseId(id);
            Subjects = new List<(SubjectDTO, ExpertAssignDTO)>();
            foreach (var item in await GetSubjectByCourseId(id))
            {
                var exp = await GetExpertAssignBySubjectId(item.SubjectId);
                Subjects.Add((item, exp));
            }
            Expert = await GetExpert();
            if (user != null)
            {
                Register = await GetUserRegister(user.UserId, Course.CourseId);
            }

        }
    }
}
