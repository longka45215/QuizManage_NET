using AutoMapper;
using BusinessObject.Models;
using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<AnswerDTO, Answer>().ReverseMap();
            CreateMap<CourseDTO, Course>().ReverseMap();
            CreateMap<SubjectDTO, Subject>().ReverseMap();
            CreateMap<QuestionDTO, Question>().ReverseMap();
            CreateMap<QuizDTO, Quiz>().ReverseMap();
            CreateMap<QuizHistoryDTO, QuizHistory>().ReverseMap();
            CreateMap<ExpertAssignDTO, ExpertAssign>().ReverseMap();
            CreateMap<CourseCategory, CourseCategoryDTO>().ReverseMap();
            CreateMap<RegisterDTO, Register>().ReverseMap();
            CreateMap<RoleDTO, RoleName>().ReverseMap();

        }
    }
}
