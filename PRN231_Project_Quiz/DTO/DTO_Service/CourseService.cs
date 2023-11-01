using AutoMapper;
using BusinessObject.Models;
using DTO.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO_Service
{
    public class CourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }
        public void DeleteCourse(CourseDTO course)
        {
            courseRepository.DeleteCourse(mapper.Map<Course>(course));
        }

        public List<CourseDTO> GetCourse()
        {
            return mapper.Map<List<CourseDTO>>(courseRepository.GetCourse());
        }

        public CourseDTO? GetCourse(string id)
        {
            return mapper.Map<CourseDTO?>(courseRepository.GetCourse(id));
        }

        public void SaveCourse(CourseDTO course)
        {
            courseRepository.SaveCourse(mapper.Map<Course>(course));
        }

        public void UpdateCourse(CourseDTO course)
        {
            courseRepository.UpdateCourse(mapper.Map<Course>(course));
        }

    }
}
