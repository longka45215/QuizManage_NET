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
    public class QuizHistoryService
    {
        private readonly IQuizHistoryRepository quizHistoryRepository;
        private readonly IMapper mapper;
        public QuizHistoryService(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
        {
            this.quizHistoryRepository = quizHistoryRepository;
            this.mapper = mapper;
        }
        public void DeleteQuizHistory(QuizHistoryDTO quizHis)
        {
            quizHistoryRepository.DeleteQuizHistory(mapper.Map<QuizHistory>(quizHis));
        }

        public List<QuizHistoryDTO> GetQuizHistory()
        {
            return mapper.Map<List<QuizHistoryDTO>>(quizHistoryRepository.GetQuizHistory());
        }

        public QuizHistory? GetQuizHistory(int id,int quesid)
        {
            return mapper.Map<QuizHistory?>(quizHistoryRepository.GetQuizHistory(id,quesid));
        }

        public void SaveQuizHistory(QuizHistoryDTO quizHis)
        {
            quizHistoryRepository.SaveQuizHistory(mapper.Map<QuizHistory>(quizHis));
        }

        public void UpdateQuizHistory(QuizHistoryDTO quizHis)
        {
            quizHistoryRepository.UpdateQuizHistory(mapper.Map<QuizHistory>(quizHis));
        }
    }
}
