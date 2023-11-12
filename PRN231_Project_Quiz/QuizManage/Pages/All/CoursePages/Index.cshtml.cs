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
using System.ComponentModel;
using System.Drawing;
using System.Text.Json.Nodes;
using DataAccess.DAO;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Text;

namespace QuizManage.Pages.All.CoursePages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string CourseApiUrl = "";
        private readonly string CourseCategoryApiUrl = "";
        public IList<CourseDTO> Course { get; set; } = default!;
        public IList<CourseCategoryDTO> CourseCategories { get; set; } = default!;
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
        private async Task<List<CourseDTO>> GetCourse()
        {
            return DeserializeJson<List<CourseDTO>>(await CallApi(CourseApiUrl));
        }
        private async Task<List<CourseDTO>> GetCourseByCategory(int cateid)
        {
            string CurApi = CourseApiUrl + "?$filter=CategoryId eq " + cateid;
            return DeserializeJson<List<CourseDTO>>(await CallApi(CurApi));
        }
        private async Task<List<CourseDTO>> GetCourseByCondition(string sort,string search)
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

        public async Task OnGetAsync()
        {
            CourseCategories = await GetCourseCategory();
            Course = await GetCourse();
        }
        public async Task OnGetCourseByCategory(int cateid)
        {
            CourseCategories = await GetCourseCategory();
            Course = await GetCourseByCategory(cateid);
        }
        public async Task OnPost(string sort,string search)
        {
            CourseCategories = await GetCourseCategory();
            Course = await GetCourseByCondition(sort,search);
        }

    }
}
