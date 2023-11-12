using BusinessObject.Models;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace QuizManage.Pages.Expert.QuestionPages
{
    public class ExportModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string QuestionApiUrl = "";
        public string Question { get; set; } = default!;
        public ExportModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
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
        public async Task OnGetAsync(string id)
        {
            IList<QuestionDTO> question = await GetQuestionBySubjectId(id);
            StringBuilder data = new StringBuilder("");
            foreach (var item in question)
            {
                var temp = item.Content.Trim().Split("/");
                foreach (var str in temp)
                {
                    data.Append(str+"\n");
                }
                StringBuilder ans = new StringBuilder("");
                foreach(var answer in item.Answers)
                {
                    data.Append(answer.Content + "\n");
                    if (answer.IsAnswer.Value)
                    {
                        ans.Append(answer.Content);
                    }
                }
                data.Append("--"+ans+"--\n");
            }
            Question = data.ToString();
        }
    }
}
