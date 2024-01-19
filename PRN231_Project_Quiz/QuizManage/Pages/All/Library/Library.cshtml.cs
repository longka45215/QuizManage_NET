using DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizManage.Helper;
using System.Net.Http.Headers;

namespace QuizManage.Pages.All.Library
{
    [Authorize]
    public class LibraryModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string CourseApiUrl = "";
        private readonly string SubjectApiUrl = "";
        private readonly string ExpertAssignApiUrl = "";
        private readonly string RegisterApiUrl = "";
        public IList<CourseDTO> Course { get; set; } = default!;
        public IList<SubjectDTO> Subjects { get; set; } = default!;
        private IList<ExpertAssignDTO> ExpertAssign { get; set; } = default!;
        private IList<RegisterDTO> Register { get; set; } = default!;
        public LibraryModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CourseApiUrl = "http://localhost:5298/odata/Course";
            SubjectApiUrl = "http://localhost:5298/odata/Subject";
            ExpertAssignApiUrl = "http://localhost:5298/api/ExpertAssign";
            RegisterApiUrl = "http://localhost:5298/api/Register";
            Course = new List<CourseDTO>();
            Subjects = new List<SubjectDTO>();
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
            var list = JsonConvert.DeserializeObject<T>(data);
            return list;
        }
        private async Task<SubjectDTO> GetSubjectBySubjectId(string id)
        {
            string CurApi = SubjectApiUrl + $"?$filter=SubjectId eq '{id}'";
            return DeserializeJsonOdata<List<SubjectDTO>>(await CallApi(CurApi))[0];
        }
        private async Task<List<ExpertAssignDTO>> GetExpertAssignByExpertId(int expertid)
        {
            string CurApi = $"http://localhost:5298/api/ExpertAssign/GetExpert/{expertid}";
            var list1 = DeserializeJson<List<ExpertAssignDTO>>(await CallApi(CurApi));
            return list1;
        }
        private async Task<List<RegisterDTO>> GetUserRegister(int userid)
        {
            string CurApi = RegisterApiUrl + $"/GetUser/{userid}";
            return DeserializeJson<List<RegisterDTO>>(await CallApi(CurApi));
        }

        private async Task<CourseDTO> GetCourseByCourseId(string id)
        {
            string CurApi = CourseApiUrl + $"?$filter=CourseId eq '{id}'";
            return DeserializeJsonOdata<List<CourseDTO>>(await CallApi(CurApi))[0];
        }
        public async Task OnGetAsync()
        {
            var user = SessionHelper.GetObjectFromJson<UserDTO>(HttpContext.Session, "User");
            ExpertAssign = await GetExpertAssignByExpertId(user.UserId);
            Register = await GetUserRegister(user.UserId);
            foreach(var item in ExpertAssign)
            {
                Subjects.Add(await GetSubjectBySubjectId(item.SubjectId));
            }
            foreach(var item in Register)
            {
                Course.Add(await GetCourseByCourseId(item.CourseId));
            }
        }
    }
}
