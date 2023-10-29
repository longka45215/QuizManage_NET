using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestion();
        Question? GetQuestion(int id);
        void SaveQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(Question question);

    }
}
