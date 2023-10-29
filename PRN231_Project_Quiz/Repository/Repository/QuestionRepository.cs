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
    public class QuestionRepository : IQuestionRepository
    {
        public void DeleteQuestion(Question question)
        {
            QuestionDAO.DeleteQuestion(question);
        }

        public List<Question> GetQuestion()
        {
            return QuestionDAO.GetQuestion();
        }

        public Question? GetQuestion(int id)
        {
            return QuestionDAO.GetQuestion(id);
        }

        public void SaveQuestion(Question question)
        {
            QuestionDAO.SaveQuestion(question);
        }

        public void UpdateQuestion(Question question)
        {
            QuestionDAO.UpdateQuestion(question);
        }
    }
}
