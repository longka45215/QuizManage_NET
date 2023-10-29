using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IQuizRepository
    {
        List<Quiz> GetQuiz();
        Quiz? GetQuiz(int id,string subjectId, int userid);
        void SaveQuiz(Quiz quiz);
        void UpdateQuiz(Quiz quiz);
        void DeleteQuiz(Quiz quiz);
    }
}
