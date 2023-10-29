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
    public class QuizRepository : IQuizRepository
    {
        public void DeleteQuiz(Quiz quiz)
        {
            QuizDAO.DeleteQuiz(quiz);
        }

        public List<Quiz> GetQuiz()
        {
            return QuizDAO.GetQuiz();   
        }

        public Quiz? GetQuiz(int id, string subjectId, int userid)
        {
            return QuizDAO.GetQuiz(id,subjectId,userid);
        }

        public void SaveQuiz(Quiz quiz)
        {
            QuizDAO.SaveQuiz(quiz);
        }

        public void UpdateQuiz(Quiz quiz)
        {
            QuizDAO.UpdateQuiz(quiz);
        }
    }
}
