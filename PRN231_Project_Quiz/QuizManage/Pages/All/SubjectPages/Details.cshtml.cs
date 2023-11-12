using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DTO.DTOs;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace QuizManage.Pages.All.SubjectPages
{
    public class DetailsModel : PageModel
    {

        private readonly HttpClient client;
        private readonly string SubjectApiUrl = "";
        private readonly string QuestionApiUrl = "";
        public IList<QuestionDTO> Question { get; set; } = default!;
        public SubjectDTO Subject { get; set; }
        public DetailsModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            SubjectApiUrl = "http://localhost:5298/odata/Subject";
            QuestionApiUrl = "http://localhost:5298/odata/Question";
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
        private async Task<List<QuestionDTO>> GetQuestionBySubjectId(string id)
        {
            string CurApi = QuestionApiUrl + $"?$filter=SubjectId eq '{id}'&$expand=Answers";
            return DeserializeJson<List<QuestionDTO>>(await CallApi(CurApi));
        }
       
        private async Task<SubjectDTO> GetSubjectBySubjectId(string id)
        {
            string CurApi = SubjectApiUrl + $"?$filter=SubjectId eq '{id}'";
            return DeserializeJson<List<SubjectDTO>>(await CallApi(CurApi))[0];
        }
        public async Task OnGetAsync(string id)
        {
            Question = await GetQuestionBySubjectId(id);
            Subject = await GetSubjectBySubjectId(id);
        }
    }
}
