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
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        public void DeleteCourseCategory(CourseCategory cate)
        {
            CourseCategoryDAO.DeleteCourseCategory(cate);
        }

        public List<CourseCategory> GetCourseCategory()
        {
            return CourseCategoryDAO.GetCourseCategory();
        }

        public CourseCategory? GetCourseCategory(int id)
        {
            return CourseCategoryDAO.GetCourseCategory(id);
        }

        public void SaveCourseCategory(CourseCategory cate)
        {
            CourseCategoryDAO.SaveCourseCategory(cate);
        }

        public void UpdateCourseCategory(CourseCategory cate)
        {
            CourseCategoryDAO.UpdateCourseCategory(cate);
        }
    }
}
