using DTO.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using QuizManage.Helper;
using System.Net.Http.Headers;

namespace QuizManage.Pages.All.SubjectPages
{
    [Authorize]
    public class TakeQuizModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string SubjectApiUrl = "";
        private readonly string QuestionApiUrl = "";
        public IList<QuestionDTO> Question { get; set; } = default!;
        public SubjectDTO Subject { get; set; }
        public class AnswerModel
        {
            public int QuestionId { get; set; }
            public string SelectedAnswer { get; set; } = default!;
        }
        [BindProperty(SupportsGet =true)]
        public List<AnswerModel> SelectedAnswers { get; set; }
        public TakeQuizModel()
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
        private async Task<List<QuestionDTO>> GetLimitQuestionBySubjectId(string id)
        {
            string CurApi = QuestionApiUrl + $"?$filter=SubjectId eq '{id}'&$expand=Answers&$top=10";
            return DeserializeJson<List<QuestionDTO>>(await CallApi(CurApi));
        }
        private async Task<SubjectDTO> GetSubjectBySubjectId(string id)
        {
            string CurApi = SubjectApiUrl + $"?$filter=SubjectId eq '{id}'";
            return DeserializeJson<List<SubjectDTO>>(await CallApi(CurApi))[0];
        }
        private List<T> GetRandomElements<T>(List<T> list, int count)
        {
            List<T> randomElements = new List<T>();
            Random random = new Random();

            while (randomElements.Count < count && list.Count > 0)
            {
                int index = random.Next(list.Count);
                randomElements.Add(list[index]);
                list.RemoveAt(index);
            }

            return randomElements;
        }
        public async Task OnGetAsync(string id)
        {
            var user = SessionHelper.GetObjectFromJson<UserDTO>(HttpContext.Session, "User");
            Question = GetRandomElements(await GetQuestionBySubjectId(id),10);
            Subject = await GetSubjectBySubjectId(id);
            SelectedAnswers = new List<AnswerModel>(Question.Count);
        }
        public async Task OnPostAsync()
        {
            foreach (var answerModel in SelectedAnswers)
            {
                
            }
        }
    }
}
