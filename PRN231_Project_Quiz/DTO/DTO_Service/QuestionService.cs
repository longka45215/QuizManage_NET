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
    public class QuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }
        public void DeleteQuestion(QuestionDTO ques)
        {
            questionRepository.DeleteQuestion(mapper.Map<Question>(ques));
        }

        public List<QuestionDTO> GetQuestion()
        {
            return mapper.Map<List<QuestionDTO>>(questionRepository.GetQuestion());
        }

        public Question? GetQuestion(int id)
        {
            return mapper.Map<Question?>(questionRepository.GetQuestion(id));
        }

        public void SaveQuestion(QuestionDTO ques)
        {
            questionRepository.SaveQuestion(mapper.Map<Question>(ques));
        }

        public void UpdateQuestion(QuestionDTO ques)
        {
            questionRepository.UpdateQuestion(mapper.Map<Question>(ques));
        }
    }
}
