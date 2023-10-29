using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IQuizHistoryRepository
    {
        List<QuizHistory> GetQuizHistory();
        QuizHistory? GetQuizHistory(int quizid, int quesid);
        void SaveQuizHistory(QuizHistory history);
        void UpdateQuizHistory(QuizHistory history);
        void DeleteQuizHistory(QuizHistory history);

    }
}
