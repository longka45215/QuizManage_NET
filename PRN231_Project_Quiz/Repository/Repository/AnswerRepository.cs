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
    public class AnswerRepository : IAnswerRepository
    {
        public void DeleteAnswer(Answer answer)
        {
            AnswerDAO.DeleteAnswer(answer);
        }

        public List<Answer> GetAnswer()
        {
            return AnswerDAO.GetAnswer();
        }

        public Answer? GetAnswer(int id)
        {
            return AnswerDAO.GetAnswer(id);
        }

        public void SaveAnswer(Answer answer)
        {
            AnswerDAO.SaveAnswer(answer);
        }

        public void UpdateAnswer(Answer answer)
        {
            AnswerDAO.UpdateAnswer(answer);
        }
    }
}
