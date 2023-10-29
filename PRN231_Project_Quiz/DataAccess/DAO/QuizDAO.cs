using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class QuizDAO
    {
        public static List<Quiz> GetQuiz()
        {
            var list = new List<Quiz>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Quizzes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Quiz? GetQuiz(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Quizzes.FirstOrDefault(a => a.QuizId==id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveQuiz(Quiz quiz)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Quizzes.Add(quiz);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateQuiz(Quiz quiz)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(quiz).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteQuiz(Quiz quiz)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Quizzes.SingleOrDefault(x => x.QuizId == quiz.QuizId);
                    if (p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    context.Quizzes.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
