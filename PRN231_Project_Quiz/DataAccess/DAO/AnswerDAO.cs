using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AnswerDAO
    {
        public static List<Answer> GetAnswer()
        {
            var list = new List<Answer>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Answers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Answer? GetAnswer(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Answers.FirstOrDefault(a => a.AnswerId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveAnswer(Answer answer)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Answers.Add(answer);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateAnswer(Answer answer)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(answer).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteAnswer(Answer answer)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Answers.SingleOrDefault(x => x.AnswerId == answer.AnswerId);
                    if (p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    context.Answers.Remove(p1);
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
