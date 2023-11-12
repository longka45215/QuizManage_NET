using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace QuizManage.Pages.Admin.SubjectPages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string CourseApiUrl = "";
        public IList<CourseDTO> Course { get; set; } = default!;
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CourseApiUrl = "http://localhost:5298/odata/Course";
            
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
        private async Task<List<CourseDTO>> GetCourse()
        {
            return DeserializeJson<List<CourseDTO>>(await CallApi(CourseApiUrl + "?$expand=Category"));
        }
        public async Task OnGetAsync()
        {
            Course = await GetCourse();
        }
    }
}
