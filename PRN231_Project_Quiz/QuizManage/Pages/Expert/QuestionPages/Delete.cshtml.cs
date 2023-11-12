using BusinessObject.Models;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace QuizManage.Pages.Expert.QuestionPages
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string QuestionApiUrl = "";
        private readonly string AnswerApiUrl = "";
        public QuestionDTO Question { get; set; }
        public DeleteModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            QuestionApiUrl = "http://localhost:5298/odata/Question";
            AnswerApiUrl = "http://localhost:5298/odata/Answer";
        }
        private T? DeserializeJson<T>(string data)
        {
            var list = JObject.Parse(data)["value"];
            return list.ToObject<T>();
        }
        private async Task<string> CallGetApi(string api)
        {
            HttpResponseMessage respone = await client.GetAsync(api);
            return await respone.Content.ReadAsStringAsync();
        }
        private async Task CallDeleteApi(string api)
        {
            HttpResponseMessage response = await client.DeleteAsync(api);
        }
        private async Task<QuestionDTO> GetQuestionByQuestionId(int id)
        {
            string CurApi = QuestionApiUrl + $"?$filter=QuestionId eq {id}&$expand=Answers";
            return DeserializeJson<List<QuestionDTO>>(await CallGetApi(CurApi))[0];
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Question = await GetQuestionByQuestionId(id);
            foreach (var item in Question.Answers)
            {
                await CallDeleteApi(AnswerApiUrl + $"({item.AnswerId})");
            }
            await CallDeleteApi(QuestionApiUrl + $"({id})");
            return Redirect($"/Expert/QuestionPages/Index?id={Question.SubjectId}");
        }
    }
}
