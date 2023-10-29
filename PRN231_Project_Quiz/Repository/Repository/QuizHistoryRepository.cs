using BusinessObject.Models;
using DataAccess.DAO;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class QuizHistoryRepository : IQuizHistoryRepository
    {
        public void DeleteQuizHistory(QuizHistory history)
        {
            QuizHistoryDAO.DeleteQuizHistory(history);
        }

        public List<QuizHistory> GetQuizHistory()
        {
            return QuizHistoryDAO.GetQuizHistory();
        }

        public QuizHistory? GetQuizHistory(int quizid, int quesid)
        {
            return QuizHistoryDAO.GetQuizHistory(quizid,quesid);
        }

        public void SaveQuizHistory(QuizHistory history)
        {
            QuizHistoryDAO.SaveQuizHistory(history);
        }

        public void UpdateQuizHistory(QuizHistory history)
        {
            QuizHistoryDAO.UpdateQuizHistory(history);
        }
    }
}
