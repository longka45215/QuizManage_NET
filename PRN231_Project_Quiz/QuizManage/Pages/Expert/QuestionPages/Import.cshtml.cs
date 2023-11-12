using BusinessObject.Models;
using DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace QuizManage.Pages.Expert.QuestionPages
{
    public class ImportModel : PageModel
    {
        private readonly HttpClient client;
        private readonly string QuestionApiUrl = "";
        private readonly string AnswerApiUrl = "";
        public ImportModel()
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
        private async Task CallPostApi(string api, string content)
        {
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(api, httpContent);
        }
        private async Task<QuestionDTO> GetLastQuestion()
        {
            string CurApi = QuestionApiUrl + $"?$orderby=QuestionId desc&top=1";
            return DeserializeJson<List<QuestionDTO>>(await CallGetApi(CurApi))[0];
        }
        public async Task<IActionResult> OnPost(IFormFile file, string subjectID)
        { 
            if (file != null && file.Length > 0)
            {
                // Đọc dữ liệu từ file và đưa vào StringBuilder
                var stringBuilder = new StringBuilder();
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        stringBuilder.AppendLine(line);
                    }
                }
                // Xử lý dữ liệu trong StringBuilder tại đây
                var fileData = stringBuilder.ToString().Split("--");
                IList<string> QuesAndAnsList = new List<string>();
                IList<string> AnsList = new List<string>();
                for (int i = 0; i < fileData.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        QuesAndAnsList.Add(fileData[i]);
                    }
                    else
                    {
                        AnsList.Add(fileData[i]);
                    }
                }
                for (int i = 0; i < QuesAndAnsList.Count - 1; i++)
                {
                    var QuesList = QuesAndAnsList[i].Split("\n");

                    await CallPostApi(QuestionApiUrl, JsonConvert.SerializeObject(new QuestionDTO
                    {
                        Content = QuesList[0],
                        SubjectId = subjectID,
                        Answers  =  new List<AnswerDTO>()
                    }));
                    var lastQues = await GetLastQuestion();
                    for (int j = 1; j < QuesList.Length; j++)
                    {
                        bool check = false;
                        if (QuesList[j][0].Equals(AnsList[i]))
                        {
                            check = true;
                        }
                        await CallPostApi(AnswerApiUrl, JsonConvert.SerializeObject(new AnswerDTO
                        {
                            Content = QuesList[j],
                            IsAnswer = check,
                            QuestionId = lastQues.QuestionId
                        }));
                    }
                }
            }
            return Redirect($"/Expert/QuestionPages/Index?id={subjectID}");

        }
    }
}
