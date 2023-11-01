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
    public class CourseCategoryService
    {
        private readonly ICourseCategoryRepository courseCategoryRepository;
        private readonly IMapper mapper;
        public CourseCategoryService(ICourseCategoryRepository courseCategoryRepository, IMapper mapper)
        {
            this.courseCategoryRepository = courseCategoryRepository;
            this.mapper = mapper;
        }
        public void DeleteCourseCategory(CourseCategoryDTO coursecate)
        {
            courseCategoryRepository.DeleteCourseCategory(mapper.Map<CourseCategory>(coursecate));
        }

        public List<CourseCategoryDTO> GetCourseCategory()
        {
            return mapper.Map<List<CourseCategoryDTO>>(courseCategoryRepository.GetCourseCategory());
        }

        public CourseCategoryDTO? GetCourseCategory(int id)
        {
            return mapper.Map<CourseCategoryDTO?>(courseCategoryRepository.GetCourseCategory(id));
        }

        public void SaveCourseCategory(CourseCategoryDTO coursecate)
        {
            courseCategoryRepository.SaveCourseCategory(mapper.Map<CourseCategory>(coursecate));
        }

        public void UpdateCourseCategory(CourseCategoryDTO coursecate)
        {
            courseCategoryRepository.UpdateCourseCategory(mapper.Map<CourseCategory>(coursecate));
        }
    }
}
