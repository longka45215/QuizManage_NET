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

namespace QuizManage.Pages.All.CoursePages
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string CourseApiUrl = "";
        private readonly string SubjectApiUrl = "";
        public CourseDTO Course { get; set; } = default!;
        public IList<SubjectDTO> Subjects { get; set; } = default!;
        public DetailsModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CourseApiUrl = "http://localhost:5298/odata/Course";
            SubjectApiUrl = "http://localhost:5298/odata/Subject";
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
        private async Task<List<SubjectDTO>> GetSubjectByCourseId(string id)
        {
            string CurApi = SubjectApiUrl + $"?$filter=CourseId eq '{id}'" ;
            return DeserializeJson<List<SubjectDTO>>(await CallApi(CurApi));
        }
        private async Task<CourseDTO> GetCourseByCourseId(string id)
        {
            string CurApi = CourseApiUrl + $"?$filter=CourseId eq '{id}'";
            return DeserializeJson<List<CourseDTO>>(await CallApi(CurApi))[0];
        }


        public async Task OnGetAsync(string id)
        {
            Course = await GetCourseByCourseId(id);
            Subjects = await GetSubjectByCourseId(id);
        }
    }
}
