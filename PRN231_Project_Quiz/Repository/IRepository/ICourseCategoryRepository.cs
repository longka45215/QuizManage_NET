using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICourseCategoryRepository
    {
        List<CourseCategory> GetCourseCategory();
        CourseCategory? GetCourseCategory(int id);
        void SaveCourseCategory(CourseCategory cate);
        void UpdateCourseCategory(CourseCategory cate);
        void DeleteCourseCategory(CourseCategory cate);
    }
}
