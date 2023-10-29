using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class QuestionDAO
    {
        public static List<Question> GetQuestion()
        {
            var list = new List<Question>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Questions.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Question? GetQuestion(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Questions.FirstOrDefault(a => a.QuestionId==id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveQuestion(Question question)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Questions.Add(question);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateQuestion(Question question)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(question).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteQuestion(Question question)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Questions.SingleOrDefault(x => x.QuestionId == question.QuestionId);
                    if (p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    context.Questions.Remove(p1);
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
