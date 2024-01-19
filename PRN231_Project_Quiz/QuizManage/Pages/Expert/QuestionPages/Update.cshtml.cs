using BusinessObject.Models;
using DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace QuizManage.Pages.Expert.QuestionPages
{
    [Authorize(Policy = "ExpertOnly")]
    public class UpdateModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string QuestionApiUrl = "";
        private readonly string AnswerApiUrl = "";
        public QuestionDTO Question { get; set; }
        public UpdateModel()
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
        private async Task CallPutApi(string api,string content)
        {
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(api, httpContent);
        }
        private async Task<QuestionDTO> GetQuestionByQuestionId(int id)
        {
            string CurApi = QuestionApiUrl + $"?$filter=QuestionId eq {id}&$expand=Answers";
            return DeserializeJson<List<QuestionDTO>>(await CallGetApi(CurApi))[0];
        }
        public async Task OnGetAsync(int id)
        {
            Question = await GetQuestionByQuestionId(id);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string content = Request.Form["questionContent"];
            int answerId = Int32.Parse(Request.Form["isAnswer"]);
            string subjectId = Request.Form["subjectId"];
            int questionId = Int32.Parse(Request.Form["questionId"]);
            Question = await GetQuestionByQuestionId(questionId);
            var question = new QuestionDTO
            {
                SubjectId = subjectId,
                Content = content,
            };
            foreach (var item in Question.Answers)
            {
                if(item.AnswerId!= answerId)
                {
                    item.IsAnswer = false;
                    
                }
                else
                {
                    item.IsAnswer = true;
                }
                string answer = JsonConvert.SerializeObject(item);
                await CallPutApi(AnswerApiUrl + $"({item.AnswerId})", answer);
            }
            string data = JsonConvert.SerializeObject(question);
            await CallPutApi(QuestionApiUrl + $"({questionId})", data);
            return Redirect($"/Expert/QuestionPages/Index?id={subjectId}");
        }
    }
}
