using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class QuizHistoryDAO
    {
        public static List<QuizHistory> GetQuizHistory()
        {
            var list = new List<QuizHistory>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.QuizHistories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static QuizHistory? GetQuizHistory(int quizid, int quesid)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.QuizHistories.
                        FirstOrDefault(a => a.QuizId == quizid && a.QuestionId == quizid);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveQuizHistory(QuizHistory expass)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.QuizHistories.Add(expass);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateQuizHistory(QuizHistory expass)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(expass).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteQuizHistory(QuizHistory expass)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.QuizHistories
                        .SingleOrDefault(a => a.QuizId == expass.QuizId && a.QuestionId == expass.QuestionId);
                    if (p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    context.QuizHistories.Remove(p1);
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
