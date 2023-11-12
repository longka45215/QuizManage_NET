using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using DTO.DTOs;

namespace QuizManage.Pages.Admin.CoursePages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string CourseApiUrl = "";
        private readonly string CourseCategoryApiUrl = "";
        public IList<CourseCategoryDTO> CourseCategories { get; set; } = default!;
        public IList<CourseDTO> Course { get; set; } = default!;
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
        private async Task<List<CourseDTO>> GetCourse()
        {
            return DeserializeJson<List<CourseDTO>>(await CallApi(CourseApiUrl+ "?$expand=Category"));
        }
        private async Task<List<CourseCategoryDTO>> GetCourseCategory()
        {
            return DeserializeJson<List<CourseCategoryDTO>>(await CallApi(CourseCategoryApiUrl));
        }
        public async Task OnGetAsync()
        {
            CourseCategories = await GetCourseCategory();
            Course = await GetCourse();
        }
    }
}
