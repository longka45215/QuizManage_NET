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
    public class SubjectService
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IMapper mapper;
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            this.subjectRepository = subjectRepository;
            this.mapper = mapper;
        }
        public void DeleteSubject(SubjectDTO subject)
        {
            subjectRepository.DeleteSubject(mapper.Map<Subject>(subject));
        }

        public List<SubjectDTO> GetSubjects()
        {
            return mapper.Map<List<SubjectDTO>>(subjectRepository.GetSubjects());
        }

        public Subject? GetSubject(string id)
        {
            return mapper.Map<Subject?>(subjectRepository.GetSubject(id));
        }

        public void SaveSubject(SubjectDTO subject)
        {
            subjectRepository.SaveSubject(mapper.Map<Subject>(subject));
        }

        public void UpdateSubject(SubjectDTO subject)
        {
            subjectRepository.UpdateSubject(mapper.Map<Subject>(subject));
        }
    }
}
