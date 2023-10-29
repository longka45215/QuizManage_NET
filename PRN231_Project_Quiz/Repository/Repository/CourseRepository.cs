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
    public class CourseRepository : ICourseRepository
    {
        public void DeleteCourse(Course course)
        {
            CourseDAO.DeleteCourse(course);
        }

        public List<Course> GetCourse()
        {
            return CourseDAO.GetCourse();
        }

        public Course? GetCourse(string id)
        {
            return CourseDAO.GetCourse(id);
        }

        public void SaveCourse(Course course)
        {
            CourseDAO.SaveCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            CourseDAO.UpdateCourse(course);
        }
    }
}
