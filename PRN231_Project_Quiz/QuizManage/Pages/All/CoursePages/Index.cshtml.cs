using DTO.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace QuizManage.Pages.All.CoursePages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string CourseApiUrl = "";
        private readonly string CourseCategoryApiUrl = "";
        public IList<CourseDTO> Course { get; set; } = default!;
        public IList<CourseCategoryDTO> CourseCategories { get; set; } = default!;
        public int TotalCourse { get; set; } = default!;
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CourseApiUrl = "http://localhost:5298/odata/Course";
            CourseCategoryApiUrl = "http://localhost:5298/odata/CourseCategory";

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
        
        private async Task<List<CourseCategoryDTO>> GetCourseCategory()
        {
            return DeserializeJson<List<CourseCategoryDTO>>(await CallApi(CourseCategoryApiUrl));
        }
        private async Task<List<CourseDTO>> GetCoursePaging(int skip)
        {
            string CurApi = CourseApiUrl+ $"?$skip={skip}&$top=6";
            return DeserializeJson<List<CourseDTO>>(await CallApi(CurApi));
        }
        private async Task<int> GetTotalCourse()
        {
            return DeserializeJson<List<CourseDTO>>(await CallApi(CourseApiUrl)).Count;
        }
        private async Task<List<CourseDTO>> GetCourseByCategory(int cateid)
        {
            string CurApi = CourseApiUrl + "?$filter=CategoryId eq " + cateid;
            return DeserializeJson<List<CourseDTO>>(await CallApi(CurApi));
        }
        private async Task<List<CourseDTO>> GetCourseByCondition(string sort, string search)
        {

            StringBuilder query = new StringBuilder("?$filter=");
            switch (sort)
            {
                case "cname":
                    query.Append($"contains(CourseName,'{search}')");
                    break;
                case "cid":
                    query.Append($"contains(CourseId,'{search}')");
                    break;
                case "all":
                    query.Append($"contains(CourseName, '{search}') or contains(CourseId, '{search}')");
                    break;
                default:
                    break;
            }

            string CurApi = CourseApiUrl + query;
            return DeserializeJson<List<CourseDTO>>(await CallApi(CurApi));
        }
        
        public async Task OnGetAsync(int? pageNum)
        {
            if(pageNum == null) {  pageNum = 0; }

            TotalCourse  = await GetTotalCourse();
            CourseCategories = await GetCourseCategory();
            Course = await GetCoursePaging((int)pageNum*6);
        }
        public async Task OnGetCourseByCategory(int cateid)
        {
            
            CourseCategories = await GetCourseCategory();
            Course = await GetCourseByCategory(cateid);
        }
        public async Task OnPost(string sort, string search)
        {
            
            CourseCategories = await GetCourseCategory();
            Course = await GetCourseByCondition(sort, search);
        }

    }
}
