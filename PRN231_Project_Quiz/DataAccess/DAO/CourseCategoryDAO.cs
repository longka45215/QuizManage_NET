using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CourseCategoryDAO
    {
        public static List<CourseCategory> GetCourseCategory()
        {
            var list = new List<CourseCategory>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.CourseCategories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public static CourseCategory? GetCourseCategory(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.CourseCategories.FirstOrDefault(a => a.CategoryId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveCourseCategory(CourseCategory cate)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.CourseCategories.Add(cate);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public static void UpdateCourseCategory(CourseCategory cate)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(cate).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteCourseCategory(CourseCategory cate)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.CourseCategories.SingleOrDefault(x => x.CategoryId == cate.CategoryId);
                    if (p1 == null)
                    {
                        throw new Exception("not found");
                    }
                    context.CourseCategories.Remove(p1);
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
