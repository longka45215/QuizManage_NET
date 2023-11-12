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
            CreateMap<CourseDTO, Course>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)).ReverseMap();
            CreateMap<SubjectDTO, Subject>().ReverseMap();
            CreateMap<Question, QuestionDTO>()
                .ForMember(dest=>dest.Answers,opt=>opt.MapFrom(src=>src.Answers));
            CreateMap<QuestionDTO, Question>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
            CreateMap<QuizDTO, Quiz>().ReverseMap();
            CreateMap<QuizHistoryDTO, QuizHistory>().ReverseMap();
            CreateMap<ExpertAssignDTO, ExpertAssign>().ReverseMap();
            CreateMap<CourseCategory, CourseCategoryDTO>().ReverseMap();
            CreateMap<RegisterDTO, Register>().ReverseMap();
            CreateMap<RoleDTO, RoleName>().ReverseMap();

        }
    }
}
