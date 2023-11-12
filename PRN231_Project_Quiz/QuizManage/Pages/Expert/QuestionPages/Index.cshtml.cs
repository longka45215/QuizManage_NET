using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace QuizManage.Pages.Expert.QuestionPages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string SubjectApiUrl = "";
        private readonly string QuestionApiUrl = "";
        public IList<QuestionDTO> Question { get; set; } = default!;
        public IList<QuestionDTO> QuestionUpdate { get; set; } = default!;
        public SubjectDTO Subject { get; set; }
        public IndexModel()
        {
            client = new HttpClient();
            QuestionUpdate = new List<QuestionDTO>();   
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
            string CurApi = QuestionApiUrl + $"?$filter=SubjectId eq '{id}'&$orderby=QuestionId desc&$expand=Answers";
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
        public async Task OnPostAsync()
        {
            var i = QuestionUpdate;
        }

    }
}
