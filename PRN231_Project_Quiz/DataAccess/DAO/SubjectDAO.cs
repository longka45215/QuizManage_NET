using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SubjectDAO
    {
        public static List<Subject> GetSubject()
        {
            var list = new List<Subject>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Subjects.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Subject? GetSubject(string id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Subjects.FirstOrDefault(a => a.SubjectId.Equals(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveSubject(Subject subject)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Subjects.Add(subject);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateSubject(Subject subject)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(subject).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteSubject(Subject subject)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Subjects.SingleOrDefault(x => x.SubjectId == subject.SubjectId);
                    if (p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    context.Subjects.Remove(p1);
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
