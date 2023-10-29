using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DTO.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO_Service
{
    public class AnswerService
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IMapper mapper;
        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            this.answerRepository = answerRepository;
            this.mapper = mapper;
        }
        public void DeleteAnswer(AnswerDTO answer)
        {
            answerRepository.DeleteAnswer(mapper.Map<Answer>(answer));
        }

        public List<AnswerDTO> GetAnswer()
        {
            return mapper.Map<List<AnswerDTO>>(answerRepository.GetAnswer()) ;
        }

        public Answer? GetAnswer(int id)
        {
            return mapper.Map<Answer?>(answerRepository.GetAnswer(id));
        }

        public void SaveAnswer(AnswerDTO answer)
        {
            answerRepository.SaveAnswer(mapper.Map<Answer>(answer));
        }

        public void UpdateAnswer(AnswerDTO answer)
        {
            answerRepository.UpdateAnswer(mapper.Map<Answer>(answer));
        }
    }
}
