using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CourseDAO
    {
        public static List<Course> GetCourse()
        {
            var list = new List<Course>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Courses.Include(x=>x.Category).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static Course? GetCourse(string id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Courses.FirstOrDefault(a => a.CourseId.Equals(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveCourse(Course course)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateCourse(Course course)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(course).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteCourse(Course course)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Courses.SingleOrDefault(x => x.CourseId == course.CourseId);
                    if(p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    context.Courses.Remove(p1);
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
