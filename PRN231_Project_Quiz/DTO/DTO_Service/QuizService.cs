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
    public class QuizService
    {
        private readonly IQuizRepository quizRepository;
        private readonly IMapper mapper;
        public QuizService(IQuizRepository quizRepository, IMapper mapper)
        {
            this.quizRepository = quizRepository;
            this.mapper = mapper;
        }
        public void DeleteQuiz(QuizDTO quiz)
        {
            quizRepository.DeleteQuiz(mapper.Map<Quiz>(quiz));
        }

        public List<QuizDTO> GetQuiz()
        {
            return mapper.Map<List<QuizDTO>>(quizRepository.GetQuiz());
        }

        public QuizDTO? GetQuiz(int id, string subjectId, int userid)
        {
            return mapper.Map<QuizDTO?>(quizRepository.GetQuiz(id,subjectId,userid));
        }

        public void SaveQuiz(QuizDTO quiz)
        {
            quizRepository.SaveQuiz(mapper.Map<Quiz>(quiz));
        }

        public void UpdateQuiz(QuizDTO quiz)
        {
            quizRepository.UpdateQuiz(mapper.Map<Quiz>(quiz));
        }
    }
}
