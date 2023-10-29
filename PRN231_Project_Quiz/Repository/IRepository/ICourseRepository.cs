using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICourseRepository
    { 
        List<Course> GetCourse();
        Course? GetCourse(string id);
        void SaveCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}
